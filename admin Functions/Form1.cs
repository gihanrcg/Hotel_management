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
using System.Globalization;
using System.IO;

namespace AttendanceRecorder
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        EncryptAndDecrypt en = new EncryptAndDecrypt();

        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        private  String loggedEmployeeID;


        public string employeeID
        {
            get { return txtEmployeeID.Text;}
            set { txtEmployeeID.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(String username,String Jobrole,String employeeID)
        {
            InitializeComponent();
            this.lblLoggedas.Text = "Logged as "+username+" : "+Jobrole;
            this.loggedEmployeeID = employeeID;
           
        }
        



        private void Form1_Load(object sender, EventArgs e)
        {
            //DBConnect db = new DBConnect();
            //String q = "SELECT * FROM employee";
            //MySqlCommand cmd = new MySqlCommand(q, db.con);
            //MySqlDataReader r = cmd.ExecuteReader();


            //if (r.HasRows == true)
            //{
            //    while (r.Read())
            //        Console.WriteLine(r[1].ToString());
            //    namesCollection.Add(r[1].ToString());
            //}
            //else
            //{
            //    MessageBox.Show("Data not found");
            //}
            //r.Close();
            //txtEmployeeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //txtEmployeeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtEmployeeName.AutoCompleteCustomSource = namesCollection; 

            //var textBox = new TextBox
            //{
                txtEmployeeName.AutoCompleteCustomSource = namesCollection;
                txtEmployeeName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtEmployeeName.AutoCompleteSource =
                    AutoCompleteSource.CustomSource;

           // };

            // Add the text box to the form.


            pnlEmployeeAttendance.Hide();
            pnlManageEmployee.Show();
            pnlViewDetailsofCustomers.Hide();


}
        
       

        private void txtContactNoHome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }


        }

        private void txtContactNoMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tileManageEmployee_Click(object sender, EventArgs e)
        {
            pnlEmployeeAttendance.Hide();
            pnlManageEmployee.Show();
            pnlViewDetailsofCustomers.Hide();

            List<String> jobs = new List<string>();

            DBConnect db = new DBConnect();

            String q = "select type from employeesalarydetails";
            MySqlCommand cmd = new MySqlCommand(q, db.con);
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                jobs.Add(r[0].ToString());
            }

            comboJobRole.DataSource = jobs;
 
        }

        private void tileEmployeeAttendance_Click(object sender, EventArgs e)
        {
            pnlEmployeeAttendance.Show();
            pnlManageEmployee.Hide();
            pnlViewDetailsofCustomers.Hide();
        }

        private void tileDetailsofCurrentCustomer_Click(object sender, EventArgs e)
        {
            pnlEmployeeAttendance.Hide();
            pnlManageEmployee.Hide();
            pnlViewDetailsofCustomers.Show();

            DBConnect db = new DBConnect();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            try
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.txtpicpath.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                DialogResult d = MessageBox.Show("Are you sure want to add this Employee..?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (d == DialogResult.Yes)
                {

                    DateTime dt = txtDatetime.Value;
                    String date = dt.ToString("yyyy-MM-dd");
                    Console.WriteLine(en.EncryptString("1234"));
                    String q = "insert into employee(name,nic,dob,address,contactHome,contactMobile,jobRole,image,password,changedBy) values ('" + txtEmployeeName.Text + "','" + txtEmployeeNIC.Text + "','" + date + "','" + txtEmployeeAddress.Text + "','" + txtContactNoHome.Text + "','" + txtContactNoMobile.Text + "','" + comboJobRole.Text + "',@IMG,'"+en.EncryptString("1234")+"','"+this.loggedEmployeeID+"')";


                    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    cmd.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Inserted Succesfully", "Done..!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    q = "SELECT * FROM employee WHERE name ='" + txtEmployeeName.Text + "'";
                    cmd = new MySqlCommand(q, db.con);
                    MySqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        txtEmployeeID.Text = r[0].ToString();

                    }
                }

            }


            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }
        }

        public void setEmployeeID(String id)
        {
            this.txtEmployeeID.Text = id;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                 DBConnect db = new DBConnect();
                 String q = "SELECT * FROM employee WHERE employeeNo ='" + txtEmployeeID.Text + "'";
                 MySqlCommand cmd = new MySqlCommand(q, db.con);
                 MySqlDataReader r = cmd.ExecuteReader();

                 if (r.HasRows)
                 {
                     while (r.Read())
                     {
                         txtEmployeeName.Text = r[1].ToString();

                         txtEmployeeNIC.Text = r[2].ToString();

                         String date = r[3].ToString();
                         txtDatetime.Value = Convert.ToDateTime(date);

                         txtEmployeeAddress.Text = r[4].ToString();

                         txtContactNoHome.Text = r[5].ToString();

                         txtContactNoMobile.Text = r[6].ToString();

                         comboJobRole.SelectedItem = r[7].ToString();

                         byte[] img = (byte[])(r[8]);

                         if (img == null)
                         {
                             picEmployeePicture.Image = null;
                         }
                         else
                         {
                             MemoryStream mstream = new MemoryStream(img);
                             picEmployeePicture.Image = System.Drawing.Image.FromStream(mstream);
                         }

                     } 
                 }
                 else
                 {
                     MessageBox.Show("No records found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }

            }
            catch (Exception ex)
            {

                
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();    

            txtEmployeeName.Clear();

            txtEmployeeNIC.Clear();

            txtDatetime.Value = DateTime.Now;

            txtEmployeeAddress.Clear();

            txtContactNoHome.Clear();

            txtContactNoMobile.Clear();

            comboJobRole.SelectedItem = "";

            picEmployeePicture.Image = null;
        }


        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            try
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.picEmployeePicture.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                DateTime dt = txtDatetime.Value;
                String date = dt.ToString("yyyy-MM-dd");

                DialogResult d = MessageBox.Show("Are you sure you want to Update this Employee..?", "Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(d == DialogResult.Yes)
                {
                    String q = "UPDATE employee SET name='" + txtEmployeeName.Text + "',nic = '" + txtEmployeeNIC.Text + "',dob ='" + date + "',address='" + txtEmployeeAddress.Text + "',contactHome='" + txtContactNoHome.Text + "',contactMobile='" + txtContactNoMobile.Text + "',jobRole='" + comboJobRole.Text + "',image=@IMG,changedBy='" + this.loggedEmployeeID +"' WHERE employeeNo='" + txtEmployeeID.Text + "'";
                    Console.WriteLine(q);
                    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    cmd.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Succesfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }

        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            try
            {
 

                DialogResult d = MessageBox.Show("Are you sure you want to Delete this Employee..?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    String q = "DELETE FROM employee WHERE employeeNo='" + txtEmployeeID.Text + "'";
                    Console.WriteLine(q);
                    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Succesfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null,null);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png)";

            if (d.ShowDialog() == DialogResult.OK)
            {
                String picpath = d.FileName.ToString();
                txtpicpath.Text = picpath;
                picpath = txtpicpath.Text;
                picEmployeePicture.ImageLocation = picpath;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text != null && txtEmployeeID.Text != "")
            {
                EmployeeIDPrint id = new EmployeeIDPrint(txtEmployeeID.Text);
                id.Show();
                
            }
            else
            {
                MessageBox.Show("Please Add the Employee or Search for the Employee. Anyway Employee ID test box should be filled with a valid Employee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanBarcode f = new ScanBarcode(this);
            f.Show();
            
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text.Length == 8)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to Logout from " + lblLoggedas.Text + "...?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (d == DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide(); 
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv.DataSource = GetEmployeeAttendence();
        }

        private DataTable GetEmployeeAttendence()
        {
            DataTable dt = new DataTable();
            DBConnect db = new DBConnect();

            String q = "select e.employeeNo as 'Employee ID',e.name as 'Name',a.date as 'Date',a.inTime as 'IN Time',a.outTime as 'Out Time',TIMEDIFF(a.outTime,a.inTime) as 'Time Worked'  from employee_attendance a, employee e where e.employeeNo = a.employeeNo";
            MySqlCommand cmd = new MySqlCommand(q, db.con);
            MySqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            return dt;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddposition_Click(object sender, EventArgs e)
        {
            EmployeePositions pos = new EmployeePositions();
            pos.Show();
        }

        private void comboJobRole_MouseClick(object sender, MouseEventArgs e)
        {
            List<String> jobs = new List<string>();

            DBConnect db = new DBConnect();

            String q = "select type from employeesalarydetails";
            MySqlCommand cmd = new MySqlCommand(q, db.con);
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                jobs.Add(r[0].ToString());
            }

            comboJobRole.DataSource = jobs;
        }

 


   


  



     


        

    }
}
