using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace final
{
    public partial class salary : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        MySqlDataAdapter sqlDta = new MySqlDataAdapter();
        DataTable sqlDt = new DataTable();
        MySqlDataReader sqlRd;

        DataSet DS = new DataSet();

        String server = "localhost";
        String database = "employee";
        String username = "root";
        String password = "admin";

        private void uploadData()
        {

            sqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "select * from employeedb";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView1.DataSource = sqlDt;

        }

        private void refreshdb()
        {
            try
            {
                sqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCmd.Connection = sqlConn;

                MySqlDataAdapter sqlDta = new MySqlDataAdapter("select * from employeedb", sqlConn);
                DataTable sqlDt = new DataTable();

                sqlDta.Fill(sqlDt);
                dataGridView1.DataSource = sqlDt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public salary()
        {
            InitializeComponent();
            uploadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtotherpayment_MouseClick(object sender, MouseEventArgs e)
        {

            txtotherpayment.Text = "";
            txtotherpayment.Focus();
        }

        private void txtotherpayment_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmpID.Text = "";
                txtFirstname.Text = "";
                txtSurname.Text = "";
                txtaddress.Text = "";
                txtmobile.Text = "";
                txtcityweighting.Text = "";
                txtbasicsalary.Text = "";
                txtovertime.Text = "";
                txtotherpayment.Text = "0.0";
                txttax.Text = "";
                txtpension.Text = "";
                txtstudentloan.Text = "";
                txtNIPayment.Text = "";
                txttaxcode.Text = "";
                txttaxperiod.Text = "0";
                txtNIPeriod.Text = "";
                txtNICode.Text = "";
                txttaxablepay.Text = "";
                txtpensionablepay.Text = "";
                txtnetpay.Text = "";
                txtgrosspay.Text = "";
                txtdeduction.Text = "";
                txtsearch.Text = "";
                dateTimePicker1.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                System.Drawing.Font fntsring = new System.Drawing.Font("Arial", 18, FontStyle.Regular);
                e.Graphics.DrawString(rtPayslip.Text, fntsring, Brushes.Black, 120, 120);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("confirm if you want to exit", "Employee system", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salary_Load(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            refreshdb();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {

                sqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;

                sqlCmd.Connection = sqlConn;

                String EmpID = txtEmpID.Text;
                String Firstname = txtFirstname.Text;
                String Surname = txtSurname.Text;
                String Address = txtaddress.Text;
                String Gender = combogender.Text;
                String Mobile = txtmobile.Text;
                String Cityweighting = txtcityweighting.Text;
                String Basicsalary = txtbasicsalary.Text;
                String Overtime = txtovertime.Text;
                String Otherpayment = txtotherpayment.Text;
                String Tax = txttax.Text;
                String Pension = txtpension.Text;
                String Studentloan = txtstudentloan.Text;
                String NIPayment = txtNIPayment.Text;
                String Paydate1 = dateTimePicker1.Text;
                String Taxperiod = txttaxperiod.Text;
                String Taxcode = txttaxcode.Text;
                String NIPeriod = txtNIPeriod.Text;
                String NICode = txtNICode.Text;
                String Taxablepay = txttaxablepay.Text;
                String Pensionablepay = txtpensionablepay.Text;
                String Netpay = txtnetpay.Text;
                String Grosspay = txtgrosspay.Text;
                String Deduction = txtdeduction.Text;
                DateTime DateVal = DateTime.Now;
                String Paydate = string.Format("{0:yyyy-MM-dd}", DateVal);


                sqlCmd.CommandText = "UPDATE employeedb SET Firstname = '" + Firstname + "',Surname = '" + Surname + "'," +
                    "Address = '" + Address + "',Gender = '" + Gender + "',Mobile = '" + Mobile + "',Cityweighting = '" + Cityweighting + "',Basicsalary = '" + Basicsalary +
                    "',Overtime = '" + Overtime + "', Otherpayment = '" + Otherpayment + "',Tax = '" + Tax + "',Pension = '" + Pension + "', Studentloan = '" + Studentloan +
                    "',NIPayment = '" + NIPayment + "',Paydate = '" + Paydate + "',Taxperiod = '" + Taxperiod + "',Taxcode = '" + Taxcode + "',NIPeriod = '" + NIPeriod +
                    "',NICode = '" + NICode + "',Taxablepay = '" + Taxablepay + "',Pensionablepay = '" + Pensionablepay + "',Netpay = '" + Netpay +
                    "',Grosspay = '" + Grosspay + "',Deduction = '" + Deduction + "' WHERE EmpID = " + EmpID + "";
                Console.WriteLine("PoojaPagal " + sqlCmd.CommandText);




                sqlConn.Open();

                sqlRd = sqlCmd.ExecuteReader();
                MessageBox.Show("Record Updated", "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlConn.Close();
                refreshdb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                sqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;

                sqlCmd.Connection = sqlConn;
                String EmpID = txtEmpID.Text;
                sqlCmd.CommandText = "delete from employeedb where EmpID = " + EmpID + "";
                Console.WriteLine("poojaMahaPagal" + sqlCmd.CommandText);
                sqlConn.Open();
                sqlRd = sqlCmd.ExecuteReader();
                MessageBox.Show("Record deleted", "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlConn.Close();
                refreshdb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    refreshdb();
                    DataView dv = sqlDt.DefaultView;
                    dv.RowFilter = string.Format("Firstname like '%{0}%'", txtsearch.Text);
                    dataGridView1.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                refreshdb();
                DataView dv = sqlDt.DefaultView;
                dv.RowFilter = string.Format("Firstname like'%{0}%'", txtsearch.Text);
                dataGridView1.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btntotal_Click(object sender, EventArgs e)
        {
            try
            {

                double Grosspay, Deduction, Netpay, Period;
                double Intercity, Basicpay, Overtime, OtherPayment, Tax, Pension, StudentLoan, NIPayment;

                Intercity = Double.Parse(txtcityweighting.Text);
                Basicpay = Double.Parse(txtbasicsalary.Text);
                Overtime = Double.Parse(txtovertime.Text);
                OtherPayment = Double.Parse(txtotherpayment.Text);
                Grosspay = Intercity + Basicpay + Overtime + OtherPayment;

                txtgrosspay.Text = String.Format("{0:c2}", Grosspay);

                Tax = (Grosspay * 9) / 100;
                Pension = (Grosspay * 12) / 100;
                StudentLoan = (Grosspay * 5) / 100;
                NIPayment = (Grosspay * 3) / 100;

                txttax.Text = String.Format("{0:c2}", Tax);
                txtpension.Text = String.Format("{0:c2}", Pension);
                txtstudentloan.Text = String.Format("{0:c2}", StudentLoan);
                txtNIPayment.Text = String.Format("{0:c2}", NIPayment);

                Deduction = Tax + Pension + StudentLoan + NIPayment;
                txtdeduction.Text = String.Format("{0:c2}", Deduction);

                Netpay = Grosspay - Deduction;
                txtnetpay.Text = String.Format("{0:c2}", Netpay);

                Period = Double.Parse(txttaxperiod.Text);
                txttaxablepay.Text = String.Format("{0:c2}", Period);
                txtpensionablepay.Text = String.Format("{0:c2}", Period * Pension);
                // ==============================================================================================================================


                sqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;
                DateTime DateVal = DateTime.Now;
                String dateInSqlFormat = string.Format("{0:yyyy-MM-dd}", DateVal);
                Console.WriteLine("Pooja " + dateInSqlFormat);
                sqlCmd.CommandText = "insert into employeedb(EmpID,Firstname,Surname,Address,Gender,Mobile,Cityweighting,"
                    + "Basicsalary,Overtime,Otherpayment,Tax,Pension,Studentloan,NIPayment,Taxperiod,Taxcode,NIPeriod,NICode,"
                    + "Taxablepay,Pensionablepay,Netpay,Grosspay,Deduction,Paydate)" +
               "values('" + txtEmpID.Text + "','" + txtFirstname.Text + "','" + txtSurname.Text + "','" + txtaddress.Text + "'," +
               "'" + combogender.Text + "','" + txtmobile.Text + "','" + txtcityweighting.Text + "','" + txtbasicsalary.Text + "'," +
               "'" + txtovertime.Text + "','" + txtotherpayment.Text + "','" + txttax.Text + "','" + txtpension.Text + "','" + txtstudentloan.Text + "','" +
               txtNIPayment.Text + "','" + txttaxperiod.Text + "','" + txttaxcode.Text + "','" + txtNIPeriod.Text + "','" +
               txtNICode.Text + "','" + txttaxablepay.Text + "','" + txtpensionablepay.Text + "','" + txtnetpay.Text + "','" + txtgrosspay.Text + "','" +
               txtdeduction.Text + "','" + dateInSqlFormat + "')";
                Console.WriteLine("This is C# " + sqlCmd.CommandText);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                refreshdb();

                // ==============================================================================================================================
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtotherpayment_MouseLeave(object sender, EventArgs e)
        {
            if (txtotherpayment.Text == "")
            {
                txtotherpayment.Text = "0.0";
            }

        }

        private void btnpayslip_Click(object sender, EventArgs e)
        {
            rtPayslip.Clear();
            rtPayslip.AppendText("\t\t" + "Payslip" + "\t\t" + "\n");
            rtPayslip.AppendText("\t\t" + "----------------------------------------" + "\t\t" + "\n");
            rtPayslip.AppendText("\t\t" + "EmpID" + "\t\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Firstname" + "\t" + txtFirstname.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Surname" + "\t" + txtSurname.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Address" + "\t\t" + txtaddress.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Gender" + "\t\t" + combogender.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Mobile" + "\t\t" + txtmobile.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Cityweight" + "\t" + txtcityweighting.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Salary" + "\t\t" + txtbasicsalary.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Overtime" + "\t" + txtovertime.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Otherpayment" + "\t" + txtotherpayment.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Tax" + "\t\t" + txttax.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Pension" + "\t\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Studentloan" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "NIPayment" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Paydate" + "\t\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Taxperiod" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Taxcode" + "\t\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "NIPeriod" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "NICode" + "\t\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Taxablepay" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Pensionablepay" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Netpay" + "\t\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Grosspay" + "\t" + txtEmpID.Text + "\n");
            rtPayslip.AppendText("\t\t" + "Deduction" + "\t" + txtEmpID.Text + "\n");


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtEmpID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtSurname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtaddress.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                combogender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtmobile.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtcityweighting.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtbasicsalary.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txtovertime.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtotherpayment.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txttax.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                txtpension.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                txtstudentloan.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                txtNIPayment.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                txttaxperiod.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                txttaxcode.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                txtNIPeriod.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                txtNICode.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                txttaxablepay.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                txtpensionablepay.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                txtnetpay.Text = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                txtgrosspay.Text = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                txtdeduction.Text = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnsample_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmpID.Text = "501";
                txtFirstname.Text = "Anita";
                txtSurname.Text = "Maam";
                txtaddress.Text = "Koramangala 5th Block";
                txtmobile.Text = "1234567890";
                txtcityweighting.Text = "90";
                txtbasicsalary.Text = "150";
                txtovertime.Text = "25";
                txtotherpayment.Text = "75";
                txttaxcode.Text = "TCIN008912";
                txttaxperiod.Text = "3";
                txtNIPeriod.Text = "TNIP008955";
                txtNICode.Text = "TNCT008999";
                combogender.Text = "Female";
                txttax.Text = "";
                txtpension.Text = "";
                txtstudentloan.Text = "";
                txtNIPayment.Text = "";
                txttaxablepay.Text = "";
                txtpensionablepay.Text = "";
                txtnetpay.Text = "";
                txtgrosspay.Text = "";
                txtdeduction.Text = "";
                txtsearch.Text = "";
                dateTimePicker1.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

