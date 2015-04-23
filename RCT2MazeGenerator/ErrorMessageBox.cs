using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2MazeGenerator {
	public partial class ErrorMessageBox : Form {
		public ErrorMessageBox() {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.OK;
		}
		public ErrorMessageBox(string text1, string text2) {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.OK;
			this.labelText1.Text = text1;
			this.labelText2.Text = text2;
		}
		private void OKPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		public static DialogResult Show(Form parent, string text1, string text2) {
			using (var form = new ErrorMessageBox(text1, text2)) {
				return form.ShowDialog(parent);
			}
		}
	}
}
