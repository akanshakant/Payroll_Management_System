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
 public partial class department : Form
 {
 public department()
 {
 InitializeComponent();
 }
 SqlConnection con = new SqlConnection("Data Source=LAPTOP3SJO2SFI\\SQLEXPRESS;Initial Catalog=PAYROLL;Integrated Security=True");
 private void department_Load(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("select (emp_id) from depart", con);
 SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
 {
 comboBox1.Items.Add(dr.GetValue(0).ToString());
 }
 dr.Close();
 con.Close();
 Refresh();
 }
 void Refresh()
 {
 con.Open();
 SqlDataAdapter ada = new SqlDataAdapter("select * from depart", con);
 DataSet ds = new DataSet();
 ada.Fill(ds, "depart");
 dataGridView1.DataSource = ds;
 dataGridView1.DataMember = "depart";
 con.Close();
 }
 private void button4_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("insert into depart
(emp_id,emp_name,emp_dep,emp_des) values ( '" + comboBox1.Text + "' , '" +
txtEmpName.Text + "' , '" + txtEmpDep.Text + "' , '" + txtEmpDesign.Text + "' ) ", con);
41
 cmd.ExecuteNonQuery();
 MessageBox.Show("inserted successfully");
 con.Close();
 Refresh();
 }
 private void button3_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("update depart set emp_name = '" +
txtEmpName.Text + "' , emp_dep = '" + txtEmpDep.Text + "' , emp_des = '" +
txtEmpDesign.Text + "' where emp_id='" + comboBox1.Text + "' ", con);
 cmd.ExecuteNonQuery();
 MessageBox.Show("updated successfully");
 con.Close();
 Refresh();
 }
 private void button2_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("delete from depart where emp_id='" +
comboBox1.Text + "' ", con);
 MessageBox.Show("deleted");
 cmd.ExecuteNonQuery();
 con.Close();
 Refresh();
 }
 private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("select * from depart where emp_id = '" +
comboBox1.SelectedItem.ToString() + "' ", con);
 SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
 {
 comboBox1.Text = dr.GetValue(0).ToString();
 txtEmpName.Text = dr.GetValue(1).ToString();
 txtEmpDep.Text = dr.GetValue(2).ToString();
 txtEmpDesign.Text = dr.GetValue(3).ToString();
 }
 dr.Close();
 con.Close();
 }
 private void button6_Click(object sender, EventArgs e)
 {
 this.Close();
 }
 private void button1_Click(object sender, EventArgs e)
 {
 this.Hide();
 emp_details emp = new emp_details();
42
 emp.Show();
 }
 private void button5_Click(object sender, EventArgs e)
 {
 comboBox1.Text = string.Empty;
 txtEmpName.Clear();
 txtEmpDep.Clear();
 txtEmpDesign.Clear();
 }
 }
}
