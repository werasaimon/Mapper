namespace WindowsFormsAppMapa
{
    partial class FormForVariables
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxNmae = new System.Windows.Forms.TextBox();
            this.trackBarDepth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(186, 365);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(192, 36);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 365);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(168, 36);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(186, 9);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(201, 35);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxType_DrawItem);
            this.comboBoxType.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.comboBoxType_MeasureItem);
            // 
            // textBoxNmae
            // 
            this.textBoxNmae.AccessibleName = "";
            this.textBoxNmae.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNmae.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxNmae.Location = new System.Drawing.Point(12, 50);
            this.textBoxNmae.Name = "textBoxNmae";
            this.textBoxNmae.Size = new System.Drawing.Size(375, 32);
            this.textBoxNmae.TabIndex = 3;
            this.textBoxNmae.Text = "Name Marker";
            this.textBoxNmae.Enter += new System.EventHandler(this.textBoxNmae_Enter);
            this.textBoxNmae.Leave += new System.EventHandler(this.textBoxNmae_Leave);
            // 
            // trackBarDepth
            // 
            this.trackBarDepth.Location = new System.Drawing.Point(12, 88);
            this.trackBarDepth.Maximum = 255;
            this.trackBarDepth.Minimum = 50;
            this.trackBarDepth.Name = "trackBarDepth";
            this.trackBarDepth.Size = new System.Drawing.Size(310, 56);
            this.trackBarDepth.TabIndex = 4;
            this.trackBarDepth.Value = 55;
            this.trackBarDepth.Scroll += new System.EventHandler(this.trackBarDepth_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Depth = 55";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 38);
            this.label2.TabIndex = 6;
            this.label2.Text = "GROUP";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 123);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(366, 236);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // FormForVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 401);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarDepth);
            this.Controls.Add(this.textBoxNmae);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "FormForVariables";
            this.Text = "FormForVariabless";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxNmae;
        private System.Windows.Forms.TrackBar trackBarDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}