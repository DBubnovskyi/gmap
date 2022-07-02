
namespace MapForms.Controls
{
    partial class TargetSettings
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
            this.labelTargetName = new System.Windows.Forms.Label();
            this.textTargetName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTargetName
            // 
            this.labelTargetName.AutoSize = true;
            this.labelTargetName.Location = new System.Drawing.Point(13, 10);
            this.labelTargetName.Name = "labelTargetName";
            this.labelTargetName.Size = new System.Drawing.Size(58, 13);
            this.labelTargetName.TabIndex = 0;
            this.labelTargetName.Text = "Назва цілі";
            // 
            // textTargetName
            // 
            this.textTargetName.Location = new System.Drawing.Point(16, 26);
            this.textTargetName.Name = "textTargetName";
            this.textTargetName.Size = new System.Drawing.Size(271, 20);
            this.textTargetName.TabIndex = 1;
            this.textTargetName.TextChanged += new System.EventHandler(this.textTargetName_TextChanged);
            // 
            // TargetSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textTargetName);
            this.Controls.Add(this.labelTargetName);
            this.Name = "TargetSettings";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(300, 177);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTargetName;
        private System.Windows.Forms.TextBox textTargetName;
    }
}
