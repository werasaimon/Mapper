namespace WindowsFormsAppMapa
{
    partial class FormMapa
    {
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMapa = new GMap.NET.WindowsForms.GMapControl();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBoxLayer0 = new System.Windows.Forms.CheckBox();
            this.checkBoxLayer1 = new System.Windows.Forms.CheckBox();
            this.checkBoxLayer2 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonUser = new System.Windows.Forms.Button();
            this.listBoxElements = new System.Windows.Forms.ListBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapa
            // 
            this.gMapa.Bearing = 0F;
            this.gMapa.CanDragMap = true;
            this.gMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapa.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapa.GrayScaleMode = false;
            this.gMapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapa.LevelsKeepInMemory = 5;
            this.gMapa.Location = new System.Drawing.Point(0, 0);
            this.gMapa.MarkersEnabled = true;
            this.gMapa.MaxZoom = 2;
            this.gMapa.MinZoom = 2;
            this.gMapa.MouseWheelZoomEnabled = true;
            this.gMapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapa.Name = "gMapa";
            this.gMapa.NegativeMode = false;
            this.gMapa.PolygonsEnabled = true;
            this.gMapa.RetryLoadTile = 0;
            this.gMapa.RoutesEnabled = true;
            this.gMapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapa.ShowTileGridLines = false;
            this.gMapa.Size = new System.Drawing.Size(713, 396);
            this.gMapa.TabIndex = 0;
            this.gMapa.Zoom = 0D;
            this.gMapa.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapa_OnPolygonClick);
            this.gMapa.OnPolygonDoubleClick += new GMap.NET.WindowsForms.PolygonDoubleClick(this.gMapa_OnPolygonDoubleClick);
            this.gMapa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapa_MouseDown);
            this.gMapa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapa_MouseMove);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(283, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(169, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Create_Polygon";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBoxLayer0
            // 
            this.checkBoxLayer0.AutoSize = true;
            this.checkBoxLayer0.Checked = true;
            this.checkBoxLayer0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLayer0.Location = new System.Drawing.Point(3, 19);
            this.checkBoxLayer0.Name = "checkBoxLayer0";
            this.checkBoxLayer0.Size = new System.Drawing.Size(75, 20);
            this.checkBoxLayer0.TabIndex = 7;
            this.checkBoxLayer0.Text = "Layer A";
            this.checkBoxLayer0.UseVisualStyleBackColor = true;
            this.checkBoxLayer0.CheckedChanged += new System.EventHandler(this.checkBoxLayer0_CheckedChanged);
            // 
            // checkBoxLayer1
            // 
            this.checkBoxLayer1.AutoSize = true;
            this.checkBoxLayer1.Checked = true;
            this.checkBoxLayer1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLayer1.Location = new System.Drawing.Point(96, 19);
            this.checkBoxLayer1.Name = "checkBoxLayer1";
            this.checkBoxLayer1.Size = new System.Drawing.Size(75, 20);
            this.checkBoxLayer1.TabIndex = 8;
            this.checkBoxLayer1.Text = "Layer B";
            this.checkBoxLayer1.UseVisualStyleBackColor = true;
            this.checkBoxLayer1.CheckedChanged += new System.EventHandler(this.checkBoxLayer1_CheckedChanged);
            // 
            // checkBoxLayer2
            // 
            this.checkBoxLayer2.AutoSize = true;
            this.checkBoxLayer2.Checked = true;
            this.checkBoxLayer2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLayer2.Location = new System.Drawing.Point(191, 19);
            this.checkBoxLayer2.Name = "checkBoxLayer2";
            this.checkBoxLayer2.Size = new System.Drawing.Size(75, 20);
            this.checkBoxLayer2.TabIndex = 9;
            this.checkBoxLayer2.Text = "Layer C";
            this.checkBoxLayer2.UseVisualStyleBackColor = true;
            this.checkBoxLayer2.CheckedChanged += new System.EventHandler(this.checkBoxLayer2_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModifyToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 52);
            // 
            // ModifyToolStripMenuItem
            // 
            this.ModifyToolStripMenuItem.Name = "ModifyToolStripMenuItem";
            this.ModifyToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.ModifyToolStripMenuItem.Text = "modify";
            this.ModifyToolStripMenuItem.Click += new System.EventHandler(this.ModifyToolStripMenuItem_Click_1);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.DeleteToolStripMenuItem.Text = "delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonUser);
            this.panel1.Controls.Add(this.checkBoxLayer1);
            this.panel1.Controls.Add(this.checkBoxLayer0);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.checkBoxLayer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 54);
            this.panel1.TabIndex = 10;
            // 
            // buttonUser
            // 
            this.buttonUser.Location = new System.Drawing.Point(458, 19);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(171, 23);
            this.buttonUser.TabIndex = 13;
            this.buttonUser.Text = "User";
            this.buttonUser.UseVisualStyleBackColor = true;
            this.buttonUser.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBoxElements
            // 
            this.listBoxElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxElements.FormattingEnabled = true;
            this.listBoxElements.ItemHeight = 25;
            this.listBoxElements.Location = new System.Drawing.Point(0, 0);
            this.listBoxElements.Name = "listBoxElements";
            this.listBoxElements.Size = new System.Drawing.Size(223, 198);
            this.listBoxElements.TabIndex = 0;
            this.listBoxElements.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxElements_DrawItem);
            this.listBoxElements.SelectedIndexChanged += new System.EventHandler(this.listBoxElements_SelectedIndexChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(0, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(89, 36);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "INFO";
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
            this.splitContainer1.Panel1.Controls.Add(this.listBoxElements);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelInfo);
            this.splitContainer1.Size = new System.Drawing.Size(223, 396);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 54);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gMapa);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(940, 396);
            this.splitContainer2.SplitterDistance = 713;
            this.splitContainer2.TabIndex = 12;
            // 
            // FormMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMapa";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMapa_FormClosing);
            this.Load += new System.EventHandler(this.FormMapa_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapa;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBoxLayer0;
        private System.Windows.Forms.CheckBox checkBoxLayer1;
        private System.Windows.Forms.CheckBox checkBoxLayer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem ModifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxElements;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonUser;
    }
}