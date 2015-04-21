namespace RCT2PaletteConverter {
	partial class ConverterForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConverterForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.mazeEditor1 = new RCT2PaletteConverter.MazeEditor();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(541, 461);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(83, 74);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 50;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// mazeEditor1
			// 
			this.mazeEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.mazeEditor1.BackgroundImage = global::RCT2PaletteConverter.Properties.Resources.Grass;
			this.mazeEditor1.Cursor = System.Windows.Forms.Cursors.Default;
			this.mazeEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mazeEditor1.Location = new System.Drawing.Point(0, 0);
			this.mazeEditor1.MazeSize = new System.Drawing.Size(50, 50);
			this.mazeEditor1.Name = "mazeEditor1";
			this.mazeEditor1.Size = new System.Drawing.Size(668, 583);
			this.mazeEditor1.TabIndex = 1;
			this.mazeEditor1.Text = "mazeEditor1";
			// 
			// ConverterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 583);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.mazeEditor1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConverterForm";
			this.Text = "RCT2 Palette Converter";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
		private MazeEditor mazeEditor1;
	}
}

