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
 public partial class attendence : Form
 {
 public attendence()
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
 SqlCommand cmd = new SqlCommand("insert into leave
(emp_id,name,dep,tot_no_of_days,worked_days,wages,sick_leave,casual_leave,no_taken,mo
n_leave,extra_leave,leave_ded) values ( '" + comboBox1.Text + "' , '" + txtEmpName.Text +
"' , '" + txtEmpDep.Text + "' , " + txtEmpTot.Text + " , " + txtEmpWork.Text + " , " +
txtEmpWage.Text + " , " + txtEmpSick.Text + " , " + txtEmpCasual.Text + " , " +
txtEmpNo.Text + " , " + txtEmpMon.Text + " , " + txtEmpExtra.Text + " , " +
txtEmpDed.Text + " ) ", con);
 cmd.ExecuteNonQuery();
 MessageBox.Show("inserted successfully");
 con.Close();
 Refresh();
 }
 private void button3_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("update leave set name = '" +
txtEmpName.Text + "' , dep = '" + txtEmpDep.Text + "' , tot_no_of_days = " +
txtEmpTot.Text + " , worked_days = " + txtEmpWork.Text + " , wages = " +
txtEmpWage.Text + " , sick_leave = " + txtEmpSick.Text + " , casual_leave = " +
txtEmpCasual.Text + " , no_taken = " + txtEmpNo.Text + " , mon_leave = " + 

txtEmpMon.Text + " , extra_leave = " + txtEmpExtra.Text + " , leave_ded = " +
txtEmpDed.Text + " where emp_id='" + comboBox1.Text + "' ", con);
 cmd.ExecuteNonQuery();
 MessageBox.Show("updated successfully");
 con.Close();
 Refresh();
 }
 private void attendence_Load(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("select (emp_id) from leave", con);
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
 SqlDataAdapter ada = new SqlDataAdapter("select * from leave", con);
 DataSet ds = new DataSet();
 ada.Fill(ds, "leave");
 dataGridView1.DataSource = ds;
 dataGridView1.DataMember = "leave";
 con.Close();
 }
 private void button2_Click(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("delete from leave where emp_id='" +
comboBox1.Text + "' ", con);
 MessageBox.Show("deleted");
 cmd.ExecuteNonQuery();
 con.Close();
 Refresh();
 }
 private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
 {
 con.Open();
 SqlCommand cmd = new SqlCommand("select * from leave where emp_id = '" +
comboBox1.SelectedItem.ToString() + "' ", con);
 SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
 {
 comboBox1.Text = dr.GetValue(0).ToString();
 txtEmpName.Text = dr.GetValue(1).ToString();
 txtEmpDep.Text = dr.GetValue(2).ToString();
 txtEmpTot.Text = dr.GetValue(3).ToString();
 txtEmpWork.Text = dr.GetValue(4).ToString();
 txtEmpWage.Text = dr.GetValue(5).ToString();
 txtEmpSick.Text = dr.GetValue(6).ToString();
 txtEmpCasual.Text = dr.GetValue(7).ToString();
 txtEmpNo.Text = dr.GetValue(8).ToString();
 txtEmpMon.Text = dr.GetValue(9).ToString();
 txtEmpExtra.Text = dr.GetValue(10).ToString();
 txtEmpDed.Text = dr.GetValue(11).ToString();
 }
 dr.Close();
 con.Close();
 }
 private void button5_Click(object sender, EventArgs e)
 {
 comboBox1.Text = string.Empty;
 txtEmpName.Clear();
 txtEmpDep.Clear();
 txtEmpTot.Clear();
 txtEmpWork.Clear();
 txtEmpWage.Clear();
 txtEmpSick.Clear();
 txtEmpCasual.Clear();
 txtEmpNo.Clear();
 txtEmpMon.Clear();
 txtEmpExtra.Clear();
 txtEmpDed.Clear();

 }
 }
}
