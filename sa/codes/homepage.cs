using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace payroll_managment_system_1
{
 public partial class home_page : Form
 {
 public home_page()
 {
 InitializeComponent();
 }
 private void button6_Click(object sender, EventArgs e)
 {
 this.Close();
 }
 private void button1_Click(object sender, EventArgs e)
 {
 this.Hide();
 department dep = new department();
 dep.Show();
 }
 private void button2_Click(object sender, EventArgs e)
 {
 this.Hide();
 emp_details emp = new emp_details();
 emp.Show();
 }
 private void button5_Click(object sender, EventArgs e)
 {
 this.Hide();
 attendence att = new attendence();
 att.Show();
 }
 }
}
