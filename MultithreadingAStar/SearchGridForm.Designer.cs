namespace MultiThreadingAStar
{
    partial class SearchGridForm
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
            this.btn_benchmark = new System.Windows.Forms.Button();
            this.lb_multi = new System.Windows.Forms.Label();
            this.cb_multi = new System.Windows.Forms.CheckBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.ofd_importmap = new System.Windows.Forms.OpenFileDialog();
            this.sfd_exportmap = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btn_benchmark
            // 
            this.btn_benchmark.Location = new System.Drawing.Point(184, 12);
            this.btn_benchmark.Name = "btn_benchmark";
            this.btn_benchmark.Size = new System.Drawing.Size(75, 23);
            this.btn_benchmark.TabIndex = 9;
            this.btn_benchmark.Text = "Calculate";
            this.btn_benchmark.UseVisualStyleBackColor = true;
            this.btn_benchmark.Click += new System.EventHandler(this.btn_benchmark_Click);
            // 
            // lb_multi
            // 
            this.lb_multi.AutoSize = true;
            this.lb_multi.Location = new System.Drawing.Point(282, 17);
            this.lb_multi.Name = "lb_multi";
            this.lb_multi.Size = new System.Drawing.Size(163, 13);
            this.lb_multi.TabIndex = 10;
            this.lb_multi.Text = "Time elapsed with multithreading:";
            // 
            // cb_multi
            // 
            this.cb_multi.AutoSize = true;
            this.cb_multi.Checked = true;
            this.cb_multi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_multi.Location = new System.Drawing.Point(559, 16);
            this.cb_multi.Name = "cb_multi";
            this.cb_multi.Size = new System.Drawing.Size(113, 17);
            this.cb_multi.TabIndex = 11;
            this.cb_multi.Text = "Use multithreading";
            this.cb_multi.UseVisualStyleBackColor = true;
            this.cb_multi.CheckedChanged += new System.EventHandler(this.cb_multi_CheckedChanged);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(12, 12);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(52, 23);
            this.btn_import.TabIndex = 12;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(70, 12);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(52, 23);
            this.btn_export.TabIndex = 12;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // ofd_importmap
            // 
            this.ofd_importmap.FileName = "openFileDialog1";
            // 
            // SearchGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(747, 284);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.cb_multi);
            this.Controls.Add(this.lb_multi);
            this.Controls.Add(this.btn_benchmark);
            this.MaximizeBox = false;
            this.Name = "SearchGridForm";
            this.Text = "Multithreading AStar";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_benchmark;
        private System.Windows.Forms.Label lb_multi;
        private System.Windows.Forms.CheckBox cb_multi;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.OpenFileDialog ofd_importmap;
        private System.Windows.Forms.SaveFileDialog sfd_exportmap;
    }
}

