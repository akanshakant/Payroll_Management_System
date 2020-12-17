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
 public partial class emp_details : Form
 {
 public emp_details()
 {
 InitializeComponent();
 }
 SqlConnection con = new SqlConnection("Data Source=LAPTOP3SJO2SFI\\SQLEXPRESS;Initial Catalog=PAYROLL;Integrated Security=True");
 private void button6_Click(object sender, EventArgs e)
 {
 this.Close();
 }
 private void button4_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand(" insert into employee
(emp_id,username,age,gender,dob,phone_no,department,dep_id,doj,city,address,email_id)
values('" + comboBox2.Text + "' , '" + txtEmpName.Text + "' , " + txtEmpAge.Text + " , '" +
comboBox1.Text + "' , '" + dateTimePicker1.Text + "' , " + txtEmpContact.Text + " , '" +
txtEmpDep.Text + "' , '" + txtDepid.Text + "' , '" + dateTimePicker2.Text + "' , '" +
txtEmpCity.Text + "' , '" + txtEmpAdress.Text + "' , '" + txtEmpEmail.Text + "' ) ", con);
 cmd.ExecuteNonQuery();
 MessageBox.Show("inserted successfully");
 con.Close();
 Refresh();
 }
 private void button3_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("update employee set username = '" +
txtEmpName.Text + "' , age = " + txtEmpAge.Text + " , gender = '" + comboBox1.Text + "' ,
dob = '" + dateTimePicker1.Text + "' ,phone_no = " + txtEmpContact.Text + " , department =
'" + txtEmpDep.Text + "' , dep_id = '" + txtDepid.Text + "' , doj = '" + dateTimePicker2.Text
+ "' , address = '" + txtEmpAdress.Text + "' where emp_id = '" + comboBox2.Text + "' ",
con);
 cmd.ExecuteNonQuery();
 MessageBox.Show("updated successfully");

 con.Close();
 Refresh();
 }
 private void button2_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("delete from employee where emp_id='" +
comboBox2.Text + "' ", con);
 MessageBox.Show("deleted");
 cmd.ExecuteNonQuery();
 con.Close();
 Refresh();
 }
 private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("select * from employee where emp_id='" +
comboBox2.SelectedItem.ToString() + "' ", con);
 SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
 {
 comboBox2.Text = dr.GetValue(0).ToString();
 txtEmpName.Text = dr.GetValue(1).ToString();
 txtEmpAge.Text = dr.GetValue(2).ToString();
 comboBox1.Text = dr.GetValue(3).ToString();
 dateTimePicker1.Text = dr.GetValue(4).ToString();
 txtEmpContact.Text = dr.GetValue(5).ToString();
 txtEmpDep.Text = dr.GetValue(6).ToString();
 txtDepid.Text = dr.GetValue(7).ToString();
 dateTimePicker2.Text = dr.GetValue(8).ToString();
 txtEmpAdress.Text = dr.GetValue(9).ToString();
 txtEmpCity.Text = dr.GetValue(10).ToString();
 txtEmpEmail.Text = dr.GetValue(11).ToString();
 }
 dr.Close();
 con.Close();
 }
 private void emp_details_Load(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("select (emp_id) from employee", con);
 SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
 {
 comboBox2.Items.Add(dr.GetValue(0).ToString());
 }
 dr.Close();
 con.Close();
 Refresh();
 
 }
 void Refresh()
 {
 con.Open();
 SqlDataAdapter ada = new SqlDataAdapter("select * from employee", con);
 DataSet ds = new DataSet();
 ada.Fill(ds, "employee");
 dataGridView1.DataSource = ds;
 dataGridView1.DataMember = "employee";
 con.Close();
 }
 private void button1_Click(object sender, EventArgs e)
 {
 this.Hide();
 attendence att = new attendence();
 att.Show();
 Refresh();
 }
 private void dataGridView1_CellContentClick(object sender,
DataGridViewCellEventArgs e)
 {
 }
 private void button5_Click(object sender, EventArgs e)
 {
 comboBox2.Text = string.Empty;
 txtEmpName.Clear();
 txtEmpAge.Clear();
 comboBox1.Text = string.Empty;
 dateTimePicker1.Text = string.Empty;
 txtEmpContact.Clear();
 txtEmpDep.Clear();
 txtDepid.Clear();
 dateTimePicker2.Text = string.Empty;
 txtEmpAdress.Clear();
 txtEmpCity.Clear();
 txtEmpEmail.Clear();
 }
 }
}
