namespace MapForms.Controls
{
    partial class MapControl
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
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.labelCoordinates = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 0);
            this.gMapControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1077, 559);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            // 
            // labelCoordinates
            // 
            this.labelCoordinates.AutoSize = true;
            this.labelCoordinates.BackColor = System.Drawing.SystemColors.Info;
            this.labelCoordinates.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelCoordinates.Location = new System.Drawing.Point(3, 2);
            this.labelCoordinates.Name = "labelCoordinates";
            this.labelCoordinates.Size = new System.Drawing.Size(128, 20);
            this.labelCoordinates.TabIndex = 0;
            this.labelCoordinates.Text = "labelCoordinates";// 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.BackColor = System.Drawing.SystemColors.Info;
            this.labelDistance.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelDistance.Location = new System.Drawing.Point(3, 24);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(105, 20);
            this.labelDistance.TabIndex = 1;
            this.labelDistance.Text = "labelDistance";
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.labelCoordinates);
            this.Controls.Add(this.gMapControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(1077, 559);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Label labelCoordinates;
        private System.Windows.Forms.Label labelDistance;
    }
}
