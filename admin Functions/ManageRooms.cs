using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceRecorder
{
    public partial class ManageRooms : MetroFramework.Forms.MetroForm
    {
        public ManageRooms()
        {
            InitializeComponent();
        }

        private void ManageRooms_Load(object sender, EventArgs e)
        {

        }
        private void retieve()
        {
            DBConnect db = new DBConnect();

        }

    }
}
