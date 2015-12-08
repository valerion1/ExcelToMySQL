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
    class FromExcel
    {
        private string fileName;
        private OleDbConnection connect;
        private DataTable schemaTable;
        private OleDbDataAdapter dataAdapter;
        private DataTable dataTable;
        private OpenFileDialog openFileDialog;

        private string pathCon;

        public bool FileIsOpen { get; private set; }

        public FromExcel()
        {
            openFileDialog = new OpenFileDialog();
            Sheets = new List<string>();
            dataTable = new DataTable();
            connect = new OleDbConnection();
            FileIsOpen = false;
        }

        public List<string> Sheets { get; private set; }
        public OleDbDataReader Reader { get; private set; }

        public void OpenExcelFile()
        {
            try
            {
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Filter = "файл Excel|*.XLSX;*.XLS";
                openFileDialog.FileName = "";
                openFileDialog.ShowDialog();

                if (openFileDialog.FileName.ToLower().Contains(".xlsx"))
                {
                    fileName = openFileDialog.FileName;
                    //HDR = true в подключении, имя столбца - первая строка excel
                    pathCon = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;extended properties=\"excel 8.0;hdr=no;IMEX=1\";data source={0}", fileName);
                    FileIsOpen = true;
                    return;
                }
                else if (openFileDialog.FileName.ToLower().Contains(".xls"))
                {
                    fileName = openFileDialog.FileName;
                    pathCon = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;extended properties=\"excel 8.0;hdr=no;IMEX=1\";data source={0}", fileName);
                    FileIsOpen = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения файла #1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            FileIsOpen = false;
        }

        public void OpenExcelFile(string path)
        {
            try
            {

                if (path.ToLower().Contains(".xlsx"))
                {
                    openFileDialog.FileName = path;
                    fileName = openFileDialog.FileName;
                    //HDR = true в подключении, имя столбца - первая строка excel
                    pathCon = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;extended properties=\"excel 8.0;hdr=no;IMEX=1\";data source={0}", fileName);
                    FileIsOpen = true;
                    return;
                }
                else if (path.ToLower().Contains(".xls"))
                {
                    openFileDialog.FileName = path;
                    fileName = openFileDialog.FileName;
                    pathCon = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;extended properties=\"excel 8.0;hdr=no;IMEX=1\";data source={0}", fileName);
                    FileIsOpen = true;
                    return;
                }
                else throw new Exception("Неверный формат файла!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения файла #2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            FileIsOpen = false;
        }

        public void Connect()
        {
            try
            {
                connect.Close();
                //HDR = true в подключении, имя столбца - первая строка excel
                //string pathCon = "Provider=Microsoft.ACE.OLEDB.12.0;extended properties=\"excel 8.0;hdr=no;IMEX=1\";data source={0}";
                connect.ConnectionString = pathCon;
                connect.Open();

                Sheets.Clear();

                //Листы из excel
                schemaTable = connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { });

                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    string str = schemaTable.Rows[i].ItemArray[2].ToString();
                    Sheets.Add(str.Substring(0, str.Length - 1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения файла #3", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (FileIsOpen)
                {
                    FileIsOpen = false;
                    Sheets.Clear();
                    dataTable.Clear();
                    connect.Close();
                    schemaTable.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения файла #4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public DataTable DataSource()
        {
            try
            {
                if (dataAdapter == null)
                    dataAdapter = new OleDbDataAdapter("Select * from [" + Sheets[0].ToString() + "$]", connect);
                else 
                    dataAdapter.SelectCommand.CommandText = "Select * from [" + Sheets[0].ToString() + "$]";

                dataTable.Clear();
                dataTable.Columns.Clear();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения данных #1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return dataTable;
        }

        public DataTable DataSource(string sheet)
        {
            try
            {
                if (dataAdapter == null)
                    dataAdapter = new OleDbDataAdapter("Select * from [" + sheet + "$]", connect);
                else dataAdapter.SelectCommand.CommandText = "Select * from [" + sheet + "$]";              
                //dataAdapter = new OleDbDataAdapter("Select * from [" + comboBox1.Text + "$]", connect);
                dataTable.Columns.Clear();
                dataTable.Clear();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения данных #2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return dataTable;
        }
    }
}