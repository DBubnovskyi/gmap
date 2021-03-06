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
            this.buttonControl1 = new MapForms.Controls.ButtonControl();
            this.buttonRoute = new MapForms.Controls.ButtonControl();
            this.buttonMarker = new MapForms.Controls.ButtonControl();
            this.mapControl = new MapForms.Controls.MapControl();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.markerSettingsControl1 = new MapForms.Controls.MarkerSettingsControl();
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
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1354, 50);
            this.panelTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.labelCoordinates);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 575);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1354, 47);
            this.panelBottom.TabIndex = 1;
            // 
            // labelCoordinates
            // 
            this.labelCoordinates.AutoSize = true;
            this.labelCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoordinates.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelCoordinates.Location = new System.Drawing.Point(12, 9);
            this.labelCoordinates.Name = "labelCoordinates";
            this.labelCoordinates.Size = new System.Drawing.Size(124, 25);
            this.labelCoordinates.TabIndex = 0;
            this.labelCoordinates.Text = "Координати";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panelLeft);
            this.panel1.Controls.Add(this.panelRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1354, 525);
            this.panel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonControl1);
            this.panel5.Controls.Add(this.buttonRoute);
            this.panel5.Controls.Add(this.buttonMarker);
            this.panel5.Controls.Add(this.mapControl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(306, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(442, 513);
            this.panel5.TabIndex = 10;
            // 
            // buttonControl1
            // 
            this.buttonControl1.ActiveMode = MapForms.Controls.ActiveMapMode.Poligon;
            this.buttonControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonControl1.ButtonIcon = MapForms.Controls.ButtonControl.IconType.polygon;
            this.buttonControl1.ElementText = "Полігони";
            this.buttonControl1.Location = new System.Drawing.Point(201, 113);
            this.buttonControl1.Name = "buttonControl1";
            this.buttonControl1.Size = new System.Drawing.Size(235, 49);
            this.buttonControl1.TabIndex = 6;
            // 
            // buttonRoute
            // 
            this.buttonRoute.ActiveMode = MapForms.Controls.ActiveMapMode.Route;
            this.buttonRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRoute.ButtonIcon = MapForms.Controls.ButtonControl.IconType.route;
            this.buttonRoute.ElementText = "Маршрути";
            this.buttonRoute.Location = new System.Drawing.Point(201, 58);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(235, 49);
            this.buttonRoute.TabIndex = 5;
            // 
            // buttonMarker
            // 
            this.buttonMarker.ActiveMode = MapForms.Controls.ActiveMapMode.Marcer;
            this.buttonMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMarker.ButtonIcon = MapForms.Controls.ButtonControl.IconType.marker;
            this.buttonMarker.ElementText = "Маркери";
            this.buttonMarker.Location = new System.Drawing.Point(201, 3);
            this.buttonMarker.Name = "buttonMarker";
            this.buttonMarker.Size = new System.Drawing.Size(235, 49);
            this.buttonMarker.TabIndex = 4;
            // 
            // mapControl
            // 
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(442, 513);
            this.mapControl.TabIndex = 3;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(6, 6);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 513);
            this.panelLeft.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.markerSettingsControl1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(748, 6);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(600, 513);
            this.panelRight.TabIndex = 8;
            // 
            // markerSettingsControl1
            // 
            this.markerSettingsControl1.BackColor = System.Drawing.Color.Transparent;
            this.markerSettingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markerSettingsControl1.Location = new System.Drawing.Point(0, 0);
            this.markerSettingsControl1.Name = "markerSettingsControl1";
            this.markerSettingsControl1.Padding = new System.Windows.Forms.Padding(15);
            this.markerSettingsControl1.Size = new System.Drawing.Size(600, 513);
            this.markerSettingsControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1354, 622);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private ButtonControl buttonControl1;
        private MarkerSettingsControl markerSettingsControl1;
    }
}

