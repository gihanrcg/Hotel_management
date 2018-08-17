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
using System.IO;

namespace AttendanceRecorder
{
    public partial class EmployeeProfile : MetroFramework.Forms.MetroForm
    {

        String employeeID = null;
        String password = null;

        public EmployeeProfile(String EmployeeID)
        {
            this.employeeID = EmployeeID;
            InitializeComponent();
        }

        private void EmployeeProfile_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            String q = "Select name,nic,address,contactHome,contactMobile,image,password from employee where employeeNo = '" + employeeID + "'";
            MySqlCommand cmd = new MySqlCommand(q, db.con);

            MySqlDataReader r = cmd.ExecuteReader();

            try
            {
                while (r.Read())
                {
                    txtEmployeeID.Text = employeeID;
                    txtName.Text = r[0].ToString();
                    txtNic.Text = r[1].ToString();
                    txtAddress.Text = r[2].ToString();
                    txtHome.Text = r[3].ToString();
                    txtMobile.Text = r[4].ToString();
                    password = r[6].ToString();
                    byte[] img = (byte[])(r[5]);

                    if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(img);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword f = new ChangePassword(employeeID, password);
            f.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {           
            if ((txtMobile.Text .Length == 10) && (txtAddress.Text != ""))
            {
                DialogResult d = MessageBox.Show("Are you sure you want to update details...?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (d == DialogResult.Yes)
                {
                    DBConnect db = new DBConnect();
                    String q = "update employee set address = '" + txtAddress.Text + "',contactHome = '" + txtHome.Text + "',contactMobile='" + txtMobile.Text + "' where employeeNo ='" + employeeID + "'";
                    MySqlCommand cmd = new MySqlCommand(q,db.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mobile no and Address Can not be empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
            
        }


    }
}
