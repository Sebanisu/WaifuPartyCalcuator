using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WaifuPartyCalcuator
{
    public partial class Form1 : Form
    {
        public static class ColPos
        {
            public const int Name = 0;
            public const int Perception = 1;
            public const int Charisma = 2;
            public const int Luck = 3;
            public const int Variance = 4;
            public const int Level = 5;
        }
        public Form1()
        {
            InitializeComponent();
        }

        static private float GenerateVariance(IEnumerable<int> rRow)
        {
            float fCount = 3.0f;//rRow.Count();
            float fMean = rRow.Sum() / fCount;
            return (float)(rRow.Sum(i => Math.Pow(i - fMean, 2.0)) / fCount);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var rRow = Enumerable.Range(1, 3).Select(i => { int.TryParse(dataGridViewInput.Rows[e.RowIndex].Cells[i].Value?.ToString() ?? "0", out int v); if (v > 0) return v; return 0; });
            dataGridViewInput.Rows[e.RowIndex].Cells[4].Value = GenerateVariance(rRow).ToString("F3", CultureInfo.InvariantCulture);
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnCount = dataGridViewInput.Columns.Count;
            int rowCount = dataGridViewInput.Rows.Count;
            if (columnCount <= 0 || rowCount <= 0) return;

            string[] outputCsv = new string[rowCount + 1];
            outputCsv[0] = Enumerable.Range(0, columnCount).Select(i => dataGridViewInput.Columns[i].HeaderText.ToString() + ",").Aggregate((c, s) => c + s);

            foreach (int rI in Enumerable.Range(0, rowCount))
            {
                if ((dataGridViewInput.Rows[rI].Cells[0].Value?.ToString() ?? "").Trim().Length == 0) continue;
                outputCsv[rI + 1] = Enumerable.Range(0, columnCount).Select(cI => "\"" + (dataGridViewInput.Rows[rI].Cells[cI].Value?.ToString() ?? "") + "\",").Aggregate((c, s) => c + s);
            }
            try
            {
                File.WriteAllLines("data.csv", outputCsv, Encoding.UTF8);
            }
            catch (Exception)
            {

            }
        }
        private void LoadData()
        {
            string[] inputCsv;
            try
            {
                inputCsv = File.ReadAllLines("data.csv");
            }
            catch
            {
                return;
            }
            dataGridViewInput.Rows.Clear();
            foreach (string row in inputCsv.Skip(1)) //skip headers
            {
                if (row.Trim().Length == 0) continue;
                int rI = dataGridViewInput.Rows.Add();
                foreach (var cell in row.Split(',').Take(dataGridViewInput.Columns.Count).Select((v, i) => new { Value = v.Trim('"'), Index = i }))
                {
                    dataGridViewInput.Rows[rI].Cells[cell.Index].Value = cell.Value;
                }
            }
            dataGridViewInput.Refresh();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /**
         * @see https://stackoverflow.com/a/12249225/2588183
         */
        private IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

        private IEnumerable<IEnumerable<T>> GetPermutationsFirst<T>(IEnumerable<T> items, int count)
        {
            foreach (T item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    Application.DoEvents();
                    foreach (var result in GetPermutations(items.Where(x => x != null && !EqualityComparer<T>.Default.Equals(x, item)), count - 1))
                        yield return new T[] { item }.Concat(result);
                }
            }
        }

        //static IEnumerable<IEnumerable<T>> GetPermutationsWithRept<T>(IEnumerable<T> list, int length)
        //{
        //    if (length == 1) return list.Select(t => new T[] { t });
        //    return GetPermutationsWithRept(list, length - 1)
        //        .SelectMany(t => list,
        //            (t1, t2) => t1.Concat(new T[] { t2 }));
        //}
        //static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        //{
        //    if (length == 1) return list.Select(t => new T[] { t });
        //    return GetPermutations(list, length - 1)
        //        .SelectMany(t => list.Where(o => !t.Contains(o)),
        //            (t1, t2) => t1.Concat(new T[] { t2 }));
        //}

        private interface IRawRowData
        {
            public int Perception { get; }
            public int Charisma { get; }
            public int Luck { get; }
            public int Level { get; }
            public float Variance { get; }
        }
        private static int GetPerception(IRawRowData x) => x.Perception;
        private static int GetCharisma(IRawRowData x) => x.Charisma;
        private static int GetLuck(IRawRowData x) => x.Luck;
        private static float GetVariance(IRawRowData x) => x.Variance;
        private static int GetLevel(IRawRowData x) => x.Level;

        private class RawOutputRowData : IRawRowData
        {
            public const int partySize = 6;
            public RawOutputRowData(RawInputRowData[] partyMembers)
            {
                m_names = new string[partySize];

                foreach (var data in partyMembers.Select((row, coli) => new { Row = row, CellIndex = coli }))
                {
                    m_names[data.CellIndex] = data.Row.Name;
                }
                double GetCombinedValue(Func<IRawRowData, int> func, IRawRowData row) => partyMembers.Select(row => func(row)).Skip(1).Average() / 2.0;
                float GetFirstValue(Func<IRawRowData, int> func, IRawRowData row) => partyMembers.Select(row => func(row)).First() / 2.0f;
                int GetProcessedValue(Func<IRawRowData, int> func) => (int)partyMembers.Select(row => Math.Ceiling(GetFirstValue(func, row) + GetCombinedValue(func, row))).First();
                Perception = GetProcessedValue(GetPerception);
                Charisma = GetProcessedValue(GetCharisma);
                Luck = GetProcessedValue(GetLuck);
                Level = GetProcessedValue(GetLevel);

                Variance = GenerateVariance(new int[] { Perception, Charisma, Luck });
            }
            private string[] m_names;
            public IReadOnlyList<string> Names { get => m_names; }
            public int Perception { get; }
            public int Charisma { get; }
            public int Luck { get; }
            public int Level { get; }
            public float Variance { get; }
        }
        private class RawInputRowData : IRawRowData
        {
            static private int IGetCellValue(int currenti, DataGridViewRow row) { int.TryParse(row.Cells[currenti].Value?.ToString() ?? "0", out int outi); if (outi > 0) return outi; return 0; }
            static private float FGetCellValue(int currenti, DataGridViewRow row) { float.TryParse(row.Cells[currenti].Value?.ToString() ?? "0.0", out float outf); if (outf > 0.0f) return outf; return 0.0f; }
            public RawInputRowData(DataGridViewRow row)
            {
                Name = row.Cells[ColPos.Name].Value?.ToString() ?? "";
                Perception = IGetCellValue(ColPos.Perception, row);
                Charisma = IGetCellValue(ColPos.Charisma, row);
                Luck = IGetCellValue(ColPos.Luck, row);
                Level = IGetCellValue(ColPos.Level, row);
                Variance = FGetCellValue(ColPos.Variance, row);
            }

            public string Name { get; }
            public int Perception { get; }
            public int Charisma { get; }
            public int Luck { get; }
            public int Level { get; }
            public float Variance { get; }
        }

        private ParallelQuery<RawInputRowData> FilterInputRows()
        {
            return from DataGridViewRow? row in dataGridViewInput.Rows.AsParallel()
                   where row != null && !((row.Cells[ColPos.Perception].Value?.ToString() ?? "0") == "0" &&
                (row.Cells[ColPos.Charisma].Value?.ToString() ?? "0") == "0" &&
                (row.Cells[ColPos.Luck].Value?.ToString() ?? "0") == "0")
                   select new RawInputRowData(row);
        }

        private IEnumerable<RawOutputRowData> GetRowData(IEnumerable<RawInputRowData> filteredRows)
        {
            foreach (var partyMembers in GetPermutationsFirst(filteredRows, RawOutputRowData.partySize))
            {
                //if (rowOfIndexes.Any(i => (filteredRows[i].Cells[0].Value?.ToString() ?? "").Trim().Length == 0))
                //{
                //    continue;
                //}
                //if (rowOfIndexes.Any(i => (filteredRows[i].Cells[1].Value?.ToString() ?? "0").Trim() == "0" && (filteredRows[i].Cells[2].Value?.ToString() ?? "0").Trim() == "0" && (filteredRows[i].Cells[3].Value?.ToString() ?? "0").Trim() == "0"))
                //{
                //    continue;
                //}
                RawOutputRowData tmpRow = new RawOutputRowData(partyMembers.ToArray());

                bool checkNotMatchNumber(RadioButton radio, int i) => radio.Checked && (tmpRow.Perception != i || tmpRow.Charisma != i || tmpRow.Luck != i);
                { // filter
                    if (checkNotMatchNumber(radio777, 7) || checkNotMatchNumber(radio888, 8) || checkNotMatchNumber(radio999, 9) || checkNotMatchNumber(radio101010, 10))
                    {
                        continue;
                    }
                    //if (!(radio777.Checked || radio888.Checked || radio999.Checked || radio101010.Checked || checkDistinct.Checked) && tmpRow.Variance <= float.Epsilon)// filter out zero matches when including Variance.
                    //{
                    //    continue;
                    //}
                }
                Application.DoEvents();
                yield return tmpRow;
            }
        }

        private IOrderedEnumerable<RawOutputRowData> Sort(IEnumerable<RawOutputRowData> tmpRows)
        {
            IEnumerable<ListViewItem> sortItems = GetSortItems();
            ListViewItem? current = sortItems.FirstOrDefault();
            if (current != null)
            {
                if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Sort(tmpRows.OrderByDescending(GetPerception), sortItems.Skip(1));
                }
                if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Sort(tmpRows.OrderByDescending(GetCharisma), sortItems.Skip(1));
                }
                if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Sort(tmpRows.OrderByDescending(GetLuck), sortItems.Skip(1));
                }
                if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Sort(tmpRows.OrderByDescending(GetLevel), sortItems.Skip(1));
                }
            }
            return Sort(tmpRows.OrderBy(GetVariance), sortItems.Skip(1));
        }
        private static IOrderedEnumerable<RawOutputRowData> Sort(IOrderedEnumerable<RawOutputRowData> tmpRows, IEnumerable<ListViewItem> sortItems)
        {
            foreach (ListViewItem? current in sortItems)
            {
                if (current != null)
                {
                    if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
                    {
                        tmpRows = tmpRows.ThenByDescending(GetPerception);
                    }
                    if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
                    {
                        tmpRows = tmpRows.ThenByDescending(GetCharisma);
                    }
                    if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
                    {
                        tmpRows = tmpRows.ThenByDescending(GetLuck);
                    }
                    if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
                    {
                        tmpRows = tmpRows.ThenByDescending(GetLevel);
                    }
                    if (current.Text.Equals("Variance", StringComparison.InvariantCultureIgnoreCase))
                    {
                        tmpRows = tmpRows.ThenBy(GetVariance);
                    }
                }
            }
            return tmpRows;
        }
        private IOrderedEnumerable<RawOutputRowData> GetSorted(IEnumerable<RawOutputRowData> tmpRows)
        {
            return Sort(tmpRows);
            //if (!checkVariance.Checked)
            //{
            //    if (radioPLC.Checked)
            //        return tmpRows.OrderByDescending(x => x.P).ThenByDescending(x => x.L).ThenByDescending(x => x.C);
            //    if (radioCPL.Checked)
            //        return tmpRows.OrderByDescending(x => x.C).ThenByDescending(x => x.P).ThenByDescending(x => x.L);
            //    if (radioCLP.Checked)
            //        return tmpRows.OrderByDescending(x => x.C).ThenByDescending(x => x.L).ThenByDescending(x => x.P);
            //    if (radioLPC.Checked)
            //        return tmpRows.OrderByDescending(x => x.L).ThenByDescending(x => x.P).ThenByDescending(x => x.C);
            //    if (radioLCP.Checked)
            //        return tmpRows.OrderByDescending(x => x.L).ThenByDescending(x => x.C).ThenByDescending(x => x.P);
            //    //if (radioPCL.Checked) //else
            //    return tmpRows.OrderByDescending(x => x.P).ThenByDescending(x => x.C).ThenByDescending(x => x.L);
            //}

            //if (radioPLC.Checked)
            //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.P).ThenByDescending(x => x.L).ThenByDescending(x => x.C);
            //if (radioCPL.Checked)
            //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.C).ThenByDescending(x => x.P).ThenByDescending(x => x.L);
            //if (radioCLP.Checked)
            //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.C).ThenByDescending(x => x.L).ThenByDescending(x => x.P);
            //if (radioLPC.Checked)
            //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.L).ThenByDescending(x => x.P).ThenByDescending(x => x.C);
            //if (radioLCP.Checked)
            //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.L).ThenByDescending(x => x.C).ThenByDescending(x => x.P);
            ////if (radioPCL.Checked) //else
            //return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.P).ThenByDescending(x => x.C).ThenByDescending(x => x.L);
        }

        private IEnumerable<RawOutputRowData> Dedupe(IEnumerable<RawOutputRowData> tmpRows)
        {
            if (checkDistinct.Checked)
                return tmpRows.GroupBy(x => new { x.Perception, x.Charisma, x.Luck, x.Level }).Select(x => x.FirstOrDefault());
            return tmpRows.Select(x => x);
        }
        private IEnumerable<RawInputRowData[]> newGetOutputRow(List<RawInputRowData> filteredRows)
        {
            long combinations = 0;
            var q = filteredRows.AsParallel();
                foreach (var item1 in q)
                {
                    var less2filteredrows = q.Skip(1);
                    foreach (var item2 in less2filteredrows)
                    {
                        var less3filteredrows = less2filteredrows.Skip(1);
                        foreach (var item3 in less3filteredrows)
                        {
                            var less4filteredrows = less3filteredrows.Skip(1);
                            foreach (var item4 in less4filteredrows)
                            {
                                var less5filteredrows = less4filteredrows.Skip(1);
                                foreach (var item5 in less5filteredrows)
                                {
                                    yield return new[] { item1, item2, item3, item4, item5 };
                                    if (++combinations % 1000000 == 0)
                                        Trace.WriteLine(combinations);
                                    //Trace.WriteLine(combinations + ": " + item0.Name + ", " + item1.Name + ", " + item2.Name + ", " + item3.Name + ", " + item4.Name + ", " + item5.Name);
                                }
                            }
                        }
                    }
                }
            
            Trace.WriteLine("Combinations Count = " + combinations);
        }
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            //const int partySize = 6;
            int columnCount = dataGridViewInput.Columns.Count;
            var filteredRows = FilterInputRows().ToList();
            int rowCount = filteredRows.Count;
            if (columnCount <= 0 || rowCount <= 0) return;
            const string wait = "Please Wait...";
            string button_string_value = buttonGenerate.Text;
            buttonGenerate.Text = wait;
            buttonGenerate.Enabled = false;
            foreach (var row in filteredRows)
            {
                Trace.WriteLine(row.Name + ", " + row.Level + ", " + row.Perception + ", " + row.Charisma + ", " + row.Luck);
            }
            Trace.WriteLine("FiltereRows.Count = " + filteredRows.Count);

            foreach (var row in newGetOutputRow(filteredRows))
            {
                //Trace.WriteLine(String.Join(", ", row.Names)+ ", "+ String.Join(", ", new[] { row.Level + row.Perception, row.Charisma, row.Luck, row.Variance }));
            }

            
            //var rRows = Enumerable.Range(0, rowCount);
            //dataGridViewOutput.Rows.Clear();
            //int.TryParse(textMax.Text, out int max);
            //if (max <= 1)
            //    max = 100;
            //foreach (var tmpRow in Dedupe(GetSorted(GetRowData(filteredRows))).Take(max))
            //{
            //    { // add row
            //        int currentRowIndex = dataGridViewOutput.Rows.Add();
            //        foreach (var data in tmpRow.Names.Select((x, coli) => new { Name = x, Index = coli }))
            //        {
            //            dataGridViewOutput.Rows[currentRowIndex].Cells[data.Index].Value = data.Name;
            //        }
            //        void AppendNumber(int currenti, int value) => dataGridViewOutput.Rows[currentRowIndex].Cells[partySize + currenti - 1].Value = value.ToString();
            //        void AppendNumberf(int currenti, float value) => dataGridViewOutput.Rows[currentRowIndex].Cells[partySize + currenti - 1].Value = value.ToString("F3", CultureInfo.InvariantCulture);
            //        AppendNumber(ColPos.Perception, tmpRow.Perception);
            //        AppendNumber(ColPos.Charisma, tmpRow.Charisma);
            //        AppendNumber(ColPos.Luck, tmpRow.Luck);
            //        AppendNumberf(ColPos.Variance, tmpRow.Variance);
            //        AppendNumber(ColPos.Level, tmpRow.Level);
            //    }
            //    Application.DoEvents();
            //}
            dataGridViewOutput.Refresh();
            buttonGenerate.Text = button_string_value;
            buttonGenerate.Enabled = true;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Regex regex;
            try
            {
                regex = new Regex(textRegex.Text, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Multiline);
            }
            catch (Exception)
            {
                return;
            }
            var matches = regex.Matches(textSourceCode.Text);
            if (matches == null || matches.Count == 0) return;
            dataGridViewInput.Rows.Clear();

            foreach (Match? match in matches)
            {
                if (match == null || !match.Success) continue;
                int rI = dataGridViewInput.Rows.Add();
                void ParseGroup(string str, int cI)
                {
                    if (match.Groups.TryGetValue(str, out Group group))
                    {
                        dataGridViewInput.Rows[rI].Cells[cI].Value = group.Value.Trim();
                    }
                }
                ParseGroup("Name", ColPos.Name);
                ParseGroup("P", ColPos.Perception);
                ParseGroup("C", ColPos.Charisma);
                ParseGroup("L", ColPos.Luck);
                ParseGroup("Level", ColPos.Level);
            }
            dataGridViewInput.Refresh();
        }
        private void UpdateCount()
        {
            Regex regex;
            try
            {
                regex = new Regex(textRegex.Text, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Multiline);
            }
            catch (Exception ex)
            {
                labelCount.Text = ex.Message;
                return;
            }
            var matches = regex.Matches(textSourceCode.Text);
            if (matches == null || matches.Count == 0)
            {
                labelCount.Text = "0";
                return;
            }
            labelCount.Text = matches.Count.ToString();
        }
        private void textRegex_TextChanged(object sender, EventArgs e)
        {
            UpdateCount();
        }

        private void textSourceCode_TextChanged(object sender, EventArgs e)
        {
            UpdateCount();
        }
        IEnumerable<ListViewItem> GetSortItems()
        {
            foreach (ListViewItem? item in listView1.Items)
            {
                if (item != null)
                    yield return item;
            }
        }
        ListViewItem? heldDownItem;
        Point heldDownPoint;
        //MouseDown event handler for your listView1
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            //listView1.AutoArrange = false;
            heldDownItem = listView1.GetItemAt(e.X, e.Y);
            if (heldDownItem != null)
            {
                heldDownPoint = new Point(e.X - heldDownItem.Position.X,
                                          e.Y - heldDownItem.Position.Y);
            }
        }
        //MouseMove event handler for your listView1
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (heldDownItem != null)
            {
                heldDownItem.Position = new Point(e.Location.X - heldDownPoint.X,
                                                  e.Location.Y - heldDownPoint.Y);

            }
        }
        //MouseUp event handler for your listView1
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (heldDownItem != null)
            {
                listView1.Items.Remove(heldDownItem);
                var new_order = GetSortItems().Concat(new ListViewItem[] { heldDownItem }).OrderBy(x => x.Position.Y).ThenBy(x => x.Position.X).ToArray();
                listView1.Items.Clear();
                listView1.Items.AddRange(new_order);
                heldDownItem = null;
                //listView1.AutoArrange = true;         
            }
        }

    }
}
