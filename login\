using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace payroll_managment_system_1
{
 public partial class Form1 : Form
 {
 public Form1()
 {
 InitializeComponent();
 }
 SqlConnection con = new SqlConnection("Data Source=LAPTOP3SJO2SFI\\SQLEXPRESS;Initial Catalog=PAYROLL;Integrated Security=True");
 private void button2_Click(object sender, EventArgs e)
 {
 this.Close();
 }
 private void textBox2_TextChanged(object sender, EventArgs e)
 {
 }
 private void Form1_Load(object sender, EventArgs e)
 {
 }
 private void button1_Click(object sender, EventArgs e)
 {
 String query = "select * from login where username = '" + txtUserName.Text.Trim() +
"' and password = '" + txtEmpPassword.Text.Trim() + "' ";
 SqlDataAdapter sda = new SqlDataAdapter(query, con);
 DataTable dt = new DataTable();
 sda.Fill(dt);
 if (dt.Rows.Count == 1)
 {
 this.Hide();
 home_page ss = new home_page();
 ss.Show();
 }
 else
 {
 MessageBox.Show("username or the password is incorrect please try again!");
 }
 }
 }
}
