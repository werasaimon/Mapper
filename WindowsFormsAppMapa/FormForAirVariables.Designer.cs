namespace WindowsFormsAppMapa
{
    partial class FormForAirVariables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxNmae = new System.Windows.Forms.TextBox();
            this.trackBarDepth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.customCheckedListBox1 = new Qodex.CustomCheckedListBox();
            this.cboFace = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(449, 292);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(3, 113);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(106, 36);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(3, 3);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(446, 35);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxType_DrawItem);
            this.comboBoxType.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.comboBoxType_MeasureItem);
            // 
            // textBoxNmae
            // 
            this.textBoxNmae.AccessibleName = "";
            this.textBoxNmae.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNmae.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNmae.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxNmae.Location = new System.Drawing.Point(3, 40);
            this.textBoxNmae.Name = "textBoxNmae";
            this.textBoxNmae.Size = new System.Drawing.Size(446, 32);
            this.textBoxNmae.TabIndex = 3;
            this.textBoxNmae.Text = "Name Marker";
            this.textBoxNmae.Enter += new System.EventHandler(this.textBoxNmae_Enter);
            this.textBoxNmae.Leave += new System.EventHandler(this.textBoxNmae_Leave);
            // 
            // trackBarDepth
            // 
            this.trackBarDepth.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarDepth.Location = new System.Drawing.Point(3, 51);
            this.trackBarDepth.Maximum = 255;
            this.trackBarDepth.Minimum = 50;
            this.trackBarDepth.Name = "trackBarDepth";
            this.trackBarDepth.Size = new System.Drawing.Size(446, 56);
            this.trackBarDepth.TabIndex = 4;
            this.trackBarDepth.Value = 55;
            this.trackBarDepth.Scroll += new System.EventHandler(this.trackBarDepth_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Depth = 55";
            // 
            // OK
            // 
            this.OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK.Location = new System.Drawing.Point(115, 113);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(103, 36);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNmae, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 74);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customCheckedListBox1);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(449, 390);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cboFace);
            this.flowLayoutPanel1.Controls.Add(this.trackBarDepth);
            this.flowLayoutPanel1.Controls.Add(this.Cancel);
            this.flowLayoutPanel1.Controls.Add(this.OK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 136);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(449, 530);
            this.splitContainer2.SplitterDistance = 390;
            this.splitContainer2.TabIndex = 13;
            // 
            // customCheckedListBox1
            // 
            this.customCheckedListBox1.DrawFocusedIndicator = false;
            this.customCheckedListBox1.FormattingEnabled = true;
            this.customCheckedListBox1.Location = new System.Drawing.Point(394, 166);
            this.customCheckedListBox1.Name = "customCheckedListBox1";
            this.customCheckedListBox1.Size = new System.Drawing.Size(8, 4);
            this.customCheckedListBox1.TabIndex = 9;
            // 
            // cboFace
            // 
            this.cboFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFace.Font = new System.Drawing.Font("Arial", 16F);
            this.cboFace.FormattingEnabled = true;
            this.cboFace.Items.AddRange(new object[] {
            "vhvh",
            "hgvgv",
            "g"});
            this.cboFace.Location = new System.Drawing.Point(4, 4);
            this.cboFace.Margin = new System.Windows.Forms.Padding(4);
            this.cboFace.Name = "cboFace";
            this.cboFace.Size = new System.Drawing.Size(160, 40);
            this.cboFace.TabIndex = 10;
            // 
            // FormForAirVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 530);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FormForAirVariables";
            this.Text = "FormForAirVariables";
            this.Load += new System.EventHandler(this.FormForAirVariables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxNmae;
        private System.Windows.Forms.TrackBar trackBarDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Qodex.CustomCheckedListBox customCheckedListBox1;
        private System.Windows.Forms.ComboBox cboFace;
    }
}