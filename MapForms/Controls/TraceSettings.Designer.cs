namespace MapForms.Controls
{
    partial class TraceSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numericSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMps = new System.Windows.Forms.Label();
            this.labelMph = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Швидкість";
            // 
            // numericSpeed
            // 
            this.numericSpeed.Location = new System.Drawing.Point(130, 14);
            this.numericSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericSpeed.Name = "numericSpeed";
            this.numericSpeed.Size = new System.Drawing.Size(100, 26);
            this.numericSpeed.TabIndex = 1;
            this.numericSpeed.ValueChanged += new System.EventHandler(this.numericSpeed_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(236, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Км/год";
            // 
            // labelMps
            // 
            this.labelMps.AutoSize = true;
            this.labelMps.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMps.Location = new System.Drawing.Point(128, 43);
            this.labelMps.Name = "labelMps";
            this.labelMps.Size = new System.Drawing.Size(62, 20);
            this.labelMps.TabIndex = 3;
            this.labelMps.Text = "0 м/сек";
            // 
            // labelMph
            // 
            this.labelMph.AutoSize = true;
            this.labelMph.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMph.Location = new System.Drawing.Point(128, 63);
            this.labelMph.Name = "labelMph";
            this.labelMph.Size = new System.Drawing.Size(86, 20);
            this.labelMph.TabIndex = 4;
            this.labelMph.Text = "0 милі/год";
            // 
            // TraceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelMph);
            this.Controls.Add(this.labelMps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericSpeed);
            this.Controls.Add(this.label1);
            this.Name = "TraceSettings";
            this.Size = new System.Drawing.Size(878, 334);
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMps;
        private System.Windows.Forms.Label labelMph;
    }
}
