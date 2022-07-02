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
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Швидкість";
            // 
            // numericSpeed
            // 
            this.numericSpeed.Location = new System.Drawing.Point(87, 9);
            this.numericSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSpeed.Name = "numericSpeed";
            this.numericSpeed.Size = new System.Drawing.Size(67, 20);
            this.numericSpeed.TabIndex = 1;
            this.numericSpeed.Value = new decimal(new int[] {
            840,
            0,
            0,
            0});
            this.numericSpeed.ValueChanged += new System.EventHandler(this.numericSpeed_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(157, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Км/год";
            // 
            // labelMps
            // 
            this.labelMps.AutoSize = true;
            this.labelMps.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMps.Location = new System.Drawing.Point(85, 28);
            this.labelMps.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMps.Name = "labelMps";
            this.labelMps.Size = new System.Drawing.Size(47, 13);
            this.labelMps.TabIndex = 3;
            this.labelMps.Text = "0 м/сек";
            // 
            // labelMph
            // 
            this.labelMph.AutoSize = true;
            this.labelMph.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMph.Location = new System.Drawing.Point(85, 41);
            this.labelMph.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMph.Name = "labelMph";
            this.labelMph.Size = new System.Drawing.Size(60, 13);
            this.labelMph.TabIndex = 4;
            this.labelMph.Text = "0 милі/год";
            // 
            // TraceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelMph);
            this.Controls.Add(this.labelMps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericSpeed);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TraceSettings";
            this.Size = new System.Drawing.Size(300, 200);
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
