using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsApplication1
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        public string tempadd;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s = new string[50];
                string[] tmp = new string[50];
                string[] s1 = new string[50];
                for (int i = 0; i < Directory.GetDirectories("d:\\").Length; i++)
                {
                    s1 = Directory.GetDirectories("d:\\");
                }
                for (int j = 0; j < s1.Length; j++)
                {
                    for (int i = 0; i < Directory.GetFiles(s1[i]).Length; i++)
                    {
                        s = Directory.GetFiles(s1[i]);
                    }
                }
                for (int i = 0; i < Directory.GetFiles(s1[i]).Length; i++)
                {
                    label1.Text += s[i];
                }
            }
            catch
            {
                MessageBox.Show("An error has been occured for a specific reason...");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] drive = new string[Environment.GetLogicalDrives().Length];
                drive = Environment.GetLogicalDrives();

                for (int i = 0; i < Environment.GetLogicalDrives().Length; i++)
                {
                    lbdrive.Items.Add(drive[i].ToString().Remove(drive[i].Length-1));
                }
            }
            catch
            {
                MessageBox.Show("An error has been occured for a specific reason...");
            }
        }

        private void lbdrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbfolder.Items.Clear();
                string[] dir = new string[Directory.GetDirectories(lbdrive.SelectedItem.ToString()).Length];
                dir = Directory.GetDirectories(lbdrive.SelectedItem.ToString());

                for (int i = 0; i < dir.Length; i++)
                {
                    string[] tmp = new string[dir[i].ToString().Split(':').Length];
                    tmp = dir[i].ToString().Split(':');
                    lbfolder.Items.Add(tmp[tmp.Length - 1]);
                }

                lbfile.Items.Clear();
                string[] file = new string[Directory.GetFiles(lbdrive.SelectedItem.ToString()).Length];
                file = Directory.GetFiles(lbdrive.SelectedItem.ToString());

                for (int i = 0; i < file.Length; i++)
                {
                    string[] tmp = new string[file[i].ToString().Split(':').Length];
                    tmp = file[i].ToString().Split(':');
                    lbfile.Items.Add(tmp[tmp.Length - 1]);
                }
                txtadd.Text = "";
                txtadd.Text = this.lbdrive.SelectedItem.ToString();
                chk();

                if (txtadd.Text.Length<=2)
                {
                    this.linkLabel1.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Drive may virtual or disk not exits...","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void chk()
        {
            if (txtadd.Text.Length <= 2)
            {
                this.linkLabel1.Enabled = false;
            }
            else
            {
                this.linkLabel1.Enabled = true;
            }
        }

        private void lbfolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbfile.Items.Clear();
                string[] file = new string[Directory.GetFiles(txtadd.Text + "\\" + lbfolder.SelectedItem.ToString()).Length];
                file = Directory.GetFiles(txtadd.Text + "\\" + lbfolder.SelectedItem.ToString());

                for (int i = 0; i < file.Length; i++)
                {
                    string[] tmp = new string[file[i].ToString().Split('\\').Length];
                    tmp = file[i].ToString().Split('\\');
                    lbfile.Items.Add(tmp[tmp.Length-1]);
                }
                
                txtadd.Text += "\\" + this.lbfolder.SelectedItem.ToString();
                chk();

                string[] dir = new string[Directory.GetDirectories(txtadd.Text).Length];
                dir = Directory.GetDirectories(txtadd.Text);
                lbfolder.Items.Clear();
                for (int i = 0; i < dir.Length; i++)
                {
                    string[] tmp = new string[dir[i].ToString().Split('\\').Length];
                    tmp = dir[i].ToString().Split('\\');
                    lbfolder.Items.Add(tmp[tmp.Length - 1]);
                }
            }
            catch
            {
                MessageBox.Show("An error has been occured for a specific reason...");
            }

        }

        private void lbfile_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
             {
                chk();

                ProcessStartInfo psi = new ProcessStartInfo();
                object RN = lbdrive.SelectedItem;
                psi.FileName = txtadd.Text + "\\" + lbfile.SelectedItem.ToString();
                Process.Start(psi);
             }
            catch
            {
                MessageBox.Show("An error has been occured for a specific reason...");
            }
        }

        private void frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                

                lbfile.Items.Clear();
                string[] split = txtadd.Text.Split('\\');
                txtadd.Text = "";
                for (int i = 0; i < split.Length - 1;i++ )
                {
                    if (i == split.Length - 2)
                    {
                        txtadd.Text += split[i].ToString();
                    }
                    else
                    {
                        txtadd.Text += split[i].ToString() + "\\";
                    }
                }
                chk();

                string[] file = new string[Directory.GetFiles(txtadd.Text).Length];
                file = Directory.GetFiles(txtadd.Text);

                for (int i = 0; i < file.Length; i++)
                {
                    string[] tmp = new string[file[i].ToString().Split('\\',':').Length];
                    tmp = file[i].ToString().Split('\\',':');
                    lbfile.Items.Add(tmp[tmp.Length - 1]);
                }

                string[] dir = new string[Directory.GetDirectories(txtadd.Text).Length];
                dir = Directory.GetDirectories(txtadd.Text);
                lbfolder.Items.Clear();
                for (int i = 0; i < dir.Length; i++)
                {
                    string[] tmp = new string[dir[i].ToString().Split('\\',':').Length];
                    tmp = dir[i].ToString().Split('\\',':');
                    lbfolder.Items.Add(tmp[tmp.Length - 1]);
                }
                
            }
            catch
            {
                MessageBox.Show("An error has been occured for a specific reason...");
            }

        }
    }
}