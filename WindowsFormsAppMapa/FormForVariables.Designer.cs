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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(186, 250);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(192, 36);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 250);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(168, 36);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBoxType.Location = new System.Drawing.Point(196, 46);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(182, 37);
            this.comboBoxType.TabIndex = 2;
            // 
            // textBoxNmae
            // 
            this.textBoxNmae.AccessibleName = "";
            this.textBoxNmae.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNmae.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxNmae.Location = new System.Drawing.Point(12, 109);
            this.textBoxNmae.Name = "textBoxNmae";
            this.textBoxNmae.Size = new System.Drawing.Size(366, 32);
            this.textBoxNmae.TabIndex = 3;
            this.textBoxNmae.Text = "Name Marker";
            this.textBoxNmae.Enter += new System.EventHandler(this.textBoxNmae_Enter);
            this.textBoxNmae.Leave += new System.EventHandler(this.textBoxNmae_Leave);
            // 
            // trackBarDepth
            // 
            this.trackBarDepth.Location = new System.Drawing.Point(12, 188);
            this.trackBarDepth.Maximum = 150;
            this.trackBarDepth.Minimum = 50;
            this.trackBarDepth.Name = "trackBarDepth";
            this.trackBarDepth.Size = new System.Drawing.Size(366, 56);
            this.trackBarDepth.TabIndex = 4;
            this.trackBarDepth.Value = 55;
            this.trackBarDepth.Scroll += new System.EventHandler(this.trackBarDepth_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Depth = 55";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "GROUP";
            // 
            // FormForVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 298);
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
    }
}