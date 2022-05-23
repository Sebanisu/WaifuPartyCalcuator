namespace WaifuPartyCalcuator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Charisma");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Perception");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Luck");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Variance");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Level");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharisma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLuck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textMax = new System.Windows.Forms.TextBox();
            this.checkDistinct = new System.Windows.Forms.CheckBox();
            this.radio101010 = new System.Windows.Forms.RadioButton();
            this.radio999 = new System.Windows.Forms.RadioButton();
            this.radio888 = new System.Windows.Forms.RadioButton();
            this.radio777 = new System.Windows.Forms.RadioButton();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.colOutName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutName3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutName4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutName5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutName6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPerception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutCharisma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutLuck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutVariance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textSourceCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textRegex = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonImport = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Waifus";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPerception,
            this.colCharisma,
            this.colLuck,
            this.colVariance,
            this.colLevel});
            this.dataGridViewInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInput.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowTemplate.Height = 25;
            this.dataGridViewInput.Size = new System.Drawing.Size(786, 392);
            this.dataGridViewInput.TabIndex = 0;
            this.dataGridViewInput.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colPerception
            // 
            this.colPerception.HeaderText = "Perception";
            this.colPerception.Name = "colPerception";
            // 
            // colCharisma
            // 
            this.colCharisma.HeaderText = "Charisma";
            this.colCharisma.Name = "colCharisma";
            // 
            // colLuck
            // 
            this.colLuck.HeaderText = "Luck";
            this.colLuck.Name = "colLuck";
            // 
            // colVariance
            // 
            this.colVariance.HeaderText = "Variance";
            this.colVariance.Name = "colVariance";
            this.colVariance.ReadOnly = true;
            // 
            // colLevel
            // 
            this.colLevel.HeaderText = "Level";
            this.colLevel.Name = "colLevel";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Party Generator";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewOutput);
            this.splitContainer1.Size = new System.Drawing.Size(786, 392);
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGenerate, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.32653F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.67347F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(149, 392);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textMax);
            this.groupBox1.Controls.Add(this.checkDistinct);
            this.groupBox1.Controls.Add(this.radio101010);
            this.groupBox1.Controls.Add(this.radio999);
            this.groupBox1.Controls.Add(this.radio888);
            this.groupBox1.Controls.Add(this.radio777);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 352);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Goals";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 17;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(64, 142);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(67, 104);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Target:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Order By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Max";
            // 
            // textMax
            // 
            this.textMax.Location = new System.Drawing.Point(42, 316);
            this.textMax.Name = "textMax";
            this.textMax.Size = new System.Drawing.Size(52, 23);
            this.textMax.TabIndex = 12;
            this.textMax.Text = "100";
            // 
            // checkDistinct
            // 
            this.checkDistinct.AutoSize = true;
            this.checkDistinct.Location = new System.Drawing.Point(3, 252);
            this.checkDistinct.Name = "checkDistinct";
            this.checkDistinct.Size = new System.Drawing.Size(143, 19);
            this.checkDistinct.TabIndex = 11;
            this.checkDistinct.Text = "Distinct (P, C, L, Level)";
            this.checkDistinct.UseVisualStyleBackColor = true;
            // 
            // radio101010
            // 
            this.radio101010.AutoSize = true;
            this.radio101010.Location = new System.Drawing.Point(64, 95);
            this.radio101010.Name = "radio101010";
            this.radio101010.Size = new System.Drawing.Size(37, 19);
            this.radio101010.TabIndex = 3;
            this.radio101010.Text = "10";
            this.radio101010.UseVisualStyleBackColor = true;
            // 
            // radio999
            // 
            this.radio999.AutoSize = true;
            this.radio999.Location = new System.Drawing.Point(64, 70);
            this.radio999.Name = "radio999";
            this.radio999.Size = new System.Drawing.Size(31, 19);
            this.radio999.TabIndex = 2;
            this.radio999.Text = "9";
            this.radio999.UseVisualStyleBackColor = true;
            // 
            // radio888
            // 
            this.radio888.AutoSize = true;
            this.radio888.Location = new System.Drawing.Point(64, 45);
            this.radio888.Name = "radio888";
            this.radio888.Size = new System.Drawing.Size(31, 19);
            this.radio888.TabIndex = 1;
            this.radio888.Text = "8";
            this.radio888.UseVisualStyleBackColor = true;
            // 
            // radio777
            // 
            this.radio777.AutoSize = true;
            this.radio777.Checked = true;
            this.radio777.Location = new System.Drawing.Point(64, 20);
            this.radio777.Name = "radio777";
            this.radio777.Size = new System.Drawing.Size(31, 19);
            this.radio777.TabIndex = 0;
            this.radio777.TabStop = true;
            this.radio777.Text = "7";
            this.radio777.UseVisualStyleBackColor = true;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerate.Location = new System.Drawing.Point(3, 361);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(143, 28);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AllowUserToAddRows = false;
            this.dataGridViewOutput.AllowUserToDeleteRows = false;
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOutName1,
            this.colOutName2,
            this.colOutName3,
            this.colOutName4,
            this.colOutName5,
            this.colOutName6,
            this.colOutPerception,
            this.colOutCharisma,
            this.colOutLuck,
            this.colOutVariance,
            this.colOutLevel});
            this.dataGridViewOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOutput.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.ReadOnly = true;
            this.dataGridViewOutput.RowTemplate.Height = 25;
            this.dataGridViewOutput.Size = new System.Drawing.Size(633, 392);
            this.dataGridViewOutput.TabIndex = 0;
            // 
            // colOutName1
            // 
            this.colOutName1.HeaderText = "Name 1";
            this.colOutName1.Name = "colOutName1";
            this.colOutName1.ReadOnly = true;
            // 
            // colOutName2
            // 
            this.colOutName2.HeaderText = "Name 2";
            this.colOutName2.Name = "colOutName2";
            this.colOutName2.ReadOnly = true;
            // 
            // colOutName3
            // 
            this.colOutName3.HeaderText = "Name 3";
            this.colOutName3.Name = "colOutName3";
            this.colOutName3.ReadOnly = true;
            // 
            // colOutName4
            // 
            this.colOutName4.HeaderText = "Name 4";
            this.colOutName4.Name = "colOutName4";
            this.colOutName4.ReadOnly = true;
            // 
            // colOutName5
            // 
            this.colOutName5.HeaderText = "Name 5";
            this.colOutName5.Name = "colOutName5";
            this.colOutName5.ReadOnly = true;
            // 
            // colOutName6
            // 
            this.colOutName6.HeaderText = "Name 6";
            this.colOutName6.Name = "colOutName6";
            this.colOutName6.ReadOnly = true;
            // 
            // colOutPerception
            // 
            this.colOutPerception.HeaderText = "Perception";
            this.colOutPerception.Name = "colOutPerception";
            this.colOutPerception.ReadOnly = true;
            // 
            // colOutCharisma
            // 
            this.colOutCharisma.HeaderText = "Charisma";
            this.colOutCharisma.Name = "colOutCharisma";
            this.colOutCharisma.ReadOnly = true;
            // 
            // colOutLuck
            // 
            this.colOutLuck.HeaderText = "Luck";
            this.colOutLuck.Name = "colOutLuck";
            this.colOutLuck.ReadOnly = true;
            // 
            // colOutVariance
            // 
            this.colOutVariance.HeaderText = "Variance";
            this.colOutVariance.Name = "colOutVariance";
            this.colOutVariance.ReadOnly = true;
            // 
            // colOutLevel
            // 
            this.colOutLevel.HeaderText = "Level";
            this.colOutLevel.Name = "colOutLevel";
            this.colOutLevel.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 398);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parse Waifu Hotel Source";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textSourceCode);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(786, 392);
            this.splitContainer2.SplitterDistance = 262;
            this.splitContainer2.TabIndex = 0;
            // 
            // textSourceCode
            // 
            this.textSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSourceCode.Location = new System.Drawing.Point(0, 0);
            this.textSourceCode.MaxLength = 0;
            this.textSourceCode.Multiline = true;
            this.textSourceCode.Name = "textSourceCode";
            this.textSourceCode.Size = new System.Drawing.Size(786, 262);
            this.textSourceCode.TabIndex = 0;
            this.textSourceCode.TextChanged += new System.EventHandler(this.textSourceCode_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.93639F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06361F));
            this.tableLayoutPanel2.Controls.Add(this.textRegex, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 126);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textRegex
            // 
            this.textRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRegex.Location = new System.Drawing.Point(3, 3);
            this.textRegex.MaxLength = 0;
            this.textRegex.Multiline = true;
            this.textRegex.Name = "textRegex";
            this.textRegex.Size = new System.Drawing.Size(583, 120);
            this.textRegex.TabIndex = 1;
            this.textRegex.Text = resources.GetString("textRegex.Text");
            this.textRegex.TextChanged += new System.EventHandler(this.textRegex_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.buttonImport, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelCount, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(592, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.16666F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(191, 120);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonImport
            // 
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImport.Location = new System.Drawing.Point(3, 3);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(185, 89);
            this.buttonImport.TabIndex = 0;
            this.buttonImport.Text = "Import Waifus";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCount.Location = new System.Drawing.Point(3, 95);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(185, 25);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveToolStripMenuItem.Text = "Save Waifus";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.loadToolStripMenuItem.Text = "Reload Waifus";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "WaifuGame Party Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio101010;
        private System.Windows.Forms.RadioButton radio999;
        private System.Windows.Forms.RadioButton radio888;
        private System.Windows.Forms.RadioButton radio777;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.CheckBox checkDistinct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textSourceCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TextBox textRegex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerception;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharisma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLuck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutName3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutName4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutName5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutName6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPerception;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutCharisma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutLuck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutVariance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutLevel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label4;
    }
}
