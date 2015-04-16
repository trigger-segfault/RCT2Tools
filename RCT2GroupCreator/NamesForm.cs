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
	public partial class NamesForm : Form {

		string[] names = new string[16];

		public NamesForm() {
			InitializeComponent();
			this.textBox0.Text = names[0];
			this.textBox1.Text = names[1];
			this.textBox2.Text = names[2];
			this.textBox3.Text = names[3];
			this.textBox4.Text = names[4];
			this.textBox5.Text = names[5];
			this.textBox6.Text = names[6];
			this.textBox7.Text = names[7];
			this.textBox9.Text = names[9];
			this.textBox10.Text = names[11];
			this.textBox13.Text = names[13];
		}

		public string[] Names {
			get { return names; }
			set {
				names = value;
				this.textBox0.Text = names[0];
				this.textBox1.Text = names[1];
				this.textBox2.Text = names[2];
				this.textBox3.Text = names[3];
				this.textBox4.Text = names[4];
				this.textBox5.Text = names[5];
				this.textBox6.Text = names[6];
				this.textBox7.Text = names[7];
				this.textBox9.Text = names[9];
				this.textBox10.Text = names[11];
				this.textBox13.Text = names[13];
			}
		}


		private void NameChanged(object sender, EventArgs e) {
			int index = Int32.Parse((sender as Control).Name.Replace("textBox", ""));
			names[index] = (sender as TextBox).Text;
		}

		private void OKPressed(object sender, EventArgs e) {
			names[0] = this.textBox0.Text;
			names[1] = this.textBox1.Text;
			names[2] = this.textBox2.Text;
			names[3] = this.textBox3.Text;
			names[4] = this.textBox4.Text;
			names[5] = this.textBox5.Text;
			names[6] = this.textBox6.Text;
			names[7] = this.textBox7.Text;
			names[9] = this.textBox9.Text;
			names[11] = this.textBox10.Text;
			names[13] = this.textBox13.Text;
			this.Close();
		}
	}
}
