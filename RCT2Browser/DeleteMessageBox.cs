using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCTDataEditor {
	public partial class DeleteMessageBox : Form {
		public DeleteMessageBox() {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.DialogResult = DialogResult.No;
		}
		public DeleteMessageBox(string deletedObject) {
			InitializeComponent();
			this.DialogResult = DialogResult.No;
			this.StartPosition = FormStartPosition.CenterParent;
			this.labelDeletedObject.Text = deletedObject;
		}

		private void YesPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}
		private void NoPressed(object sender, EventArgs e) {
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		public static DialogResult Show(Form parent, string deletedObject) {
			using (var form = new DeleteMessageBox( deletedObject)) {
				return form.ShowDialog(parent);
			}
		}
	}

}
