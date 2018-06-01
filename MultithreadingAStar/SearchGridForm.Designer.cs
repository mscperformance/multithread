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
            // 
            // SearchGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(693, 284);
            this.Controls.Add(this.btn_benchmark);
            this.MaximizeBox = false;
            this.Name = "SearchGridForm";
            this.Text = "EpPathFinding.cs Demo";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_benchmark;
    }
}

