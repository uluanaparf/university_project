using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursework
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public class GurvicaSolver
    {
        public static int FindBestStrategy(DataGridView dataGridView, double optimismCoefficient)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
            {
                throw new ArgumentException("Неверно заполнена таблица");
            }

            if (optimismCoefficient < 0 || optimismCoefficient > 1)
            {
                throw new ArgumentException("Коэффициент оптимизма должен быть от 0 до 1");
            }

            int rowCount = dataGridView.Rows.Count-1;
            int colCount = dataGridView.Columns.Count;

            // Создаем массив для хранения взвешенных значений в каждой строке
            double[] weightedValuesInRows = new double[rowCount];

            // Находим взвешенные значения в каждой строке
            for (int i = 0; i < rowCount; i++)
            {
                double minValueInRow = double.MaxValue;
                double maxValueInRow = double.MinValue;

                for (int j = 0; j < colCount; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null &&
                        double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double cellValue))
                    {
                        if (cellValue < minValueInRow)
                        {
                            minValueInRow = cellValue;
                        }

                        if (cellValue > maxValueInRow)
                        {
                            maxValueInRow = cellValue;
                        }
                    }
                }

                // Взвешенное значение: optimismCoefficient * maxValue + (1 - optimismCoefficient) * minValue
                weightedValuesInRows[i] = optimismCoefficient * minValueInRow + (1 - optimismCoefficient) * maxValueInRow;
            }

            // Находим стратегию с максимальным взвешенным значением
            double maxWeightedValue = double.MinValue;
            int bestStrategy = -1;

            for (int i = 0; i < rowCount; i++)
            {
                if (weightedValuesInRows[i] > maxWeightedValue)
                {
                    maxWeightedValue = weightedValuesInRows[i];
                    bestStrategy = i+1;
                }
            }

            return bestStrategy;
        }
    }

}
