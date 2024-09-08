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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void openMainFormButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.FormClosed += MainForm_FormClosed;
            this.Hide();
            mainForm.Show();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Application.Exit();
        }

    }
}
