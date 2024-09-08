using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kursework
{
    public partial class MatrixForm : Form
    { 
        private DataGridView dataGridView;
        private DataGridView dataGridViewBayes;

        public MatrixForm(int row, int colums)
        {
            InitializeComponent();
            dataGridViewBayes = new DataGridView();
            dataGridViewBayes.Location = new System.Drawing.Point(groupBox1.Location.X+365, groupBox1.Location.Y-20);
            dataGridViewBayes.Size = new System.Drawing.Size(colums*115, 100);
            dataGridViewBayes.AllowUserToAddRows = false;
            Controls.Add(dataGridViewBayes);

            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            Controls.Add(dataGridView);

            // Создание и отображение матрицы.
            CreateAndDisplayMatrix(row, colums);
            buttonFile.Location = new System.Drawing.Point(10, row*35);
            groupBox1.Location = new System.Drawing.Point(colums*115, dataGridView.Location.Y+3);
            buttonSolution.Location = new System.Drawing.Point(buttonFile.Width + buttonFile.Location.X + 10, buttonFile.Location.Y);
            label1.Location = new System.Drawing.Point(buttonFile.Width + buttonFile.Location.X + buttonSolution.Width+20, buttonFile.Location.Y+15);
            textBox1.Location = new System.Drawing.Point(buttonFile.Width + buttonFile.Location.X + buttonSolution.Width + label1.Width+25, buttonFile.Location.Y + 15);
        }


        private void CreateAndDisplayMatrix(int rows, int columns)
        {
            // Создание DataTable для хранения данных матрицы.
            var dataTable = new System.Data.DataTable();

            // Добавление столбцов в DataTable.
            for (int i = 0; i < columns; i++)
            {
                dataTable.Columns.Add($"Column{i + 1}", typeof(int));
            }

            // Добавление строк в DataTable.
            for (int i = 0; i < rows; i++)
            {
                dataTable.Rows.Add();
            }

            // Назначение DataTable элементу DataGridView.
            dataGridView.DataSource = dataTable;
        }
        private void ReadExcelButton_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Выберите файл Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Чтение данных из Excel файла.
                DataTable dataTable = ReadDataFromExcel(filePath);

                // Проверка соответствия размеров матрицы и таблицы.
                if ((dataTable.Rows.Count+1) == dataGridView.Rows.Count &&
                    dataTable.Columns.Count == dataGridView.Columns.Count)
                {
                    // Запись данных в таблицу DataGridView.
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            dataGridView.Rows[i].Cells[j].Value = dataTable.Rows[i][j];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Размеры матрицы в файле Excel не соответствуют размерам таблицы.");
                }
            }
        }

        private DataTable ReadDataFromExcel(string filePath)
        {
            DataTable dataTable = new DataTable();

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            int rowCount = worksheet.UsedRange.Rows.Count;
            int colCount = worksheet.UsedRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                if (i == 1)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        dataTable.Columns.Add("Column" + j, typeof(int));
                    }
                }

                DataRow row = dataTable.NewRow();
                for (int j = 1; j <= colCount; j++)
                {
                    row[j - 1] = worksheet.Cells[i, j].Value;
                }
                dataTable.Rows.Add(row);
            }

            workbook.Close(false);
            excelApp.Quit();

            return dataTable;

        }
        
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            // Проверяем состояние CheckBox
            if (checkBox3.Checked)
            {
                // Создаем таблицу с 1 строкой и количеством столбцов, равным столбцам изначальной матрицы
                CreateBayesTable();
            }
            else
            {
                // Если CheckBox не выбран, очищаем таблицу
                dataGridViewBayes.DataSource = null;
            }
        }

        private void CreateBayesTable()
        {
            // Очищаем существующую таблицу, если она есть
            dataGridViewBayes.DataSource = null;

            // Создаем DataTable с количеством столбцов, равным столбцам изначальной матрицы
            DataTable dataTable = new DataTable();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // Добавляем пустую строку
            dataTable.Rows.Add(dataTable.NewRow());

            // Устанавливаем таблицу данных для DataGridView
            dataGridViewBayes.DataSource = dataTable;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Обработчик события изменения состояния для всех CheckBox'ов

            // Проверяем состояние каждого CheckBox и вызываем соответствующий метод
            if (checkBox1.Checked)
            {


                int decision = SavageSolver.FindBestStrategy(dataGridView);

                if (decision != -1)
                {
                    MessageBox.Show($"Лучшая стратегия по критерию Сэвиджа: {decision}");
                }
                else
                {
                    MessageBox.Show("Невозможно найти решение.Проверьте введенные данные");
                }
            }

            if (checkBox2.Checked)
            {
               

                int decision = GurvicaSolver.FindBestStrategy(dataGridView, Convert.ToDouble(textBox1.Text));

                if (decision != -1)
                {
                    MessageBox.Show($"Лучшая стратегия по критерию Гурвица: {decision}");
                }
                else
                {
                    MessageBox.Show("Невозможно найти решение.Проверьте введенные данные");
                }
            }

                if (checkBox3.Checked)
                 {
                    int decision = BayesSolver.FindBestStrategy(dataGridView,dataGridViewBayes);

                    if (decision != -1)
                    {
                        MessageBox.Show($"Лучшая стратегия по критерию Байеса: {decision}");
                    }
                    else
                    {
                        MessageBox.Show("Невозможно найти решение.Проверьте введенные данные");
                    }
                 }

                 if (checkBox4.Checked)
                 {
                    int decision = WaldSolver.FindBestStrategy(dataGridView);

                    if (decision != -1)
                    {
                        MessageBox.Show($"Лучшая стратегия по критерию Вальда: {decision}");
                    }
                    else
                    {
                        MessageBox.Show("Невозможно найти решение.Проверьте введенные данные");
                    }
                 }
            }

       
    }
}
