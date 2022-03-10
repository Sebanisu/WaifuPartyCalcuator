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
        struct tmpRowData
        {
            public string[] Names;
            public int P, C, L;

            public float Variance;
        }

        IEnumerable<tmpRowData> GetRowData(IEnumerable<IEnumerable<int>> rPartyRowIndex)
        {

            const int partySize = 6;
            foreach (var rowOfIndexes in rPartyRowIndex)
            {
                if (rowOfIndexes.Any(i => (dataGridView1.Rows[i].Cells[0].Value?.ToString() ?? "").Trim().Length == 0))
                {
                    continue;
                }
                tmpRowData tmpRow = new tmpRowData
                {
                    Names = new string[partySize]
                };
                foreach (var data in rowOfIndexes.Select((rowi, coli) => new { Row = dataGridView1.Rows[rowi], CellIndex = coli }))
                {
                    tmpRow.Names[data.CellIndex] = data.Row.Cells[0].Value?.ToString() ?? "";
                }
                Func<int, int, int> GetCellValue = (currenti, rowi) => { int.TryParse(dataGridView1.Rows[rowi].Cells[currenti].Value?.ToString() ?? "0", out int outi); if (outi > 0) return outi; return 0; };
                Func<int, int, double> GetCombinedValue = (currenti, rowi) => rowOfIndexes.Select(rowi => GetCellValue(currenti, rowi)).Average() / 2.0;
                Func<int, int, double> GetFirstValue = (currenti, rowi) => rowOfIndexes.Select(rowi => GetCellValue(currenti, rowi)).First() / 2.0;
                Func<int, int> GetProcessedValue = (currenti) => (int)Math.Round(rowOfIndexes.Select(rowi => GetFirstValue(currenti, rowi) + GetCombinedValue(currenti, rowi)).First(), 0);
                tmpRow.P = GetProcessedValue(1);
                tmpRow.C = GetProcessedValue(2);
                tmpRow.L = GetProcessedValue(3);
                Func<RadioButton, int, bool> checkNotMatchNumber = (radio, i) => radio.Checked && (tmpRow.P != i || tmpRow.C != i || tmpRow.L != i);
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
            if(checkDistinct.Checked)
                return tmpRows.GroupBy(x=> new { x.P, x.C, x.L } ).Select(x => x.FirstOrDefault());
            return tmpRows.Select(x => x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int partySize = 6;
            int columnCount = dataGridView1.Columns.Count;
            int rowCount = dataGridView1.Rows.Count;
            if (columnCount <= 0 || rowCount <= 0) return;
            var rRows = Enumerable.Range(0, rowCount);
            var rPartyRowIndex = GetPermutations(rRows, partySize);
            dataGridView2.Rows.Clear();
            int.TryParse(textMax.Text, out int max);
            if (max <= 1)
                max = 100;
            foreach (var tmpRow in Dedupe(GetSorted(GetRowData(rPartyRowIndex))).Take(max))
            {
                { // add row
                    int currentRowIndex = dataGridView2.Rows.Add();
                    foreach (var data in tmpRow.Names.Select((x, coli) => new { Name = x, Index = coli }))
                    {
                        dataGridView2.Rows[currentRowIndex].Cells[data.Index].Value = data.Name;
                    }
                    Action<int, int> AppendNumber = (currenti, value) => dataGridView2.Rows[currentRowIndex].Cells[partySize + currenti].Value = value.ToString();
                    Action<int, float> AppendNumberf = (currenti, value) => dataGridView2.Rows[currentRowIndex].Cells[partySize + currenti].Value = value.ToString("F3", CultureInfo.InvariantCulture);
                    AppendNumber(0, tmpRow.P);
                    AppendNumber(1, tmpRow.C);
                    AppendNumber(2, tmpRow.L);
                    AppendNumberf(3, tmpRow.Variance);
                }
            }
            dataGridView2.Refresh();
        }
    }
}
