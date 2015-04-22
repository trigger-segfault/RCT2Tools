using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2MazeGenerator {
	partial class AboutBox : Form {
		
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public AboutBox() {
			InitializeComponent();
			this.labelTitle.Text = AssemblyTitle;
			this.labelVersion.Text = "Version " + AssemblyVersion;
			//this.labelCopyright.Text = AssemblyCopyright;
		}

		#endregion
		//============ EVENTS ============
		#region Events

		/** <summary> Opens the GitHub page of the project. </summary> */
		private void OpenGitHubPage(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://github.com/trigger-death/RCT2Tools");
		}

		#endregion
		//========== PROPERTIES ==========
		#region Properties

		/** <summary> Gets the title of the assembly. </summary> */
		public string AssemblyTitle {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0) {
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "") {
						return titleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}
		/** <summary> Gets the desciption of the assembly. </summary> */
		public string AssemblyDescription {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}
		/** <summary> Gets the version of the assembly. </summary> */
		public string AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}
		/** <summary> Gets the copyright of the assembly. </summary> */
		public string AssemblyCopyright {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		#endregion
	}
}
