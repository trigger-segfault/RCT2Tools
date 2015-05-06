using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2MusicManager {
	public partial class VolumeMessageBox : Form {

		public int NewVolume {
			get { return this.trackBarVolume.Value; }
		}

		public VolumeMessageBox() {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.Cancel;
		}
		public VolumeMessageBox(int currentVolume) {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.Cancel;
			this.trackBarVolume.Value = currentVolume;
			this.labelVolume.Text = currentVolume.ToString() + "%";
		}

		private void YesPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void NoPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		public static DialogResult Show(Form parent, int currentVolume) {
			using (var form = new VolumeMessageBox(currentVolume)) {
				return form.ShowDialog(parent);
			}
		}

		private void VolumeChanged(object sender, EventArgs e) {
			this.labelVolume.Text = this.trackBarVolume.Value.ToString() + "%";
		}
	}

}
