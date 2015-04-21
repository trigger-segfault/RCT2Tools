namespace RCT2MazeGenerator {
	partial class MazeForm {
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.rctPanel1 = new CustomControls.RCTPanel();
			this.mazeEditor1 = new RCT2PaletteConverter.MazeEditor();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.rctPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.rctPanel1);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainer1.Size = new System.Drawing.Size(631, 453);
			this.splitContainer1.SplitterDistance = 210;
			this.splitContainer1.TabIndex = 1;
			// 
			// rctPanel1
			// 
			this.rctPanel1.Controls.Add(this.mazeEditor1);
			this.rctPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel1.Location = new System.Drawing.Point(3, 3);
			this.rctPanel1.Name = "rctPanel1";
			this.rctPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctPanel1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel1.Size = new System.Drawing.Size(411, 447);
			this.rctPanel1.TabIndex = 0;
			// 
			// mazeEditor1
			// 
			this.mazeEditor1.BackgroundImage = global::RCT2MazeGenerator.Properties.Resources.Grass;
			this.mazeEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mazeEditor1.Location = new System.Drawing.Point(1, 1);
			this.mazeEditor1.MazeSize = new System.Drawing.Size(20, 20);
			this.mazeEditor1.Name = "mazeEditor1";
			this.mazeEditor1.Size = new System.Drawing.Size(409, 445);
			this.mazeEditor1.TabIndex = 0;
			this.mazeEditor1.Text = "mazeEditor1";
			// 
			// MazeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(631, 453);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MazeForm";
			this.Text = "RCT2 Maze Generator";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mazeEditor1_KeyDown);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.rctPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private CustomControls.RCTPanel rctPanel1;
		private RCT2PaletteConverter.MazeEditor mazeEditor1;
	}
}

