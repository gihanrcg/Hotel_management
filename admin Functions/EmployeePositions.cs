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
    public partial class EmployeePositions : Form
    {
        String id;
        int id1;
        int delete_id;

        public EmployeePositions()
        {
            InitializeComponent();
        }

        private void EmployeePositions_Load(object sender, EventArgs e)
        {

          
            DBConnect db = new DBConnect();
            MySqlCommand cmd = db.con.CreateCommand();
            cmd.CommandText = "select * from employeesalarydetails";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgvEmployeePositions.DataSource = dt;
        }

        private DataTable loadPositions()
        {
            DataTable dt = new DataTable();;
            DBConnect db = new DBConnect();
            String q = "select * from employeesalarydetails";
            MySqlCommand cmd = new MySqlCommand(q, db.con);
            MySqlDataReader r = cmd.ExecuteReader();

            dt.Load(r);
            return dt;
        }

        private void dgvEmployeePositions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvEmployeePositions.Rows[e.RowIndex].Cells["id"].Value.ToString();

        }
    }
}
