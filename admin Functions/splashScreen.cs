﻿using System;
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
    public partial class splashScreen : MetroFramework.Forms.MetroForm
    {
        int progress = 0;

        public splashScreen()
        {
            InitializeComponent();
        }

        private void splashScreen_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 30;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress >= 100)
            {
                timer1.Enabled = false;
                timer1.Stop();
                this.Hide();
                Login f = new Login();
                f.Show();
            }
         
            metroProgressSpinner1.Value = progress;
            metroProgressBar1.Value = progress;
            metroLabel1.Text= "Loading...  " + progress + "%";
        }


    }
}
