using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRCT2Steam {
	public partial class SteamForm : Form {
		public SteamForm() {
			InitializeComponent();
		}

		private void RCT2ButtonPressed(object sender, EventArgs e) {
			string path = "Vanilla.exe";
			if (File.Exists(path)) {
				ProcessStartInfo start = new ProcessStartInfo();
				start.Arguments = path;
				start.FileName = path;
				start.WindowStyle = ProcessWindowStyle.Normal;
				start.CreateNoWindow = true;

				using (Process proc = Process.Start(start)) {
					Application.Exit();
				}
			}
			else {
				ErrorForm.Show(this, "Could not find RCT2. You must rename", "it to \"Vanilla\".");
			}
		}
		private void OpenRCT2ButtonPressed(object sender, EventArgs e) {
			string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenRCT2", "bin", "OpenRCT2.exe");
			if (File.Exists(path)) {
				ProcessStartInfo start = new ProcessStartInfo();
				start.Arguments = "";
				start.FileName = path;
				start.WorkingDirectory = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenRCT2", "bin");
				start.WindowStyle = ProcessWindowStyle.Normal;
				start.CreateNoWindow = true;

				using (Process proc = Process.Start(start)) {
					Application.Exit();
				}
			}
			else {
				ErrorForm.Show(this, "Could not find OpenRCT2. You must", "update from the launcher at least once.");
			}
		}

		private void LauncherButtonPressed(object sender, EventArgs e) {
			string path = "OpenRCT2 Launcher.exe";
			if (File.Exists(path)) {
				ProcessStartInfo start = new ProcessStartInfo();
				start.Arguments = "";
				start.FileName = path;
				start.WindowStyle = ProcessWindowStyle.Normal;
				start.CreateNoWindow = true;

				using (Process proc = Process.Start(start)) {
					Application.Exit();
				}
			}
			else {
				ErrorForm.Show(this, "Could not find OpenRCT2 Launcher. You", "must put it in your RCT2 directory.");
			}
		}

		private void XButtonPressed(object sender, EventArgs e) {
			Application.Exit();
		}
	}
}
