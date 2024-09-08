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

    public class BayesSolver
    {
        public static int FindBestStrategy(DataGridView dataGridView, DataGridView dataGridViewProbabilities)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
            {
                throw new ArgumentException("Неверно задана таблица");
            }

            if (dataGridViewProbabilities == null || dataGridViewProbabilities.Rows.Count != 1 || dataGridViewProbabilities.Columns.Count != dataGridView.Columns.Count)
            {
                throw new ArgumentException("Неверно введены вероятности");
            }

            int rowCount = dataGridView.Rows.Count-1;
            int colCount = dataGridView.Columns.Count;

            // Инициализируем массив для хранения суммы вероятностей умноженных на значения в каждой строке
            double[] sumProbabilities = new double[rowCount];

            // Читаем вероятности из DataGridViewProbabilities
            double[] probabilities = new double[colCount];

            for (int j = 0; j < colCount; j++)
            {
                if (dataGridViewProbabilities.Rows[0].Cells[j].Value != null &&
                    double.TryParse(dataGridViewProbabilities.Rows[0].Cells[j].Value.ToString(), out double probability))
                {
                    probabilities[j] = probability;
                }
                else
                {
                    throw new ArgumentException($"Invalid probability value in column {j}");
                }
            }

            // Рассчитываем сумму вероятностей умноженных на значения в каждой строке
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null &&
                        double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double cellValue))
                    {
                        sumProbabilities[i] += cellValue * probabilities[j];
                    }
                }
            }

            // Находим стратегию с максимальной суммой
            double maxSumProbability = double.MinValue;
            int bestStrategy = -1;

            for (int i = 0; i < rowCount; i++)
            {
                if (sumProbabilities[i] > maxSumProbability)
                {
                    maxSumProbability = sumProbabilities[i];
                    bestStrategy = i+1;
                }
            }

            return bestStrategy;
        }
    }


}
