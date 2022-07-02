using System;
using System.Runtime.InteropServices;
using MapForms.Controls;

namespace MapForms
{
    partial class MainForm
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

        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelCoordinates = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.buttonRoute = new MapForms.Controls.ButtonControl();
            this.buttonMarker = new MapForms.Controls.ButtonControl();
            this.mapControl = new MapForms.Controls.MapControl();
            this.traceSettings = new MapForms.Controls.TraceSettings();
            this.targetSettings = new MapForms.Controls.TargetSettings();
            this.panelBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(903, 32);
            this.panelTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.labelCoordinates);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 373);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(903, 31);
            this.panelBottom.TabIndex = 1;
            // 
            // labelCoordinates
            // 
            this.labelCoordinates.AutoSize = true;
            this.labelCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoordinates.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelCoordinates.Location = new System.Drawing.Point(8, 6);
            this.labelCoordinates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCoordinates.Name = "labelCoordinates";
            this.labelCoordinates.Size = new System.Drawing.Size(88, 17);
            this.labelCoordinates.TabIndex = 0;
            this.labelCoordinates.Text = "Координати";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panelLeft);
            this.panel1.Controls.Add(this.panelRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(903, 341);
            this.panel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonRoute);
            this.panel5.Controls.Add(this.buttonMarker);
            this.panel5.Controls.Add(this.mapControl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(204, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(395, 333);
            this.panel5.TabIndex = 10;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(4, 4);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 333);
            this.panelLeft.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.DarkGray;
            this.panelRight.Controls.Add(this.targetSettings);
            this.panelRight.Controls.Add(this.traceSettings);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(599, 4);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(300, 333);
            this.panelRight.TabIndex = 8;
            // 
            // buttonRoute
            // 
            this.buttonRoute.ActiveMode = MapForms.Controls.ActiveMapMode.Trajectory;
            this.buttonRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRoute.ButtonIcon = MapForms.Controls.ButtonControl.IconType.route;
            this.buttonRoute.ElementText = "Траекторія";
            this.buttonRoute.Location = new System.Drawing.Point(234, 38);
            this.buttonRoute.Margin = new System.Windows.Forms.Padding(1);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(157, 32);
            this.buttonRoute.TabIndex = 5;
            // 
            // buttonMarker
            // 
            this.buttonMarker.ActiveMode = MapForms.Controls.ActiveMapMode.Targets;
            this.buttonMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMarker.ButtonIcon = MapForms.Controls.ButtonControl.IconType.marker;
            this.buttonMarker.ElementText = "Цілі";
            this.buttonMarker.Location = new System.Drawing.Point(234, 2);
            this.buttonMarker.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMarker.Name = "buttonMarker";
            this.buttonMarker.Size = new System.Drawing.Size(157, 32);
            this.buttonMarker.TabIndex = 4;
            // 
            // mapControl
            // 
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(395, 333);
            this.mapControl.TabIndex = 3;
            // 
            // traceSettings
            // 
            this.traceSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.traceSettings.Location = new System.Drawing.Point(0, 0);
            this.traceSettings.Margin = new System.Windows.Forms.Padding(1);
            this.traceSettings.Name = "traceSettings";
            this.traceSettings.Size = new System.Drawing.Size(300, 79);
            this.traceSettings.SpeedChaged = null;
            this.traceSettings.TabIndex = 0;
            // 
            // targetSettings
            // 
            this.targetSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.targetSettings.Location = new System.Drawing.Point(0, 79);
            this.targetSettings.Name = "targetSettings";
            this.targetSettings.Padding = new System.Windows.Forms.Padding(10);
            this.targetSettings.Size = new System.Drawing.Size(300, 88);
            this.targetSettings.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(903, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "Map";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCoordinates;
        private MapControl mapControl;
        private ButtonControl buttonMarker;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private ButtonControl buttonRoute;
        private TraceSettings traceSettings;
        private TargetSettings targetSettings;
    }
}

