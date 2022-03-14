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

namespace WaifuPartyCalcuator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float getVariance(IEnumerable<int> rRow)
        {
            float fMean = rRow.Sum() / 3.0f;
            return (float)(rRow.Sum(i => Math.Pow(i - fMean, 2.0)) / 3.0f);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var rRow = Enumerable.Range(1, 3).Select(i => { int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[i].Value?.ToString() ?? "0", out int v); if (v > 0) return v; return 0; });
            dataGridView1.Rows[e.RowIndex].Cells[4].Value = getVariance(rRow).ToString("F3", CultureInfo.InvariantCulture);
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnCount = dataGridView1.Columns.Count;
            int rowCount = dataGridView1.Rows.Count;
            if (columnCount <= 0 || rowCount <= 0) return;

            string[] outputCsv = new string[rowCount + 1];
            outputCsv[0] = Enumerable.Range(0, columnCount).Select(i => dataGridView1.Columns[i].HeaderText.ToString() + ",").Aggregate((c, s) => c + s);

            foreach (int rI in Enumerable.Range(0, rowCount))
            {
                if ((dataGridView1.Rows[rI].Cells[0].Value?.ToString() ?? "").Trim().Length == 0) continue;
                outputCsv[rI + 1] = Enumerable.Range(0, columnCount).Select(cI => "\"" + (dataGridView1.Rows[rI].Cells[cI].Value?.ToString() ?? "") + "\",").Aggregate((c, s) => c + s);
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
            dataGridView1.Rows.Clear();
            foreach (string row in inputCsv.Skip(1))
            {
                if (row.Trim().Length == 0) continue;
                int rI = dataGridView1.Rows.Add();
                foreach (var cell in row.Split(',').SkipLast(1).Select((v, i) => new { Value = v.Trim('"'), Index = i }))
                {
                    dataGridView1.Rows[rI].Cells[cell.Index].Value = cell.Value;
                }
            }
            dataGridView1.Refresh();
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
        IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
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
        IEnumerable<IEnumerable<T>> GetPermutationsFirst<T>(IEnumerable<T> items, int count)
        {
            foreach (T item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Where(x => x!=null && !EqualityComparer<T>.Default.Equals(x, item)),count -1))
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
        struct tmpRowData
        {
            public string[] Names;
            public int P, C, L;

            public float Variance;
        }
        IEnumerable<DataGridViewRow> FilteredRows()
        {
            foreach (DataGridViewRow? row in dataGridView1.Rows)
            {
                if (row == null) continue;
                //if ((row.Cells[0].Value?.ToString() ?? "").Trim().Length == 0) continue;
                //if ((row.Cells[1].Value?.ToString() ?? "").Trim().Length == 0) continue;
                //if ((row.Cells[2].Value?.ToString() ?? "").Trim().Length == 0) continue;
                //if ((row.Cells[3].Value?.ToString() ?? "").Trim().Length == 0) continue;
                if ((row.Cells[1].Value?.ToString() ?? "0") == "0" &&
                (row.Cells[2].Value?.ToString() ?? "0") == "0" &&
                (row.Cells[3].Value?.ToString() ?? "0") == "0")
                {
                    continue;
                }
                yield return row;
            }
        }
        IEnumerable<tmpRowData> GetRowData(List<DataGridViewRow> filteredRows)
        {

            const int partySize = 6;
            foreach (IEnumerable<DataGridViewRow> partyMembers in GetPermutationsFirst(filteredRows, partySize))
            {
                //if (rowOfIndexes.Any(i => (filteredRows[i].Cells[0].Value?.ToString() ?? "").Trim().Length == 0))
                //{
                //    continue;
                //}
                //if (rowOfIndexes.Any(i => (filteredRows[i].Cells[1].Value?.ToString() ?? "0").Trim() == "0" && (filteredRows[i].Cells[2].Value?.ToString() ?? "0").Trim() == "0" && (filteredRows[i].Cells[3].Value?.ToString() ?? "0").Trim() == "0"))
                //{
                //    continue;
                //}
                tmpRowData tmpRow = new tmpRowData
                {
                    Names = new string[partySize]
                };
                foreach (var data in partyMembers.Select((row, coli) => new { Row = row, CellIndex = coli }))
                {
                    tmpRow.Names[data.CellIndex] = data.Row.Cells[0].Value?.ToString() ?? "";
                }
                int GetCellValue(int currenti, DataGridViewRow row) { int.TryParse(row.Cells[currenti].Value?.ToString() ?? "0", out int outi); if (outi > 0) return outi; return 0; }
                double GetCombinedValue(int currenti, DataGridViewRow row) => partyMembers.Select(row => GetCellValue(currenti, row)).Average() / 2.0;
                double GetFirstValue(int currenti, DataGridViewRow row) => partyMembers.Select(row => GetCellValue(currenti, row)).First() / 2.0;
                int GetProcessedValue(int currenti) => (int)Math.Round(partyMembers.Select(row => GetFirstValue(currenti, row) + GetCombinedValue(currenti, row)).First(), 0);
                tmpRow.P = GetProcessedValue(1);
                tmpRow.C = GetProcessedValue(2);
                tmpRow.L = GetProcessedValue(3);
                bool checkNotMatchNumber(RadioButton radio, int i) => radio.Checked && (tmpRow.P != i || tmpRow.C != i || tmpRow.L != i);
                { // filter
                    if (checkNotMatchNumber(radio777, 7) || checkNotMatchNumber(radio888, 8) || checkNotMatchNumber(radio999, 9) || checkNotMatchNumber(radio101010, 10))
                    {
                        continue;
                    }
                    tmpRow.Variance = getVariance(new int[] { tmpRow.P, tmpRow.C, tmpRow.L });
                    if (!(radio777.Checked || radio888.Checked || radio999.Checked || radio101010.Checked || checkDistinct.Checked) && checkVariance.Checked && tmpRow.Variance <= float.Epsilon)// filter out zero matches when including Variance.
                    {
                        continue;
                    }
                }
                yield return tmpRow;
            }
        }

        IOrderedEnumerable<tmpRowData> GetSorted(IEnumerable<tmpRowData> tmpRows)
        {
            if (!checkVariance.Checked)
            {
                if (radioPLC.Checked)
                    return tmpRows.OrderByDescending(x => x.P).ThenByDescending(x => x.L).ThenByDescending(x => x.C);
                if (radioCPL.Checked)
                    return tmpRows.OrderByDescending(x => x.C).ThenByDescending(x => x.P).ThenByDescending(x => x.L);
                if (radioCLP.Checked)
                    return tmpRows.OrderByDescending(x => x.C).ThenByDescending(x => x.L).ThenByDescending(x => x.P);
                if (radioLPC.Checked)
                    return tmpRows.OrderByDescending(x => x.L).ThenByDescending(x => x.P).ThenByDescending(x => x.C);
                if (radioLCP.Checked)
                    return tmpRows.OrderByDescending(x => x.L).ThenByDescending(x => x.C).ThenByDescending(x => x.P);
                //if (radioPCL.Checked) //else
                return tmpRows.OrderByDescending(x => x.P).ThenByDescending(x => x.C).ThenByDescending(x => x.L);
            }

            if (radioPLC.Checked)
                return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.P).ThenByDescending(x => x.L).ThenByDescending(x => x.C);
            if (radioCPL.Checked)
                return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.C).ThenByDescending(x => x.P).ThenByDescending(x => x.L);
            if (radioCLP.Checked)
                return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.C).ThenByDescending(x => x.L).ThenByDescending(x => x.P);
            if (radioLPC.Checked)
                return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.L).ThenByDescending(x => x.P).ThenByDescending(x => x.C);
            if (radioLCP.Checked)
                return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.L).ThenByDescending(x => x.C).ThenByDescending(x => x.P);
            //if (radioPCL.Checked) //else
            return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.P).ThenByDescending(x => x.C).ThenByDescending(x => x.L);
        }
        IEnumerable<tmpRowData> Dedupe(IEnumerable<tmpRowData> tmpRows)
        {
            if (checkDistinct.Checked)
                return tmpRows.GroupBy(x => new { x.P, x.C, x.L }).Select(x => x.FirstOrDefault());
            return tmpRows.Select(x => x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int partySize = 6;
            int columnCount = dataGridView1.Columns.Count;
            var filteredRows = FilteredRows().ToList();
            int rowCount = filteredRows.Count;
            if (columnCount <= 0 || rowCount <= 0) return;
            var rRows = Enumerable.Range(0, rowCount);
            //var rPartyRowIndex = GetPermutations(rRows, partySize);
            dataGridView2.Rows.Clear();
            int.TryParse(textMax.Text, out int max);
            if (max <= 1)
                max = 100;
            foreach (var tmpRow in Dedupe(GetSorted(GetRowData(filteredRows))).Take(max))
            {
                { // add row
                    int currentRowIndex = dataGridView2.Rows.Add();
                    foreach (var data in tmpRow.Names.Select((x, coli) => new { Name = x, Index = coli }))
                    {
                        dataGridView2.Rows[currentRowIndex].Cells[data.Index].Value = data.Name;
                    }
                    void AppendNumber(int currenti, int value) => dataGridView2.Rows[currentRowIndex].Cells[partySize + currenti].Value = value.ToString();
                    void AppendNumberf(int currenti, float value) => dataGridView2.Rows[currentRowIndex].Cells[partySize + currenti].Value = value.ToString("F3", CultureInfo.InvariantCulture);
                    AppendNumber(0, tmpRow.P);
                    AppendNumber(1, tmpRow.C);
                    AppendNumber(2, tmpRow.L);
                    AppendNumberf(3, tmpRow.Variance);
                }
            }
            dataGridView2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
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
            dataGridView1.Rows.Clear();

            foreach (Match? match in matches)
            {
                if (match == null || !match.Success) continue;
                int rI = dataGridView1.Rows.Add();
                void ParseGroup(string str, int cI)
                {
                    if (match.Groups.TryGetValue(str, out Group group))
                    {
                        dataGridView1.Rows[rI].Cells[cI].Value = group.Value.Trim();
                    }
                }
                ParseGroup("Name", 0);
                ParseGroup("P", 1);
                ParseGroup("C", 2);
                ParseGroup("L", 3);
            }
            dataGridView1.Refresh();
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
    }
}
