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


namespace excel_to_mysql
{
    public partial class MainForm : Form
    {
        private FromExcel fExcel;
        private ToMySQL tMsql;
        private Settings settingsForm;

        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            fExcel = new FromExcel();
            settingsForm = new Settings();
            tMsql = new ToMySQL();

            #region DATA_EXCEL
            labelDataGridExcel.AllowDrop = true;
            dataGridView1.AllowDrop = true;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            labelDataGridExcel.DragDrop += dataGridView1_DragDrop;
            labelDataGridExcel.DragEnter += dataGridView1_DragEnter;
            labelDataGridExcel.Text = "Перетащите\nExcel-файл сюда";
            #endregion

            #region DATA_MYSQL
            dataGridView2.Click += dataGridView2_Click;
            labelDataGridMySQL.Click += dataGridView2_Click;
            labelDataGridMySQL.Text = "Подключите\nбазу данных";
            #endregion

            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            addTableBut.Click += addTableBut_Click;
        }

        #region FORM_EVENT
        void dataGridView2_Click(object sender, EventArgs e)
        {
            if (!settingsForm.ResultConeccting)
            {
                settingsForm.ShowDialog();
                addTableBut.Enabled = settingsForm.ResultConeccting;
                labelDataGridMySQL.Visible = !settingsForm.ResultConeccting;
            }
        }

        void addTableBut_Click(object sender, EventArgs e)
        {
            dataGridView2.SelectAll();
            dataGridView2.ClearSelection();
            tMsql.AddTable(fExcel.DataSource(comboBox1.Text), comboBox1.Text);
            dataGridView2.DataSource = tMsql.DataSource(comboBox1.Text);
        }

        void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = fExcel.DataSource(comboBox1.Text);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
               (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] obj = (string[])e.Data.GetData(DataFormats.FileDrop);
                string str = null;
                for (int i = 0; i < obj.Length; i++)
                    str += obj[i];

                fExcel.OpenExcelFile(str);
                if (fExcel.FileIsOpen)
                {
                    labelDataGridExcel.Visible = false;
                    fExcel.Connect();
                    dataGridView1.DataSource = fExcel.DataSource();
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;

                    comboBox1.Enabled = true;
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                    comboBox1.Items.AddRange(fExcel.Sheets.Distinct().ToArray());
                    comboBox1.Text = fExcel.Sheets[0];

                    addTableBut.Enabled = (settingsForm.ResultConeccting && fExcel.FileIsOpen);
                }
            }
        }
        #endregion

        #region MENU
        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fExcel.OpenExcelFile();
            if (fExcel.FileIsOpen)
            {
                labelDataGridExcel.Visible = false;
                fExcel.Connect();
                dataGridView1.DataSource = fExcel.DataSource();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;

                comboBox1.Enabled = true;
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Items.AddRange(fExcel.Sheets.Distinct().ToArray());
                comboBox1.Text = fExcel.Sheets[0];

                addTableBut.Enabled = (settingsForm.ResultConeccting && fExcel.FileIsOpen);
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = null;

            fExcel.Disconnect();
            comboBox1.Items.Clear();
            labelDataGridExcel.Visible = true;
            comboBox1.Enabled = false;
            addTableBut.Enabled = (settingsForm.ResultConeccting && fExcel.FileIsOpen);
        }

        private void mySQLСерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
            //button1.Enabled = settingsForm.ResultConeccting;
            addTableBut.Enabled = (settingsForm.ResultConeccting && fExcel.FileIsOpen);
            labelDataGridMySQL.Visible = !settingsForm.ResultConeccting;
            tMsql = settingsForm.ToMSQL;
        }

        private void отключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tMsql.IsConnected)
            {
                tMsql.Disconnect();
                addTableBut.Enabled = false;
                labelDataGridMySQL.Visible = !tMsql.IsConnected;
            }
        }
        #endregion
    }
}
