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
	public partial class RenameMessageBox : Form {

		public string NewName {
			get { return this.textBoxName.Text; }
		}

		public RenameMessageBox() {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.Cancel;
		}
		public RenameMessageBox(string currentName) {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.Cancel;
			this.textBoxName.Text = currentName;
		}

		private void YesPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void NoPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		public static DialogResult Show(Form parent, string currentName) {
			using (var form = new RenameMessageBox(currentName)) {
				return form.ShowDialog(parent);
			}
		}
	}

}
