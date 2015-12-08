using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel_to_mysql;
using System.Threading;

namespace excel_to_mysql
{
    public partial class Settings : Form
    {

        public ToMySQL ToMSQL { get; private set; }
        public bool ResultConeccting { get; private set; }
        private BackgroundWorker worker1;
        private Microsoft.Win32.RegistryKey regKey;
        

        public Settings()
        {
            InitializeComponent();
            ToMSQL = new ToMySQL();
            worker1 = new BackgroundWorker();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            string name,user,password,database;
            GetRegistry(out name, out user, out password, out database);
            serverNameBox.Text = name;
            userNameBox.Text = user;
            passwordBox.Text = password;
            databaseBox.Text = database;

            serverNameBox.TextChanged += Box_TextChanged;
            userNameBox.TextChanged += Box_TextChanged;
            passwordBox.TextChanged += Box_TextChanged;
            databaseBox.TextChanged += Box_TextChanged;

            connectBut.Click += connectBut_Click;

            worker1.DoWork += worker1_DoWork;
            worker1.RunWorkerCompleted += worker1_RunWorkerCompleted;
        }

        private void Box_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            pictureBox1.Visible = false;
        }

        private void worker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            if(ToMSQL.IsConnected)
            {
                pictureBox1.Image = excel_to_mysql.Properties.Resources.green_tick_simple;
                pictureBox1.Visible = true;
                label5.Visible = true;
                ResultConeccting = true;
                label5.ForeColor = Color.Green;
                label5.Text = "Connection successfully!";
                Task.Run(() => Thread.Sleep(1100)).Wait();
                this.Close();
            }
            else
            {
                pictureBox1.Image = excel_to_mysql.Properties.Resources.delete_128x128;
                pictureBox1.Visible = true;
                label5.Visible = true;
                ResultConeccting = false;
                label5.ForeColor = Color.Red;
                label5.Text = "Connection fails!";
            }
        }

        private void worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ToMSQL.Connect(serverNameBox.Text, userNameBox.Text, passwordBox.Text, databaseBox.Text);
        }

        private void connectBut_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            pictureBox1.Visible = false;
            try
            {
                if (!worker1.IsBusy)
                    worker1.RunWorkerAsync();

                if (saveCheck.Checked)
                {
                    string path = @"Software\ExcelToMySQL\settings";
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path, true);

                    if (regKey == null)
                    {
                        regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(path);
                        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path, true);
                        regKey.SetValue("ip", serverNameBox.Text);
                        regKey.SetValue("name", userNameBox.Text);
                        regKey.SetValue("password", passwordBox.Text);
                        regKey.SetValue("database", databaseBox.Text);
                        regKey.Close();
                    }
                    else
                    {
                        regKey.SetValue("ip", serverNameBox.Text);
                        regKey.SetValue("name", userNameBox.Text);
                        regKey.SetValue("password", passwordBox.Text);
                        regKey.SetValue("database", databaseBox.Text);
                        regKey.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Что-то пошло не так...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetRegistry(out string name, out string user, out string password, out string database)
        {
            name = "";
            user = "";
            password = "";
            database = "";
            string path = @"Software\ExcelToMySQL\settings";
            try
            {
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path, true);
                if (regKey != null)
                {
                    string[] keys = regKey.GetValueNames();
                    if (keys.Length != 0)
                    {
                        foreach (string str in keys)
                        {
                            switch (str)
                            {
                                case "ip":
                                    name = regKey.GetValue("ip").ToString();
                                    break;
                                case "name":
                                    user = regKey.GetValue("name").ToString();
                                    break;
                                case "password":
                                    password = regKey.GetValue("password").ToString();
                                    break;
                                case "database":
                                    database = regKey.GetValue("database").ToString();
                                    break;
                            }
                        }
                        regKey.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Что-то пошло не так...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }
    }
}
