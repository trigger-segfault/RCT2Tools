using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2GroupCreator {
	public partial class WarningMessageBox : Form {
		public WarningMessageBox() {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.No;
		}
		public WarningMessageBox(string text1, string text2) {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.No;
			this.labelText1.Text = text1;
			this.labelText2.Text = text2;
		}

		private void YesPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}
		private void NoPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		public static DialogResult Show(Form parent, string text1, string text2) {
			using (var form = new WarningMessageBox(text1, text2)) {
				return form.ShowDialog(parent);
			}
		}
	}

}
