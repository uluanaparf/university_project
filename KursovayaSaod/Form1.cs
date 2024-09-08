using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovayaSaod
{
    unsafe public partial class Form1 : Form
    {
        private LinkedList<Node> linkedList = new LinkedList<Node>();

        private void Data(Node node)
        {
            node.Surname = textBox1.Text;
            node.Name = textBox2.Text;
            node.Patronimyc = textBox3.Text;
            node.Group = textBox4.Text;
        }
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            textBox1.Select();
        }

        private void AddNodeClick(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                Node node = new Node();
                Data(node);
                linkedList.Add(node);
                textBox5.Paste("Студент : " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " +
                "группы " + textBox4.Text + " добавлен\r\n");
            }
            else
            {
                textBox5.Paste("Заполните все поля для ввода данных\r\n");
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Find(object sender, EventArgs e)
        {
            Node node = new Node();
            Data(node);
            bool isPresent = linkedList.Contains(node);
            textBox5.Text = isPresent == true ? "Студент присутствует в списке" : "Студент отсутствует в списке";
        }

        private void Delete(object sender, EventArgs e)
        {
            Node node = new Node();
            Data(node);
            if (linkedList.Contains(node))
            {

                linkedList.Remove(node);
                textBox5.Paste("Студент : " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text +
                     " группы " + textBox4.Text + " удален\r\n");
            }
            else
            {
                textBox5.Paste("Такого студента нет\r\n");
            }
        }

        private void ClearList(object sender, EventArgs e)
        {
            linkedList.Clear();
            textBox5.Text = "Список очищен";
        }

        private void PrintAll(object sender, EventArgs e)
        {
            textBox5.Clear();
            //linkedList.Sort();
            textBox5.Paste($"Весь список:{"\r\n"}{linkedList.PrintAll(linkedList)} {"\r\n"}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Paste($"Студент(ы) группы {textBox4.Text}  {"\r\n"}{linkedList.PrintByGroup(linkedList, textBox4.Text)} {"\r\n"}");
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            Node node = new Node();
            Data(node);
            if (linkedList.Contains(node))
                linkedList.RemoveFirst(node);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Node node = new Node();
            Data(node);
            linkedList.RemoveF(node);
        }
    }


}
