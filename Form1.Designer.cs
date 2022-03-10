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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharisma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLuck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textMax = new System.Windows.Forms.TextBox();
            this.checkDistinct = new System.Windows.Forms.CheckBox();
            this.checkVariance = new System.Windows.Forms.CheckBox();
            this.radioLCP = new System.Windows.Forms.RadioButton();
            this.radioLPC = new System.Windows.Forms.RadioButton();
            this.radioCLP = new System.Windows.Forms.RadioButton();
            this.radioCPL = new System.Windows.Forms.RadioButton();
            this.radioPLC = new System.Windows.Forms.RadioButton();
            this.radioPCL = new System.Windows.Forms.RadioButton();
            this.radio101010 = new System.Windows.Forms.RadioButton();
            this.radio999 = new System.Windows.Forms.RadioButton();
            this.radio888 = new System.Windows.Forms.RadioButton();
            this.radio777 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Waifus";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPerception,
            this.colCharisma,
            this.colLuck,
            this.colVariance});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(786, 392);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(786, 392);
            this.splitContainer1.SplitterDistance = 146;
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
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.32653F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.67347F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(146, 392);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textMax);
            this.groupBox1.Controls.Add(this.checkDistinct);
            this.groupBox1.Controls.Add(this.checkVariance);
            this.groupBox1.Controls.Add(this.radioLCP);
            this.groupBox1.Controls.Add(this.radioLPC);
            this.groupBox1.Controls.Add(this.radioCLP);
            this.groupBox1.Controls.Add(this.radioCPL);
            this.groupBox1.Controls.Add(this.radioPLC);
            this.groupBox1.Controls.Add(this.radioPCL);
            this.groupBox1.Controls.Add(this.radio101010);
            this.groupBox1.Controls.Add(this.radio999);
            this.groupBox1.Controls.Add(this.radio888);
            this.groupBox1.Controls.Add(this.radio777);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 352);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Goals";
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
            this.checkDistinct.Location = new System.Drawing.Point(6, 292);
            this.checkDistinct.Name = "checkDistinct";
            this.checkDistinct.Size = new System.Drawing.Size(110, 19);
            this.checkDistinct.TabIndex = 11;
            this.checkDistinct.Text = "Distinct (P, C, L)";
            this.checkDistinct.UseVisualStyleBackColor = true;
            // 
            // checkVariance
            // 
            this.checkVariance.AutoSize = true;
            this.checkVariance.Location = new System.Drawing.Point(6, 267);
            this.checkVariance.Name = "checkVariance";
            this.checkVariance.Size = new System.Drawing.Size(95, 19);
            this.checkVariance.TabIndex = 10;
            this.checkVariance.Text = "Low Variance";
            this.checkVariance.UseVisualStyleBackColor = true;
            // 
            // radioLCP
            // 
            this.radioLCP.AutoSize = true;
            this.radioLCP.Location = new System.Drawing.Point(64, 242);
            this.radioLCP.Name = "radioLCP";
            this.radioLCP.Size = new System.Drawing.Size(52, 19);
            this.radioLCP.TabIndex = 9;
            this.radioLCP.TabStop = true;
            this.radioLCP.Text = "L,C,P";
            this.radioLCP.UseVisualStyleBackColor = true;
            // 
            // radioLPC
            // 
            this.radioLPC.AutoSize = true;
            this.radioLPC.Location = new System.Drawing.Point(64, 217);
            this.radioLPC.Name = "radioLPC";
            this.radioLPC.Size = new System.Drawing.Size(52, 19);
            this.radioLPC.TabIndex = 8;
            this.radioLPC.TabStop = true;
            this.radioLPC.Text = "L,P,C";
            this.radioLPC.UseVisualStyleBackColor = true;
            // 
            // radioCLP
            // 
            this.radioCLP.AutoSize = true;
            this.radioCLP.Location = new System.Drawing.Point(64, 192);
            this.radioCLP.Name = "radioCLP";
            this.radioCLP.Size = new System.Drawing.Size(52, 19);
            this.radioCLP.TabIndex = 7;
            this.radioCLP.TabStop = true;
            this.radioCLP.Text = "C,L,P";
            this.radioCLP.UseVisualStyleBackColor = true;
            // 
            // radioCPL
            // 
            this.radioCPL.AutoSize = true;
            this.radioCPL.Location = new System.Drawing.Point(64, 167);
            this.radioCPL.Name = "radioCPL";
            this.radioCPL.Size = new System.Drawing.Size(52, 19);
            this.radioCPL.TabIndex = 6;
            this.radioCPL.Text = "C,P,L";
            this.radioCPL.UseVisualStyleBackColor = true;
            // 
            // radioPLC
            // 
            this.radioPLC.AutoSize = true;
            this.radioPLC.Location = new System.Drawing.Point(64, 142);
            this.radioPLC.Name = "radioPLC";
            this.radioPLC.Size = new System.Drawing.Size(52, 19);
            this.radioPLC.TabIndex = 5;
            this.radioPLC.Text = "P,L,C";
            this.radioPLC.UseVisualStyleBackColor = true;
            // 
            // radioPCL
            // 
            this.radioPCL.AutoSize = true;
            this.radioPCL.Location = new System.Drawing.Point(64, 117);
            this.radioPCL.Name = "radioPCL";
            this.radioPCL.Size = new System.Drawing.Size(52, 19);
            this.radioPCL.TabIndex = 4;
            this.radioPCL.Text = "P,C,L";
            this.radioPCL.UseVisualStyleBackColor = true;
            // 
            // radio101010
            // 
            this.radio101010.AutoSize = true;
            this.radio101010.Location = new System.Drawing.Point(64, 95);
            this.radio101010.Name = "radio101010";
            this.radio101010.Size = new System.Drawing.Size(67, 19);
            this.radio101010.TabIndex = 3;
            this.radio101010.Text = "10,10,10";
            this.radio101010.UseVisualStyleBackColor = true;
            // 
            // radio999
            // 
            this.radio999.AutoSize = true;
            this.radio999.Location = new System.Drawing.Point(64, 70);
            this.radio999.Name = "radio999";
            this.radio999.Size = new System.Drawing.Size(49, 19);
            this.radio999.TabIndex = 2;
            this.radio999.Text = "9,9,9";
            this.radio999.UseVisualStyleBackColor = true;
            // 
            // radio888
            // 
            this.radio888.AutoSize = true;
            this.radio888.Location = new System.Drawing.Point(64, 45);
            this.radio888.Name = "radio888";
            this.radio888.Size = new System.Drawing.Size(49, 19);
            this.radio888.TabIndex = 1;
            this.radio888.Text = "8,8,8";
            this.radio888.UseVisualStyleBackColor = true;
            // 
            // radio777
            // 
            this.radio777.AutoSize = true;
            this.radio777.Checked = true;
            this.radio777.Location = new System.Drawing.Point(64, 20);
            this.radio777.Name = "radio777";
            this.radio777.Size = new System.Drawing.Size(49, 19);
            this.radio777.TabIndex = 0;
            this.radio777.TabStop = true;
            this.radio777.Text = "7,7,7";
            this.radio777.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(636, 392);
            this.dataGridView2.TabIndex = 0;
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save Waifus";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Reload Waifus";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Order By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filter By:";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name 1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name 2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Name 3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Name 4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Name 5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Name 6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Perception";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Charisma";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Luck";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Variance";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioCPL;
        private System.Windows.Forms.RadioButton radioPLC;
        private System.Windows.Forms.RadioButton radioPCL;
        private System.Windows.Forms.RadioButton radio101010;
        private System.Windows.Forms.RadioButton radio999;
        private System.Windows.Forms.RadioButton radio888;
        private System.Windows.Forms.RadioButton radio777;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.RadioButton radioLCP;
        private System.Windows.Forms.RadioButton radioLPC;
        private System.Windows.Forms.RadioButton radioCLP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerception;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharisma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLuck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariance;
        private System.Windows.Forms.CheckBox checkVariance;
        private System.Windows.Forms.CheckBox checkDistinct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}
