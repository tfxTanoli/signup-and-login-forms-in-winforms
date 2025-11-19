using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Signup_And_Login
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrEmpty(textBox9.Text))
			{
				MessageBox.Show("Please Fill All The Details");
			}
			else if (textBox8.Text != textBox9.Text)
			{
				MessageBox.Show("Password and Confirm Password do not match");
			}
			else
			{
				string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
				SqlConnection con = new SqlConnection(cs);
				string query = "insert into signup values (@id, @name,@gender,@fathername,@age,@class,@email,@pass)";
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@id", textBox1.Text);
				cmd.Parameters.AddWithValue("@name", textBox2.Text);
				cmd.Parameters.AddWithValue("@gender", textBox3.Text);
				cmd.Parameters.AddWithValue("@fathername", textBox4.Text);
				cmd.Parameters.AddWithValue("@age", textBox5.Text);
				cmd.Parameters.AddWithValue("@class", textBox6.Text);
				cmd.Parameters.AddWithValue("@email", textBox7.Text);
				cmd.Parameters.AddWithValue("@pass", textBox8.Text);

				con.Open();
				int a = cmd.ExecuteNonQuery();

				if (a > 0)
				{
					MessageBox.Show("Data inserted successfully");
				}
				else
				{
					MessageBox.Show("Data not inserted");
				}
				con.Close();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(textBox1.Text))
			{
				textBox1.Focus();
				errorProvider1.SetError(this.textBox1, "Please Enter ID");
			}
			else
			{
				errorProvider1.Clear();
			}
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				textBox2.Focus();
				errorProvider2.SetError(this.textBox2, "Please Enter Name");
			}
			else
			{
				errorProvider2.Clear();
			}
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(textBox3.Text))
			{
				textBox3.Focus();
				errorProvider3.SetError(this.textBox3, "Please Enter Valid Gender");
			}
			else
			{
				errorProvider3.Clear();
			}
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox4.Text))
			{
				textBox4.Focus();
				errorProvider4.SetError(this.textBox4, "Please Enter Father Name");
			}
			else
			{
				errorProvider4.Clear();
			}
		}

		private void textBox5_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox5.Text))
			{
				textBox5.Focus();
				errorProvider5.SetError(this.textBox5, "Please Enter Age");
			}
			else
			{
				errorProvider5.Clear();
			}
		}

		private void textBox6_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox6.Text))
			{
				textBox6.Focus();
				errorProvider6.SetError(this.textBox6, "Please Enter Class");
			}
			else
			{
				errorProvider6.Clear();
			}
		}

		private void textBox7_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox7.Text))
			{
				textBox7.Focus();
				errorProvider7.SetError(this.textBox7, "Please Enter Email");
			}
			else
			{
				errorProvider7.Clear();
			}
		}

		private void textBox8_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox8.Text))
			{
				textBox8.Focus();
				errorProvider8.SetError(this.textBox8, "Please Enter Password");
			}
			else
			{
				errorProvider8.Clear();
			}
		}

		private void textBox9_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox9.Text))
			{
				textBox9.Focus();
				errorProvider9.SetError(this.textBox9, "Please Enter Confirm Password");
			}
			else
			{
				errorProvider9.Clear();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if(Char.IsDigit(ch) || ch == 8) {
			e.Handled = false;
			}
			else
			{
			e.Handled = true;
			}
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (Char.IsDigit(ch) || ch == 8)
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if(Char.IsLetter(ch) || ch == 8 || ch==32)
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (Char.IsLetter(ch) || ch == 8 || ch == 32)
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
	}
}
