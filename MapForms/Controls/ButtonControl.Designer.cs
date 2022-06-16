using System.Drawing;

namespace MapForms.Controls
{
    partial class ButtonControl
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
            this.ButtonText = new System.Windows.Forms.Label();
            this.panelHiglight = new System.Windows.Forms.Panel();
            this.panelShowButton = new System.Windows.Forms.Panel();
            this.pictureShow = new System.Windows.Forms.PictureBox();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.panelShowButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonText
            // 
            this.ButtonText.AutoSize = true;
            this.ButtonText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonText.Location = new System.Drawing.Point(53, 10);
            this.ButtonText.Name = "ButtonText";
            this.ButtonText.Size = new System.Drawing.Size(68, 25);
            this.ButtonText.TabIndex = 0;
            this.ButtonText.Text = "Button";
            this.ButtonText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.ButtonText.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.ButtonText.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            // 
            // panelHiglight
            // 
            this.panelHiglight.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelHiglight.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHiglight.Location = new System.Drawing.Point(0, 0);
            this.panelHiglight.Name = "panelHiglight";
            this.panelHiglight.Size = new System.Drawing.Size(15, 45);
            this.panelHiglight.TabIndex = 1;
            this.panelHiglight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.panelHiglight.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.panelHiglight.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            // 
            // panelShowButton
            // 
            this.panelShowButton.Controls.Add(this.pictureShow);
            this.panelShowButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelShowButton.Location = new System.Drawing.Point(225, 0);
            this.panelShowButton.Name = "panelShowButton";
            this.panelShowButton.Size = new System.Drawing.Size(45, 45);
            this.panelShowButton.TabIndex = 3;
            this.panelShowButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_ClickShow);
            this.panelShowButton.MouseEnter += new System.EventHandler(this.Mouse_EnterShow);
            this.panelShowButton.MouseLeave += new System.EventHandler(this.Mouse_LeaveShow);
            // 
            // pictureShow
            // 
            this.pictureShow.Image = global::MapForms.Properties.Resources.left_arrow_button;
            this.pictureShow.Location = new System.Drawing.Point(12, 11);
            this.pictureShow.Name = "pictureShow";
            this.pictureShow.Size = new System.Drawing.Size(25, 25);
            this.pictureShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureShow.TabIndex = 4;
            this.pictureShow.TabStop = false;
            this.pictureShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_ClickShow);
            this.pictureShow.MouseEnter += new System.EventHandler(this.Mouse_EnterShow);
            this.pictureShow.MouseLeave += new System.EventHandler(this.Mouse_LeaveShow);
            // 
            // pictureIcon
            // 
            this.pictureIcon.Image = global::MapForms.Properties.Resources.polygon;
            this.pictureIcon.Location = new System.Drawing.Point(23, 10);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(25, 25);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 2;
            this.pictureIcon.TabStop = false;
            this.pictureIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.pictureIcon.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.pictureIcon.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            // 
            // ButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panelShowButton);
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.ButtonText);
            this.Controls.Add(this.panelHiglight);
            this.Name = "ButtonControl";
            this.Size = new System.Drawing.Size(270, 45);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.panelShowButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label ButtonText;
        private System.Windows.Forms.Panel panelHiglight;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.Panel panelShowButton;
        private System.Windows.Forms.PictureBox pictureShow;
    }
}
