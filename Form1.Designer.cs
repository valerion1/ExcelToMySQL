namespace excel_to_mysql
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySQLСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.labelDataGridExcel = new System.Windows.Forms.Label();
            this.addTableBut = new System.Windows.Forms.Button();
            this.labelDataGridMySQL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(544, 437);
            this.dataGridView1.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.Location = new System.Drawing.Point(54, 474);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1173, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1,
            this.закрытьToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.открытьToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem1.Text = "Открыть";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mySQLСерверToolStripMenuItem,
            this.отключениеToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.настройкиToolStripMenuItem.Text = "Соединение";
            // 
            // mySQLСерверToolStripMenuItem
            // 
            this.mySQLСерверToolStripMenuItem.Name = "mySQLСерверToolStripMenuItem";
            this.mySQLСерверToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.mySQLСерверToolStripMenuItem.Text = "MySQL Сервер";
            this.mySQLСерверToolStripMenuItem.Click += new System.EventHandler(this.mySQLСерверToolStripMenuItem_Click);
            // 
            // отключениеToolStripMenuItem
            // 
            this.отключениеToolStripMenuItem.Name = "отключениеToolStripMenuItem";
            this.отключениеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.отключениеToolStripMenuItem.Text = "Отключение";
            this.отключениеToolStripMenuItem.Click += new System.EventHandler(this.отключениеToolStripMenuItem_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(578, 31);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(523, 435);
            this.dataGridView2.TabIndex = 9;
            // 
            // labelDataGridExcel
            // 
            this.labelDataGridExcel.AutoSize = true;
            this.labelDataGridExcel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelDataGridExcel.Font = new System.Drawing.Font("Malgun Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDataGridExcel.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.labelDataGridExcel.Location = new System.Drawing.Point(61, 175);
            this.labelDataGridExcel.Name = "labelDataGridExcel";
            this.labelDataGridExcel.Size = new System.Drawing.Size(53, 72);
            this.labelDataGridExcel.TabIndex = 10;
            this.labelDataGridExcel.Text = "*";
            this.labelDataGridExcel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addTableBut
            // 
            this.addTableBut.Enabled = false;
            this.addTableBut.Location = new System.Drawing.Point(611, 474);
            this.addTableBut.Name = "addTableBut";
            this.addTableBut.Size = new System.Drawing.Size(171, 23);
            this.addTableBut.TabIndex = 11;
            this.addTableBut.Text = "Добавить таблицу в БД";
            this.addTableBut.UseVisualStyleBackColor = true;
            // 
            // labelDataGridMySQL
            // 
            this.labelDataGridMySQL.AutoSize = true;
            this.labelDataGridMySQL.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelDataGridMySQL.Font = new System.Drawing.Font("Malgun Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDataGridMySQL.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.labelDataGridMySQL.Location = new System.Drawing.Point(680, 175);
            this.labelDataGridMySQL.Name = "labelDataGridMySQL";
            this.labelDataGridMySQL.Size = new System.Drawing.Size(53, 72);
            this.labelDataGridMySQL.TabIndex = 12;
            this.labelDataGridMySQL.Text = "*";
            this.labelDataGridMySQL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 563);
            this.Controls.Add(this.labelDataGridMySQL);
            this.Controls.Add(this.addTableBut);
            this.Controls.Add(this.labelDataGridExcel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcelToMySQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label labelDataGridExcel;
        private System.Windows.Forms.Button addTableBut;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySQLСерверToolStripMenuItem;
        private System.Windows.Forms.Label labelDataGridMySQL;
        private System.Windows.Forms.ToolStripMenuItem отключениеToolStripMenuItem;
    }
}

