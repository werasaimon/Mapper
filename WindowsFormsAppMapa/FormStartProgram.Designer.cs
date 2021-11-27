namespace WindowsFormsAppMapa
{
    partial class FormStartProgram
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMapper = new System.Windows.Forms.Button();
            this.buttonAddUsers = new System.Windows.Forms.Button();
            this.buttonAddPollutionTypes = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonMapper);
            this.flowLayoutPanel1.Controls.Add(this.buttonAddUsers);
            this.flowLayoutPanel1.Controls.Add(this.buttonAddPollutionTypes);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(389, 363);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonMapper
            // 
            this.buttonMapper.Location = new System.Drawing.Point(3, 3);
            this.buttonMapper.Name = "buttonMapper";
            this.buttonMapper.Size = new System.Drawing.Size(379, 110);
            this.buttonMapper.TabIndex = 0;
            this.buttonMapper.Text = "Mapper";
            this.buttonMapper.UseVisualStyleBackColor = true;
            this.buttonMapper.Click += new System.EventHandler(this.buttonMapper_Click);
            // 
            // buttonAddUsers
            // 
            this.buttonAddUsers.Location = new System.Drawing.Point(3, 119);
            this.buttonAddUsers.Name = "buttonAddUsers";
            this.buttonAddUsers.Size = new System.Drawing.Size(379, 102);
            this.buttonAddUsers.TabIndex = 1;
            this.buttonAddUsers.Text = "Add Users";
            this.buttonAddUsers.UseVisualStyleBackColor = true;
            this.buttonAddUsers.Click += new System.EventHandler(this.buttonAddUsers_Click);
            // 
            // buttonAddPollutionTypes
            // 
            this.buttonAddPollutionTypes.Location = new System.Drawing.Point(3, 227);
            this.buttonAddPollutionTypes.Name = "buttonAddPollutionTypes";
            this.buttonAddPollutionTypes.Size = new System.Drawing.Size(379, 129);
            this.buttonAddPollutionTypes.TabIndex = 2;
            this.buttonAddPollutionTypes.Text = "Pollution Typess";
            this.buttonAddPollutionTypes.UseVisualStyleBackColor = true;
            this.buttonAddPollutionTypes.Click += new System.EventHandler(this.buttonAddPollutionTypes_Click);
            // 
            // FormStartProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 363);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormStartProgram";
            this.Text = "FormStartProgram";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonMapper;
        private System.Windows.Forms.Button buttonAddUsers;
        private System.Windows.Forms.Button buttonAddPollutionTypes;
    }
}