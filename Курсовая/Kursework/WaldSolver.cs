using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursework
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public class WaldSolver
    {
        public static int FindBestStrategy(DataGridView dataGridView)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
            {
                throw new ArgumentException("Неверно построена таблица");
            }

            int rowCount = dataGridView.Rows.Count-1;
            int colCount = dataGridView.Columns.Count;

            // Создаем массив для хранения минимальных значений в каждой строке
            double[] minValuesInRows = new double[rowCount];

            // Находим минимальные значения в каждой строке
            for (int i = 0; i < rowCount; i++)
            {
                double minValueInRow = double.MaxValue;

                for (int j = 0; j < colCount; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null &&
                        double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double cellValue))
                    {
                        if (cellValue < minValueInRow)
                        {
                            minValueInRow = cellValue;
                        }
                    }
                }

                minValuesInRows[i] = minValueInRow;
            }

            // Находим максимальное минимальное значение в строках
            double maxMinValue = double.MinValue;
            int bestStrategy = -1;

            for (int i = 0; i < rowCount; i++)
            {
                if (minValuesInRows[i] > maxMinValue)
                {
                    maxMinValue = minValuesInRows[i];
                    bestStrategy = i+1;
                }
            }

            return bestStrategy;
        }
    }

}
