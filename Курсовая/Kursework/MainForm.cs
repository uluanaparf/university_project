using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            // Закройте вторую форму. Это вызовет событие FormClosed.
            this.Close();
        }
        private void createMatrixButton_Click(object sender, EventArgs e)
        {
            // Проверка корректности введенных данных.
            if (int.TryParse(textBoxRow.Text, out int rows) && int.TryParse(textBoxColum.Text, out int columns))
            {
                // Создание новой формы с матрицей и передача параметров.
                MatrixForm matrixForm = new MatrixForm(rows, columns);
                matrixForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введите корректные значения для строк и столбцов.");
            }
        }

    }
}
