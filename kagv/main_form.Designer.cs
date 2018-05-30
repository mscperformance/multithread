﻿namespace kagv {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.gb_settings = new System.Windows.Forms.GroupBox();
            this.gb_agvs = new System.Windows.Forms.GroupBox();
            this.nUD_AGVs = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_weight = new System.Windows.Forms.NumericUpDown();
            this.rb_wall = new System.Windows.Forms.RadioButton();
            this.rb_start = new System.Windows.Forms.RadioButton();
            this.rb_stop = new System.Windows.Forms.RadioButton();
            this.settings_menu = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heuristicModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manhattanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.euclideanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chebyshevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightOverCurrentBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aGVIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultGridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cd_grid = new System.Windows.Forms.ColorDialog();
            this.sfd_exportmap = new System.Windows.Forms.SaveFileDialog();
            this.ofd_importmap = new System.Windows.Forms.OpenFileDialog();
            this.menuPanel.SuspendLayout();
            this.gb_settings.SuspendLayout();
            this.gb_agvs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_AGVs)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_weight)).BeginInit();
            this.settings_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuPanel.Controls.Add(this.gb_settings);
            this.menuPanel.Location = new System.Drawing.Point(0, 27);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(601, 75);
            this.menuPanel.TabIndex = 7;
            // 
            // gb_settings
            // 
            this.gb_settings.Controls.Add(this.gb_agvs);
            this.gb_settings.Controls.Add(this.groupBox1);
            this.gb_settings.Controls.Add(this.rb_wall);
            this.gb_settings.Controls.Add(this.rb_start);
            this.gb_settings.Controls.Add(this.rb_stop);
            this.gb_settings.Location = new System.Drawing.Point(3, 5);
            this.gb_settings.Name = "gb_settings";
            this.gb_settings.Size = new System.Drawing.Size(264, 65);
            this.gb_settings.TabIndex = 25;
            this.gb_settings.TabStop = false;
            this.gb_settings.Text = "Toolbox";
            // 
            // gb_agvs
            // 
            this.gb_agvs.Controls.Add(this.nUD_AGVs);
            this.gb_agvs.Location = new System.Drawing.Point(115, 16);
            this.gb_agvs.Name = "gb_agvs";
            this.gb_agvs.Size = new System.Drawing.Size(65, 43);
            this.gb_agvs.TabIndex = 18;
            this.gb_agvs.TabStop = false;
            this.gb_agvs.Text = "Objects";
            // 
            // nUD_AGVs
            // 
            this.nUD_AGVs.Location = new System.Drawing.Point(16, 17);
            this.nUD_AGVs.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUD_AGVs.Name = "nUD_AGVs";
            this.nUD_AGVs.Size = new System.Drawing.Size(30, 20);
            this.nUD_AGVs.TabIndex = 10;
            this.nUD_AGVs.ValueChanged += new System.EventHandler(this.nUD_AGVs_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_weight);
            this.groupBox1.Location = new System.Drawing.Point(186, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(69, 43);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "A* Weight";
            // 
            // nud_weight
            // 
            this.nud_weight.DecimalPlaces = 2;
            this.nud_weight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_weight.Location = new System.Drawing.Point(3, 20);
            this.nud_weight.Name = "nud_weight";
            this.nud_weight.Size = new System.Drawing.Size(64, 20);
            this.nud_weight.TabIndex = 28;
            this.nud_weight.ValueChanged += new System.EventHandler(this.nud_weight_ValueChanged);
            // 
            // rb_wall
            // 
            this.rb_wall.AutoSize = true;
            this.rb_wall.Checked = true;
            this.rb_wall.Location = new System.Drawing.Point(9, 19);
            this.rb_wall.Name = "rb_wall";
            this.rb_wall.Size = new System.Drawing.Size(46, 17);
            this.rb_wall.TabIndex = 4;
            this.rb_wall.TabStop = true;
            this.rb_wall.Text = "Wall";
            this.rb_wall.UseVisualStyleBackColor = true;
            // 
            // rb_start
            // 
            this.rb_start.AutoSize = true;
            this.rb_start.Location = new System.Drawing.Point(62, 42);
            this.rb_start.Name = "rb_start";
            this.rb_start.Size = new System.Drawing.Size(47, 17);
            this.rb_start.TabIndex = 4;
            this.rb_start.Text = "Start";
            this.rb_start.UseVisualStyleBackColor = true;
            // 
            // rb_stop
            // 
            this.rb_stop.AutoSize = true;
            this.rb_stop.Location = new System.Drawing.Point(9, 42);
            this.rb_stop.Name = "rb_stop";
            this.rb_stop.Size = new System.Drawing.Size(47, 17);
            this.rb_stop.TabIndex = 4;
            this.rb_stop.Text = "Stop";
            this.rb_stop.UseVisualStyleBackColor = true;
            // 
            // settings_menu
            // 
            this.settings_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.aToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.settings_menu.Location = new System.Drawing.Point(0, 0);
            this.settings_menu.Name = "settings_menu";
            this.settings_menu.Size = new System.Drawing.Size(804, 24);
            this.settings_menu.TabIndex = 8;
            this.settings_menu.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heuristicModeToolStripMenuItem});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.aToolStripMenuItem.Text = "Algorithm";
            // 
            // heuristicModeToolStripMenuItem
            // 
            this.heuristicModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manhattanToolStripMenuItem,
            this.euclideanToolStripMenuItem,
            this.chebyshevToolStripMenuItem});
            this.heuristicModeToolStripMenuItem.Name = "heuristicModeToolStripMenuItem";
            this.heuristicModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.heuristicModeToolStripMenuItem.Text = "Heuristic Mode";
            // 
            // manhattanToolStripMenuItem
            // 
            this.manhattanToolStripMenuItem.Name = "manhattanToolStripMenuItem";
            this.manhattanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manhattanToolStripMenuItem.Text = "Manhattan";
            this.manhattanToolStripMenuItem.Click += new System.EventHandler(this.manhattanToolStripMenuItem_Click);
            // 
            // euclideanToolStripMenuItem
            // 
            this.euclideanToolStripMenuItem.Name = "euclideanToolStripMenuItem";
            this.euclideanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.euclideanToolStripMenuItem.Text = "Euclidean";
            this.euclideanToolStripMenuItem.Click += new System.EventHandler(this.euclideanToolStripMenuItem_Click);
            // 
            // chebyshevToolStripMenuItem
            // 
            this.chebyshevToolStripMenuItem.Name = "chebyshevToolStripMenuItem";
            this.chebyshevToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chebyshevToolStripMenuItem.Text = "Chebyshev";
            this.chebyshevToolStripMenuItem.Click += new System.EventHandler(this.chebyshevToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.borderColorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.clearToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepsToolStripMenuItem,
            this.linesToolStripMenuItem,
            this.dotsToolStripMenuItem,
            this.bordersToolStripMenuItem,
            this.highlightOverCurrentBoxToolStripMenuItem,
            this.aGVIndexToolStripMenuItem});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.showToolStripMenuItem.Text = "Show...";
            // 
            // stepsToolStripMenuItem
            // 
            this.stepsToolStripMenuItem.Name = "stepsToolStripMenuItem";
            this.stepsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.stepsToolStripMenuItem.Text = "...Steps";
            this.stepsToolStripMenuItem.Click += new System.EventHandler(this.stepsToolStripMenuItem_Click);
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.linesToolStripMenuItem.Text = "...Lines";
            this.linesToolStripMenuItem.Click += new System.EventHandler(this.stepsToolStripMenuItem_Click);
            // 
            // dotsToolStripMenuItem
            // 
            this.dotsToolStripMenuItem.Name = "dotsToolStripMenuItem";
            this.dotsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.dotsToolStripMenuItem.Text = "...Dots";
            this.dotsToolStripMenuItem.Click += new System.EventHandler(this.stepsToolStripMenuItem_Click);
            // 
            // bordersToolStripMenuItem
            // 
            this.bordersToolStripMenuItem.Name = "bordersToolStripMenuItem";
            this.bordersToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.bordersToolStripMenuItem.Text = "...Borders";
            this.bordersToolStripMenuItem.Click += new System.EventHandler(this.stepsToolStripMenuItem_Click);
            // 
            // highlightOverCurrentBoxToolStripMenuItem
            // 
            this.highlightOverCurrentBoxToolStripMenuItem.Name = "highlightOverCurrentBoxToolStripMenuItem";
            this.highlightOverCurrentBoxToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.highlightOverCurrentBoxToolStripMenuItem.Text = "...Highlight over current box";
            this.highlightOverCurrentBoxToolStripMenuItem.Click += new System.EventHandler(this.stepsToolStripMenuItem_Click);
            // 
            // aGVIndexToolStripMenuItem
            // 
            this.aGVIndexToolStripMenuItem.Name = "aGVIndexToolStripMenuItem";
            this.aGVIndexToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.aGVIndexToolStripMenuItem.Text = "...AGV index";
            this.aGVIndexToolStripMenuItem.Click += new System.EventHandler(this.stepsToolStripMenuItem_Click);
            // 
            // borderColorToolStripMenuItem
            // 
            this.borderColorToolStripMenuItem.Name = "borderColorToolStripMenuItem";
            this.borderColorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.borderColorToolStripMenuItem.Text = "Border Color";
            this.borderColorToolStripMenuItem.Click += new System.EventHandler(this.borderColorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wallsToolStripMenuItem,
            this.allToolStripMenuItem,
            this.borderColorToolStripMenuItem1,
            this.defaultGridSizeToolStripMenuItem});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // wallsToolStripMenuItem
            // 
            this.wallsToolStripMenuItem.Name = "wallsToolStripMenuItem";
            this.wallsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.wallsToolStripMenuItem.Text = "Walls";
            this.wallsToolStripMenuItem.Click += new System.EventHandler(this.wallsToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.ShortcutKeyDisplayString = "(F5)";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // borderColorToolStripMenuItem1
            // 
            this.borderColorToolStripMenuItem1.Name = "borderColorToolStripMenuItem1";
            this.borderColorToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.borderColorToolStripMenuItem1.Text = "Border Color";
            this.borderColorToolStripMenuItem1.Click += new System.EventHandler(this.borderColorToolStripMenuItem1_Click);
            // 
            // defaultGridSizeToolStripMenuItem
            // 
            this.defaultGridSizeToolStripMenuItem.Name = "defaultGridSizeToolStripMenuItem";
            this.defaultGridSizeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.defaultGridSizeToolStripMenuItem.Text = "Default Grid size";
            this.defaultGridSizeToolStripMenuItem.Click += new System.EventHandler(this.defaultGridSizeToolStripMenuItem_Click);
            // 
            // ofd_importmap
            // 
            this.ofd_importmap.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 466);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.settings_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.settings_menu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "A* Star multithreading demo";
            this.Load += new System.EventHandler(this.main_form_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.main_form_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.main_form_MouseUp);
            this.menuPanel.ResumeLayout(false);
            this.gb_settings.ResumeLayout(false);
            this.gb_settings.PerformLayout();
            this.gb_agvs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_AGVs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_weight)).EndInit();
            this.settings_menu.ResumeLayout(false);
            this.settings_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.RadioButton rb_stop;
        private System.Windows.Forms.RadioButton rb_start;
        private System.Windows.Forms.RadioButton rb_wall;
        private System.Windows.Forms.NumericUpDown nUD_AGVs;
        private System.Windows.Forms.MenuStrip settings_menu;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heuristicModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manhattanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem euclideanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chebyshevToolStripMenuItem;
        private System.Windows.Forms.ColorDialog cd_grid;
        private System.Windows.Forms.GroupBox gb_settings;
        private System.Windows.Forms.GroupBox gb_agvs;
        private System.Windows.Forms.NumericUpDown nud_weight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightOverCurrentBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aGVIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wallsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem defaultGridSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_exportmap;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd_importmap;
    }
}

