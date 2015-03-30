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
public partial class AboutForm : Form {
	public AboutForm() {
		InitializeComponent();
	}



	private void OpenGitHubPage(object sender, EventArgs e) {
		System.Diagnostics.Process.Start("https://github.com/trigger-death/RCT2Tools");
	}
}
}
