using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCTDataEditor {
	partial class AboutBox : Form {
		public AboutBox() {
			InitializeComponent();
			this.labelVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.StartPosition = FormStartPosition.CenterParent;
		}
		private void OpenGitHubPage(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://github.com/trigger-death/RCT2Tools");
		}
	}
}
