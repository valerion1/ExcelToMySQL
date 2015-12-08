using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;

namespace excel_to_mysql
{
    public class ToMySQL
    {
        private MySqlConnection connect;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private DataTable dataTable;
        private DirectoryInfo directory;

        private struct ConnectConfig
        {
            public static string server;
            public static string user;
            public static string password;
            public static string database;            
        }
        public bool IsConnected { get; private set; }

        public ToMySQL()
        {
            command = new MySqlCommand();
            dataTable = new DataTable();
            connect = new MySqlConnection();
            IsConnected = false;
        }

        public void Connect(string server, string user, string password, string database)
        {
            ConnectConfig.server = server;
            ConnectConfig.user = user;
            ConnectConfig.password = password;
            ConnectConfig.database = database;

            try
            {
                IsConnected = false;
                connect.Close();
                string connectString = @"server=" + ConnectConfig.server + ";userid=" + ConnectConfig.user + ";password=" + ConnectConfig.password +
                                        ";database=" + ConnectConfig.database + ";Allow User Variables=true;";
                connect.ConnectionString = connectString;

                connect.Open();

                if (connect.State == ConnectionState.Open)
                {
                    command.Connection = connect;
                    IsConnected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка подключения #1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Disconnect()
        {
            IsConnected = false;
            ConnectConfig.server = "";
            ConnectConfig.user = "";
            ConnectConfig.password = "";
            ConnectConfig.database = "";
            try
            {
                connect.Close();
                command.CommandText = "";
                //reader.Close();
                dataTable.Clear();
                dataTable.Columns.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка подключения #2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public DataTable DataSource(string table)
        {
            try
            {
                Connect(ConnectConfig.server, ConnectConfig.user, ConnectConfig.password, ConnectConfig.database);
                command.CommandText = @"SELECT * FROM " + table + ";";
                reader = command.ExecuteReader();
                dataTable.Clear();
                dataTable.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return dataTable;
        }

        public void AddTable(DataTable addTable, string tableName)
        {
            string path = GenerateTxt(addTable, tableName);
            string columns = "";
            try
            {
                for (int i = 0; i < addTable.Columns.Count; i++)
                    columns += ", column" + (i + 1) + " varchar(30)";

                Connect(ConnectConfig.server, ConnectConfig.user, ConnectConfig.password, ConnectConfig.database);


                command.CommandText = @"CREATE TABLE " + tableName + " ( id int(11) NOT NULL AUTO_INCREMENT" + columns + ", PRIMARY KEY(id));LOAD DATA LOCAL INFILE '" + path + "' INTO TABLE " + tableName + " FIELDS TERMINATED BY ',' LINES TERMINATED BY '\r\n'";
                reader = command.ExecuteReader();
                File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                File.Delete(path);
            }
        }

        private string GenerateTxt(DataTable addTable, string tableName)
        {
            string path = "";
            try
            {
                //if (!Directory.Exists(@"log"))
                    //directory = Directory.CreateDirectory(@"log");

                string str = "";
                for (int i = 0; i < addTable.Rows.Count; i++)
                {
                    str += "0,";//i + ",";
                    for (int j = 0; j < addTable.Columns.Count; j++)
                        str += addTable.Rows[i][j].ToString() + ",";
                    str += "\r\n";
                }

                //path = Environment.CurrentDirectory.Replace('\\', '/') + "/log/" + DateTime.Now.ToString().Replace(':', '.') + " " + tableName + ".txt";

                path = Environment.CurrentDirectory.Replace('\\', '/') + "/temp.txt";

                using (FileStream fs = File.Create(@"" + path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(str);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Что-то пошло не так...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return path;
        }

    }
}