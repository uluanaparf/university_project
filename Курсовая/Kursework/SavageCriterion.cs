using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursework
{


    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public class SavageSolver
    {
        public static int FindBestStrategy(DataGridView dataGridView)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
            {
                throw new ArgumentException("Неправильно заполнена таблица");
            }

            int rowCount = (dataGridView.Rows.Count-1);
            int colCount = dataGridView.Columns.Count;

            // Создаем массив для хранения максимальных значений в каждом столбце
            double[] maxValues = new double[colCount];

            // Находим максимальные значения в каждом столбце
            for (int j = 0; j < colCount; j++)
            {
                double maxValue = double.MinValue;

                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null &&
                        double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double cellValue))
                    {
                        if (cellValue > maxValue)
                        {
                            maxValue = cellValue;
                        }
                    }
                }

                maxValues[j] = maxValue;
            }

            // Отнимаем максимальные значения от каждого элемента в соответствующем столбце
            for (int j = 0; j < colCount; j++)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null &&
                        double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double cellValue))
                    {
                        dataGridView.Rows[i].Cells[j].Value = maxValues[j]-cellValue;
                    }
                }
            }

            // Находим стратегию, минимизирующую максимальные потери
            double[] maxRowValues = new double[rowCount];

            // Находим максимальные значения в каждой строке
            for (int i = 0; i < rowCount; i++)
            {
                double maxRowValue = double.MinValue;

                for (int j = 0; j < colCount; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null &&
                        double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double cellValue))
                    {
                        if (cellValue > maxRowValue)
                        {
                            maxRowValue = cellValue;
                        }
                    }
                }

                maxRowValues[i] = maxRowValue;
            }

            // Находим максимальное значение в массиве максимальных значений строк
            double minMaxRowValue = double.MaxValue;
            int bestStrategy = -1;

            for (int i = 0; i < rowCount; i++)
            {
                if (maxRowValues[i] < minMaxRowValue)
                {
                    minMaxRowValue = maxRowValues[i];
                    bestStrategy = i+1;
                }
            }

            return bestStrategy;
            }
        }
    }



