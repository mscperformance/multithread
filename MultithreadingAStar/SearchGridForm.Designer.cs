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
            this.SuspendLayout();
            // 
            // btn_benchmark
            // 
            this.btn_benchmark.Location = new System.Drawing.Point(12, 12);
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
            this.lb_multi.Location = new System.Drawing.Point(93, 17);
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
            this.cb_multi.Location = new System.Drawing.Point(370, 13);
            this.cb_multi.Name = "cb_multi";
            this.cb_multi.Size = new System.Drawing.Size(113, 17);
            this.cb_multi.TabIndex = 11;
            this.cb_multi.Text = "Use multithreading";
            this.cb_multi.UseVisualStyleBackColor = true;
            this.cb_multi.CheckedChanged += new System.EventHandler(this.cb_multi_CheckedChanged);
            // 
            // SearchGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(747, 284);
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
    }
}

