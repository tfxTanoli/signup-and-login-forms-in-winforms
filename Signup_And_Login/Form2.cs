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
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				textBox1.Focus();
				errorProvider1.SetError(this.textBox1, "Please Enter Username");
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
				errorProvider2.SetError(this.textBox2, "Please Enter Password");
			}
			else
			{
				errorProvider2.Clear();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
			SqlConnection con = new SqlConnection(cs);
			string query = "Select * from signup where S_EMAIL = @email and S_PASSWORD = @pass";
			SqlCommand cmd = new SqlCommand(query, con);

			cmd.Parameters.AddWithValue("@email", textBox1.Text);
			cmd.Parameters.AddWithValue("@pass", textBox2.Text);

			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();

			if(dr.HasRows == true)
			{
				MessageBox.Show("Login Successfully...!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Invalid Credentials...!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			con.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Form1 signupPage = new Form1();
			this.Hide();
			signupPage.Show();

		}
	}
}
