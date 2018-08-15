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

namespace AttendanceRecorder
{
    public partial class AttendenceRecorder : Form
    {
        public AttendenceRecorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {
                String employeeID = txtEmployeeID.Text;

                DBConnect db = new DBConnect();
                String date = DateTime.Now.ToString("yyyy-MM-dd");
                String time = DateTime.Now.ToString("HH:mm");

                String q = "INSERT INTO employee_attendance(employeeNo,date,inTime) VALUES('" + employeeID + "','" + date + "','" + time + "')";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");
                txtEmployeeID.Clear();
                txtEmployeeID.Focus();
                
            }
            else
            {
                MessageBox.Show("Scan your ID first");
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text.Length == 8)
            {
                Console.Beep(1000, 400);
                btnIn.Focus();
            }
        }

        private void AttendenceRecorder_Load(object sender, EventArgs e)
        {
            txtEmployeeID.Focus();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {
                String employeeID = txtEmployeeID.Text;

                DBConnect db = new DBConnect();
                String date = DateTime.Now.ToString("yyyy-MM-dd");
                String time = DateTime.Now.ToString("HH:mm");

                String q = "update employee_attendance SET outTime = '"+time+"' where employeeNo = '"+employeeID+"' and date = '"+date+"'";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");
                txtEmployeeID.Clear();
                txtEmployeeID.Focus();
                    

            }
            else
            {
                MessageBox.Show("Scan your ID first");
            }
        }
    }
}
