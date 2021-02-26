using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Login : Form
    {
        public Point pt = new Point();
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "admin")
            {
                if (txtpwd.Text == "admin")
                {
                    frmmain win = new frmmain();
                    this.Hide();
                    win.ShowDialog();
                }
                else
                {
                    lblerror.Text = "Enter valid password";
                    txtpwd.Focus();
                    txtpwd.SelectAll();
                }
            }
            else
            {
                lblerror.Text = "Enter valid username";
                txtuser.Focus();
                txtuser.SelectAll();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            pt.X = e.X;
            pt.Y = e.Y;
        }

        private void Login_MouseMove_1(object sender, MouseEventArgs e)
        {
            string temp = e.Button.ToString();
            if (temp == "Left")
            {
                this.Location = new Point(this.Left - (pt.X - e.X), this.Top - (pt.Y - e.Y));
            }
        }
    }
}