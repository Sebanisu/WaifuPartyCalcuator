﻿using System;
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
using System.Diagnostics.CodeAnalysis;

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

        static private float CalcVariance(int[] rRow)
        {
            float fCount = 3.0f;//rRow.Count();
            float fMean = rRow.Sum() / fCount;
            return (float)(rRow.Sum(i => Math.Pow(i - fMean, 2.0)) / fCount);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var rRow = Enumerable.Range(1, 3).Select(i => { int.TryParse(dataGridViewInput.Rows[e.RowIndex].Cells[i].Value?.ToString() ?? "0", out int v); if (v > 0) return v; return 0; });
            dataGridViewInput.Rows[e.RowIndex].Cells[4].Value = CalcVariance(rRow.ToArray()).ToString("F3", CultureInfo.InvariantCulture);
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
        private IEnumerable<IEnumerable<T>> GetPermutations2<T>(ParallelQuery<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations2(items.Skip(i + 1), count - 1))
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

                Variance = CalcVariance(new int[] { Perception, Charisma, Luck });
            }
            readonly private string[] m_names;
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

        //private IOrderedEnumerable<RawOutputRowData> Sort(IEnumerable<RawOutputRowData> tmpRows)
        //{
        //    IEnumerable<ListViewItem> sortItems = GetSortItems();
        //    ListViewItem? current = sortItems.FirstOrDefault();
        //    if (current != null)
        //    {
        //        if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            return Sort(tmpRows.OrderByDescending(GetPerception), sortItems.Skip(1));
        //        }
        //        if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            return Sort(tmpRows.OrderByDescending(GetCharisma), sortItems.Skip(1));
        //        }
        //        if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            return Sort(tmpRows.OrderByDescending(GetLuck), sortItems.Skip(1));
        //        }
        //        if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            return Sort(tmpRows.OrderByDescending(GetLevel), sortItems.Skip(1));
        //        }
        //    }
        //    return Sort(tmpRows.OrderBy(GetVariance), sortItems.Skip(1));
        //}
        //private static IOrderedEnumerable<RawOutputRowData> Sort(IOrderedEnumerable<RawOutputRowData> tmpRows, IEnumerable<ListViewItem> sortItems)
        //{
        //    foreach (ListViewItem? current in sortItems)
        //    {
        //        if (current != null)
        //        {
        //            if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                tmpRows = tmpRows.ThenByDescending(GetPerception);
        //            }
        //            if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                tmpRows = tmpRows.ThenByDescending(GetCharisma);
        //            }
        //            if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                tmpRows = tmpRows.ThenByDescending(GetLuck);
        //            }
        //            if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                tmpRows = tmpRows.ThenByDescending(GetLevel);
        //            }
        //            if (current.Text.Equals("Variance", StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                tmpRows = tmpRows.ThenBy(GetVariance);
        //            }
        //        }
        //    }
        //    return tmpRows;
        //}
        //private IOrderedEnumerable<RawOutputRowData> GetSorted(IEnumerable<RawOutputRowData> tmpRows)
        //{
        //    return Sort(tmpRows);
        //    //if (!checkVariance.Checked)
        //    //{
        //    //    if (radioPLC.Checked)
        //    //        return tmpRows.OrderByDescending(x => x.P).ThenByDescending(x => x.L).ThenByDescending(x => x.C);
        //    //    if (radioCPL.Checked)
        //    //        return tmpRows.OrderByDescending(x => x.C).ThenByDescending(x => x.P).ThenByDescending(x => x.L);
        //    //    if (radioCLP.Checked)
        //    //        return tmpRows.OrderByDescending(x => x.C).ThenByDescending(x => x.L).ThenByDescending(x => x.P);
        //    //    if (radioLPC.Checked)
        //    //        return tmpRows.OrderByDescending(x => x.L).ThenByDescending(x => x.P).ThenByDescending(x => x.C);
        //    //    if (radioLCP.Checked)
        //    //        return tmpRows.OrderByDescending(x => x.L).ThenByDescending(x => x.C).ThenByDescending(x => x.P);
        //    //    //if (radioPCL.Checked) //else
        //    //    return tmpRows.OrderByDescending(x => x.P).ThenByDescending(x => x.C).ThenByDescending(x => x.L);
        //    //}

        //    //if (radioPLC.Checked)
        //    //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.P).ThenByDescending(x => x.L).ThenByDescending(x => x.C);
        //    //if (radioCPL.Checked)
        //    //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.C).ThenByDescending(x => x.P).ThenByDescending(x => x.L);
        //    //if (radioCLP.Checked)
        //    //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.C).ThenByDescending(x => x.L).ThenByDescending(x => x.P);
        //    //if (radioLPC.Checked)
        //    //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.L).ThenByDescending(x => x.P).ThenByDescending(x => x.C);
        //    //if (radioLCP.Checked)
        //    //    return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.L).ThenByDescending(x => x.C).ThenByDescending(x => x.P);
        //    ////if (radioPCL.Checked) //else
        //    //return tmpRows.OrderBy(x => x.Variance).ThenByDescending(x => x.P).ThenByDescending(x => x.C).ThenByDescending(x => x.L);
        //}

        private IEnumerable<Tuple<RawInputRowData, RawInputRowData[]>> Dedupe(IEnumerable<Tuple<RawInputRowData, RawInputRowData[]>> tmpRows)
        {
            if (checkDistinct.Checked)
                return tmpRows.GroupBy(f => {
                    (RawInputRowData first, RawInputRowData[] rest) = f;
                    var final_party = rest.Skip(1).Append(first).ToArray();
                    return new
                    {
                        p = (int)Math.Ceiling(CalcStat(x => x.Perception, rest[0], final_party)),
                        c = (int)Math.Ceiling(CalcStat(x => x.Charisma, rest[0], final_party)),
                        l = (int)Math.Ceiling(CalcStat(x => x.Luck, rest[0], final_party)),
                        lvl = (int)Math.Ceiling(CalcStat(x => x.Level, rest[0], final_party))
                    };
                }).Select(x => x.FirstOrDefault());
            return tmpRows.Select(x => x);
        }
        public double factorial_WhileLoop(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                --number;
            }
            return result;
        }
        private long MaxCount(int n)
        {

            const int r = 5;
            double max_count = factorial_WhileLoop(n) / (factorial_WhileLoop(r) * factorial_WhileLoop(n - r));
            return (long)max_count;
        }
        class combination
        {
            public RawInputRowData[] Raw { get; }
            public float Level { get; }
            public float Perception { get; }
            public float Charisma { get; }
            public float Luck { get; }
            public combination(RawInputRowData[] in_raw)
            {
                Raw = in_raw;
                Level = (float)(in_raw.Average(x => x.Level) / 2.0d);
                Perception = (float)(in_raw.Average(x => x.Perception) / 2.0d);
                Charisma = (float)(in_raw.Average(x => x.Charisma) / 2.0d);
                Luck = (float)(in_raw.Average(x => x.Luck) / 2.0d);
            }
        }
        class combinationComparer : IEqualityComparer<combination>
        {
            public bool Equals([AllowNull] combination x, [AllowNull] combination y)
            {
                if (x == y) return true;
                if (x == null || y == null) return false;
                if (x.Level != y.Level) return false;
                if (x.Perception != y.Perception) return false;
                if (x.Charisma != y.Charisma) return false;
                if (x.Luck != y.Luck) return false;
                return false;
            }

            public int GetHashCode([DisallowNull] combination obj)
            {
                return Tuple.Create(obj.Level, obj.Perception, obj.Charisma, obj.Luck).GetHashCode();
            }
        }
        class first_column
        {

            public RawInputRowData Raw { get; }
            public float Level { get; }
            public float Perception { get; }
            public float Charisma { get; }
            public float Luck { get; }

            public first_column(RawInputRowData in_raw)
            {
                Raw = in_raw;
                Level = in_raw.Level / 2.0f;
                Perception = in_raw.Perception / 2.0f;
                Charisma = in_raw.Charisma / 2.0f;
                Luck = in_raw.Luck / 2.0f;
            }
        }

        class first_columnComparer : IEqualityComparer<first_column>
        {
            public bool Equals([AllowNull] first_column x, [AllowNull] first_column y)
            {
                if (x == y) return true;
                if (x == null || y == null) return false;
                if (x.Level != y.Level) return false;
                if (x.Perception != y.Perception) return false;
                if (x.Charisma != y.Charisma) return false;
                if (x.Luck != y.Luck) return false;
                return false;
            }

            public int GetHashCode([DisallowNull] first_column obj)
            {
                return Tuple.Create(obj.Level, obj.Perception, obj.Charisma, obj.Luck).GetHashCode();
            }
        }
        private IEnumerable<first_column> getfirst_columns(List<RawInputRowData> filteredRows)
        {
            foreach (var item in filteredRows.AsParallel())
            {
                yield return new first_column(item);
            }
        }
        class combined_output
        {
            public RawInputRowData[] Raw { get; }
            public int Level { get; }
            public int Perception { get; }
            public int Charisma { get; }
            public int Luck { get; }
            public float Variance { get; }
            public bool Valid { get; } = false;
            public combined_output(first_column in_first_column, combination in_combination)
            {
                if (in_combination.Raw.Contains(in_first_column.Raw))
                {
                    return;
                }
                Raw = in_combination.Raw.Prepend(in_first_column.Raw).ToArray();
                Level = (int)Math.Ceiling(in_first_column.Level + in_combination.Level);
                Perception = (int)Math.Ceiling(in_first_column.Perception + in_combination.Perception);
                Charisma = (int)Math.Ceiling(in_first_column.Charisma + in_combination.Charisma);
                Luck = (int)Math.Ceiling(in_first_column.Luck + in_combination.Luck);
                Variance = CalcVariance(new int[] { Perception, Charisma, Luck });
                Valid = true;
            }
        }
        private IEnumerable<combination> getcombinations(List<RawInputRowData> filteredRows)
        {
            long combinations = 0;
            long max_count = MaxCount(filteredRows.Count());
            var q = filteredRows.AsParallel();
            foreach (var items in GetPermutations2(q, 5))
            {
                if (++combinations % 1000000 == 0)
                {
                    Trace.WriteLine(combinations + " / " + max_count);
                }
                if (combinations % 10000 == 0)
                {
                    label4.Text = "Combinations: " + (((double)(combinations) / (double)max_count) * 100).ToString("00.000") + "%";
                    Application.DoEvents();
                }
                yield return new combination(items.ToArray());

            }
            Trace.WriteLine("Combinations Count = " + combinations);
            label4.Text = "";
        }
        private void saveoutputtofile(IEnumerable<combined_output> combined_Outputs)
        {
            try
            {
                using (FileStream fs = File.Open("output.csv", FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        {
                            int columnCount = dataGridViewOutput.Columns.Count;
                            string header = Enumerable.Range(0, columnCount).Select(i => dataGridViewOutput.Columns[i].HeaderText.ToString() + ",").Aggregate((c, s) => c + s);
                            Debug.WriteLine(header);
                            sw.WriteLine(header);
                            sw.Flush();
                        }
                        foreach (var output in combined_Outputs)
                        {
                            string outputcsv =
                            output.Raw.Select(i => "\"" + i.Name + "\",").Aggregate((c, s) => c + s);
                            void AppendNumber(int value) => outputcsv += value.ToString() + ",";
                            void AppendNumberf(float value) => outputcsv += value.ToString("F3", CultureInfo.InvariantCulture) + ",";
                            AppendNumber(output.Perception);
                            AppendNumber(output.Charisma);
                            AppendNumber(output.Luck);
                            AppendNumberf(output.Variance);
                            AppendNumber(output.Level);
                            Debug.WriteLine(outputcsv);
                            sw.WriteLine(outputcsv);
                            sw.Flush();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private IEnumerable<combined_output> GetCombined_Outputs(first_column[] first_Columns, combination[] combinations)
        {

            long approx_max_rows = first_Columns.Length * combinations.Length;
            long current_row = 0;
            foreach (first_column first in first_Columns.AsParallel())
                foreach (combination combination in combinations.AsParallel())
                {
                    var tmpRow = new combined_output(first, combination);
                    if (!tmpRow.Valid) continue;
                    yield return tmpRow;

                    if (current_row % 1000 == 0)
                    {
                        label4.Text = "Rows Output: " + (((double)(current_row) / (double)approx_max_rows) * 100).ToString("00.000") + "%";
                        Trace.WriteLine(current_row);
                        Application.DoEvents();
                    }
                    ++current_row;
                }
            label4.Text = "";
        }
        private IOrderedEnumerable<RawInputRowData> Sort1(IEnumerable<RawInputRowData> tmpRows, RawInputRowData[]? current_party = default, IEnumerable<ListViewItem>? sortItems = default)
        {
            //if (current_party != null && current_party.Length != 0)
            //{
            //    return tmpRows.OrderBy(x => CalcVariance(current_party[0], current_party.Skip(1).Append(x).ToArray()));
            //}
            //else
            //{
            //    return tmpRows.OrderBy(x => CalcVariance(x));
            //}
            if (sortItems == null)
                sortItems = GetSortItems();
            ListViewItem? current = sortItems.FirstOrDefault();
            if (current != null)
            {
                if (current_party != null && current_party.Length != 0)
                {
                    if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetGoal, y => y.Perception, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetGoal, y => y.Charisma, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetGoal, y => y.Luck, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetLevel, y => y.Level, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Variance", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcVariance(current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                }
                else
                {
                    if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetGoal, y => y.Perception, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetGoal, y => y.Charisma, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetGoal, y => y.Luck, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcRemaining(TargetLevel, y => y.Level, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Variance", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.OrderBy(x => CalcVariance(x)), current_party, sortItems.Skip(1));
                    }
                }
            }

            return tmpRows.OrderBy(x => 1);
        }
        private IOrderedEnumerable<RawInputRowData> Sort2(IOrderedEnumerable<RawInputRowData> tmpRows, RawInputRowData[]? current_party = default, IEnumerable<ListViewItem>? sortItems = default)
        {

            if (sortItems == null)
                sortItems = GetSortItems();
            ListViewItem? current = sortItems.FirstOrDefault();
            if (current != null)
            {
                if (current_party != null && current_party.Length != 0)
                {
                    if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetGoal, y => y.Perception, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetGoal, y => y.Charisma, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetGoal, y => y.Luck, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetLevel, y => y.Level, current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Variance", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcVariance(current_party[0], current_party.Skip(1).Append(x).ToArray())), current_party, sortItems.Skip(1));
                    }
                }
                else
                {
                    if (current.Text.Equals("Perception", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetGoal, y => y.Perception, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Charisma", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetGoal, y => y.Charisma, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Luck", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetGoal, y => y.Luck, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Level", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcRemaining(TargetLevel, y => y.Level, x)), current_party, sortItems.Skip(1));
                    }
                    if (current.Text.Equals("Variance", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Sort2(tmpRows.ThenBy(x => CalcVariance(x)), current_party, sortItems.Skip(1));
                    }
                }
            }
            return tmpRows;
        }
        private int TargetGoal
        {
            get
            {
                if (radio777.Checked)
                { return 7; }
                if (radio888.Checked)
                { return 8; }
                if (radio999.Checked)
                {
                    return 9;
                }
                return 10;
            }
        }
        private const int TargetLevel = 100;

        private float CalcVariance(RawInputRowData first, RawInputRowData[]? rest = default)
        {
            return CalcVariance(new int[] { (int)Math.Ceiling(CalcStat(x => x.Perception, first, rest)), (int)Math.Ceiling(CalcStat(x => x.Charisma, first, rest)), (int)Math.Ceiling(CalcStat(x => x.Luck, first, rest)) });
        }
        private float CalcStat(Func<RawInputRowData, int> func, RawInputRowData first, RawInputRowData[]? rest = default)
        {
            return (5 * func(first) + (rest?.Sum(x => func(x)) ?? 0)) / 10.0f;
        }
        private float CalcRemaining(int goal, Func<RawInputRowData, int> func, RawInputRowData first, RawInputRowData[]? rest = default)
        {
            return Math.Abs(10.0f * goal - (5 * func(first) + (rest?.Sum(x => func(x)) ?? 0)));
        }
        const int max_per_level = 3;

        private void AddOutputRow(RawInputRowData first, RawInputRowData[] rest)

        {

            if (dataGridViewOutput.Columns.Count == 0) return;
            { // add row
                const int partySize = 6;
                int currentRowIndex = dataGridViewOutput.Rows.Add();
                foreach (var data in rest.Prepend(first).Select(x => x.Name).Select((x, coli) => new { Name = x, Index = coli }))
                {
                    dataGridViewOutput.Rows[currentRowIndex].Cells[data.Index].Value = data.Name;
                }
                void AppendNumberi(int currenti, float value) => dataGridViewOutput.Rows[currentRowIndex].Cells[partySize + currenti - 1].Value = ((int)Math.Ceiling(value)).ToString();
                void AppendNumberf(int currenti, float value) => dataGridViewOutput.Rows[currentRowIndex].Cells[partySize + currenti - 1].Value = value.ToString("F3", CultureInfo.InvariantCulture);
                AppendNumberi(ColPos.Perception, CalcStat(x => x.Perception, first, rest));
                AppendNumberi(ColPos.Charisma, CalcStat(x => x.Charisma, first, rest));
                AppendNumberi(ColPos.Luck, CalcStat(x => x.Luck, first, rest));
                AppendNumberf(ColPos.Variance, CalcVariance(first, rest));
                AppendNumberi(ColPos.Level, CalcStat(x => x.Level, first, rest));

                if (currentRowIndex % 50 == 0)
                    Application.DoEvents();
            }
        }
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int columnCount = dataGridViewInput.Columns.Count;
            var filteredRows = FilterInputRows().ToArray();
            int rowCount = filteredRows.Length;
            if (columnCount <= 0 || rowCount <= 0) return;
            const string wait = "Please Wait...";
            string button_string_value = buttonGenerate.Text;
            buttonGenerate.Text = wait;
            buttonGenerate.Enabled = false;
            void traceout(RawInputRowData member, RawInputRowData[]? tmpparty = default)
            {
                var final_party = tmpparty?.Skip(1).Append(member).ToArray();
                Trace.WriteLine(string.Concat(Enumerable.Repeat("\t", tmpparty?.Length ?? 0)) + member.Name + ", " + member.Level + ", " + member.Perception + ", " + member.Charisma + ", " + member.Luck + ", " +
                CalcRemaining(TargetLevel, (x => x.Level), member, tmpparty) + ", " +
                CalcRemaining(TargetGoal, (x => x.Perception), member, tmpparty) + ", " +
                CalcRemaining(TargetGoal, (x => x.Charisma), member, tmpparty) + ", " +
                CalcRemaining(TargetGoal, (x => x.Luck), member, tmpparty) + ", v_" +
                        CalcVariance(tmpparty?.FirstOrDefault() ?? member, final_party));
            };
            void traceoutfinalgroupstats(RawInputRowData member, RawInputRowData[]? tmpparty = default)
            {
                var final_party = tmpparty.Skip(1).Append(member).ToArray();
                Trace.WriteLine("\t\t\t\t\t\t" + CalcStat((x => x.Level), tmpparty[0], final_party) + ", " +
                    CalcStat((x => x.Perception), tmpparty[0], final_party) + ", " +
                    CalcStat((x => x.Charisma), tmpparty[0], final_party) + ", " +
                    CalcStat((x => x.Luck), tmpparty[0], final_party) + ", V" +
                    CalcVariance(tmpparty[0], final_party));
                AddOutputRow(tmpparty[0], final_party);
            }
            IEnumerable<Tuple<RawInputRowData, RawInputRowData[]>> Loop()
            {
                foreach (var party0 in Sort1(filteredRows))
                {
                    traceout(party0);
                    var tmp_party1 = new RawInputRowData[] { party0 };
                    foreach (var party1 in Sort1(filteredRows.Where(x => !tmp_party1.Contains(x)), tmp_party1).Take(max_per_level))
                    {
                        traceout(party1, tmp_party1);
                        var tmp_party2 = new RawInputRowData[] { party0, party1 };
                        foreach (var party2 in Sort1(filteredRows.Where(x => !tmp_party2.Contains(x)), tmp_party2).Take(max_per_level))
                        {
                            traceout(party2, tmp_party2);
                            var tmp_party3 = new RawInputRowData[] { party0, party1, party2 };
                            foreach (var party3 in Sort1(filteredRows.Where(x => !tmp_party3.Contains(x)), tmp_party3).Take(max_per_level))
                            {
                                traceout(party3, tmp_party3);
                                var tmp_party4 = new RawInputRowData[] { party0, party1, party2, party3 };
                                foreach (var party4 in Sort1(filteredRows.Where(x => !tmp_party4.Contains(x)), tmp_party4).Take(max_per_level))
                                {
                                    traceout(party4, tmp_party4);
                                    var tmp_party5 = new RawInputRowData[] { party0, party1, party2, party3, party4 };
                                    foreach (var party5 in Sort1(filteredRows.Where(x => !tmp_party5.Contains(x)), tmp_party5).Take(max_per_level))
                                    {
                                        traceout(party5, tmp_party5);
                                        yield return new Tuple<RawInputRowData, RawInputRowData[]>(party5, tmp_party5);
                                    }
                                }
                            }
                        }
                    }
                }
            }


            dataGridViewOutput.Rows.Clear();
            foreach (DataGridViewColumn? column in dataGridViewOutput.Columns)
            {
                if (column != null)
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewOutput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach ((RawInputRowData first, RawInputRowData[] rest) in Dedupe(Loop()))
            {
                traceoutfinalgroupstats(first,rest);
            }

            foreach (DataGridViewColumn? column in dataGridViewOutput.Columns)
            {
                if (column != null)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridViewOutput.AutoResizeColumns();




            //Trace.WriteLine("FiltereRows.Count = " + filteredRows.Count);

            //first_column[] first_Columns = getfirst_columns(filteredRows).Distinct(new first_columnComparer()).ToArray();
            //combination[] combinations = getcombinations(filteredRows).Distinct(new combinationComparer()).ToArray();

            //saveoutputtofile(GetCombined_Outputs(first_Columns, combinations));

            //long approx_max_rows = filteredRows.Count * combinations.GetLength(0);
            //long current_row = 0;
            //const int partySize = 6;
            //foreach (first_column first in first_Columns)
            //    foreach (combination combination in combinations)
            //    {
            //        var tmpRow = new combined_output(first, combination);
            //        if (!tmpRow.Valid) continue;
            //        { // add row
            //            int currentRowIndex = dataGridViewOutput.Rows.Add();
            //            foreach (var data in tmpRow.Raw.Select((x, coli) => new { Name = x.Name, Index = coli }))
            //            {
            //                dataGridViewOutput.Rows[currentRowIndex].Cells[data.Index].Value = data.Name;
            //            }
            //            void AppendNumber(int currenti, int value) => dataGridViewOutput.Rows[currentRowIndex].Cells[partySize + currenti - 1].Value = value.ToString();
            //            void AppendNumberf(int currenti, float value) => dataGridViewOutput.Rows[currentRowIndex].Cells[partySize + currenti - 1].Value = value.ToString("F3", CultureInfo.InvariantCulture);
            //            AppendNumber(ColPos.Perception, tmpRow.Perception);
            //            AppendNumber(ColPos.Charisma, tmpRow.Charisma);
            //            AppendNumber(ColPos.Luck, tmpRow.Luck);
            //            AppendNumberf(ColPos.Variance, tmpRow.Variance);
            //            AppendNumber(ColPos.Level, tmpRow.Level);
            //        }
            //        if (current_row % 1000 == 0)
            //        {
            //            label4.Text = "Rows Output: " + (((double)(current_row) / (double)approx_max_rows) * 100).ToString("00.000") + "%";
            //            Trace.WriteLine(current_row);
            //            Application.DoEvents();
            //        }
            //        ++current_row;
            //    }
            //label4.Text = "";


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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
