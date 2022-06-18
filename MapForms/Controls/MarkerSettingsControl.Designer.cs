namespace MapForms.Controls
{
    partial class MarkerSettingsControl
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonColor = new System.Windows.Forms.Button();
            this.textBoxToolTip = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBoxTip = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelColorShow = new System.Windows.Forms.Panel();
            this.pictureBoxMarker = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelColorMarker = new System.Windows.Forms.Panel();
            this.numMarkerSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBoxTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarker)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonColor
            // 
            this.buttonColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.buttonColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonColor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonColor.Location = new System.Drawing.Point(21, 154);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(0);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(490, 50);
            this.buttonColor.TabIndex = 0;
            this.buttonColor.Text = "Колір підказки";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxToolTip
            // 
            this.textBoxToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxToolTip.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxToolTip.Location = new System.Drawing.Point(19, 66);
            this.textBoxToolTip.Name = "textBoxToolTip";
            this.textBoxToolTip.Size = new System.Drawing.Size(534, 30);
            this.textBoxToolTip.TabIndex = 2;
            this.textBoxToolTip.Text = "--";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBox1.Location = new System.Drawing.Point(20, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(244, 29);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Координати в підказці";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBoxTip
            // 
            this.groupBoxTip.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTip.Controls.Add(this.panelColorShow);
            this.groupBoxTip.Controls.Add(this.label1);
            this.groupBoxTip.Controls.Add(this.buttonColor);
            this.groupBoxTip.Controls.Add(this.checkBox1);
            this.groupBoxTip.Controls.Add(this.textBoxToolTip);
            this.groupBoxTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxTip.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxTip.Location = new System.Drawing.Point(15, 179);
            this.groupBoxTip.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxTip.Name = "groupBoxTip";
            this.groupBoxTip.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxTip.Size = new System.Drawing.Size(570, 225);
            this.groupBoxTip.TabIndex = 3;
            this.groupBoxTip.TabStop = false;
            this.groupBoxTip.Text = "Підказка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текст підказки";
            // 
            // panelColorShow
            // 
            this.panelColorShow.BackColor = System.Drawing.Color.Red;
            this.panelColorShow.Location = new System.Drawing.Point(527, 154);
            this.panelColorShow.Name = "panelColorShow";
            this.panelColorShow.Size = new System.Drawing.Size(25, 50);
            this.panelColorShow.TabIndex = 3;
            // 
            // pictureBoxMarker
            // 
            this.pictureBoxMarker.Location = new System.Drawing.Point(20, 39);
            this.pictureBoxMarker.Name = "pictureBoxMarker";
            this.pictureBoxMarker.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxMarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMarker.TabIndex = 4;
            this.pictureBoxMarker.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numMarkerSize);
            this.groupBox1.Controls.Add(this.panelColorMarker);
            this.groupBox1.Controls.Add(this.pictureBoxMarker);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(570, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Макер";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(90, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(421, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Колір маркера";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panelColorMarker
            // 
            this.panelColorMarker.BackColor = System.Drawing.Color.Red;
            this.panelColorMarker.Location = new System.Drawing.Point(527, 39);
            this.panelColorMarker.Name = "panelColorMarker";
            this.panelColorMarker.Size = new System.Drawing.Size(25, 50);
            this.panelColorMarker.TabIndex = 5;
            // 
            // numMarkerSize
            // 
            this.numMarkerSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMarkerSize.Location = new System.Drawing.Point(20, 110);
            this.numMarkerSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMarkerSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMarkerSize.Name = "numMarkerSize";
            this.numMarkerSize.Size = new System.Drawing.Size(78, 30);
            this.numMarkerSize.TabIndex = 6;
            this.numMarkerSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numMarkerSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Розмір маркера";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(15, 404);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 381);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список маркерів";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 100);
            this.panel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Gray;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.ForeColor = System.Drawing.Color.Aqua;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(3, 126);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(564, 252);
            this.listBox1.TabIndex = 1;
            // 
            // MarkerSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxTip);
            this.Controls.Add(this.groupBox1);
            this.Name = "MarkerSettingsControl";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(600, 800);
            this.groupBoxTip.ResumeLayout(false);
            this.groupBoxTip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarker)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.TextBox textBoxToolTip;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBoxTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelColorShow;
        private System.Windows.Forms.PictureBox pictureBoxMarker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelColorMarker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMarkerSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
