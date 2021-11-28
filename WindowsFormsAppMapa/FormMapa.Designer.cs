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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxElements = new System.Windows.Forms.ListBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.customCheckedListBoxGround = new WindowsFormsAppMapa.CustomCheckedListBox();
            this.customCheckedListBoxAir = new WindowsFormsAppMapa.CustomCheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInfoOutput = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.gMapa.Size = new System.Drawing.Size(730, 513);
            this.gMapa.TabIndex = 0;
            this.gMapa.Zoom = 0D;
            this.gMapa.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapa_OnMarkerClick);
            this.gMapa.OnMarkerDoubleClick += new GMap.NET.WindowsForms.MarkerDoubleClick(this.gMapa_OnMarkerDoubleClick);
            this.gMapa.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapa_OnPolygonClick);
            this.gMapa.OnPolygonDoubleClick += new GMap.NET.WindowsForms.PolygonDoubleClick(this.gMapa_OnPolygonDoubleClick);
            this.gMapa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapa_MouseDown);
            this.gMapa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapa_MouseMove);
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
            // listBoxElements
            // 
            this.listBoxElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxElements.FormattingEnabled = true;
            this.listBoxElements.ItemHeight = 25;
            this.listBoxElements.Location = new System.Drawing.Point(0, 0);
            this.listBoxElements.Name = "listBoxElements";
            this.listBoxElements.Size = new System.Drawing.Size(171, 255);
            this.listBoxElements.TabIndex = 0;
            this.listBoxElements.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxElements_DrawItem);
            this.listBoxElements.SelectedIndexChanged += new System.EventHandler(this.listBoxElements_SelectedIndexChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(0, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(59, 25);
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
            this.splitContainer1.Size = new System.Drawing.Size(171, 513);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1034, 513);
            this.splitContainer2.SplitterDistance = 859;
            this.splitContainer2.TabIndex = 12;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gMapa);
            this.splitContainer3.Size = new System.Drawing.Size(859, 513);
            this.splitContainer3.SplitterDistance = 125;
            this.splitContainer3.TabIndex = 2;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.customCheckedListBoxGround);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.customCheckedListBoxAir);
            this.splitContainer5.Size = new System.Drawing.Size(125, 513);
            this.splitContainer5.SplitterDistance = 179;
            this.splitContainer5.TabIndex = 16;
            // 
            // customCheckedListBoxGround
            // 
            this.customCheckedListBoxGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customCheckedListBoxGround.DrawFocusedIndicator = false;
            this.customCheckedListBoxGround.FormattingEnabled = true;
            this.customCheckedListBoxGround.Location = new System.Drawing.Point(0, 0);
            this.customCheckedListBoxGround.Name = "customCheckedListBoxGround";
            this.customCheckedListBoxGround.Size = new System.Drawing.Size(125, 179);
            this.customCheckedListBoxGround.TabIndex = 1;
            this.customCheckedListBoxGround.GetBackColor += new WindowsFormsAppMapa.CustomCheckedListBox.GetColorDelegate(this.customCheckedListBoxGround_GetBackColor);
            this.customCheckedListBoxGround.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.customCheckedListBoxGround_ItemCheck);
            // 
            // customCheckedListBoxAir
            // 
            this.customCheckedListBoxAir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customCheckedListBoxAir.DrawFocusedIndicator = false;
            this.customCheckedListBoxAir.FormattingEnabled = true;
            this.customCheckedListBoxAir.Location = new System.Drawing.Point(0, 0);
            this.customCheckedListBoxAir.Name = "customCheckedListBoxAir";
            this.customCheckedListBoxAir.Size = new System.Drawing.Size(125, 330);
            this.customCheckedListBoxAir.TabIndex = 15;
            this.customCheckedListBoxAir.GetBackColor += new WindowsFormsAppMapa.CustomCheckedListBox.GetColorDelegate(this.customCheckedListBoxAir_GetBackColor);
            this.customCheckedListBoxAir.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.customCheckedListBoxAir_ItemCheck);
            this.customCheckedListBoxAir.SelectedIndexChanged += new System.EventHandler(this.customCheckedListBoxAir_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelInfoOutput);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 67);
            this.panel1.TabIndex = 13;
            // 
            // labelInfoOutput
            // 
            this.labelInfoOutput.AutoSize = true;
            this.labelInfoOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfoOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfoOutput.Location = new System.Drawing.Point(0, 47);
            this.labelInfoOutput.Name = "labelInfoOutput";
            this.labelInfoOutput.Size = new System.Drawing.Size(59, 20);
            this.labelInfoOutput.TabIndex = 1;
            this.labelInfoOutput.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolStripComboBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripSeparator1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groundToolStripMenuItem,
            this.airToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // groundToolStripMenuItem
            // 
            this.groundToolStripMenuItem.Name = "groundToolStripMenuItem";
            this.groundToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.groundToolStripMenuItem.Text = "Ground";
            this.groundToolStripMenuItem.Click += new System.EventHandler(this.groundToolStripMenuItem_Click_1);
            // 
            // airToolStripMenuItem
            // 
            this.airToolStripMenuItem.Name = "airToolStripMenuItem";
            this.airToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.airToolStripMenuItem.Text = "Air";
            this.airToolStripMenuItem.Click += new System.EventHandler(this.airToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "All ",
            "Air",
            "Ground"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer4.Size = new System.Drawing.Size(1034, 584);
            this.splitContainer4.SplitterDistance = 67;
            this.splitContainer4.TabIndex = 14;
            // 
            // FormMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 584);
            this.Controls.Add(this.splitContainer4);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMapa";
            this.Text = "FormMapa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMapa_FormClosing);
            this.Load += new System.EventHandler(this.FormMapa_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapa;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem ModifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private CustomCheckedListBox customCheckedListBoxGround;
        private CustomCheckedListBox customCheckedListBoxAir;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ListBox listBoxElements;
        private System.Windows.Forms.Label labelInfoOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}