namespace KursovayaSaod
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 155);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(125, 27);
            this.textBox3.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 207);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(125, 27);
            this.textBox4.TabIndex = 0;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox5.Location = new System.Drawing.Point(219, 13);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(599, 310);
            this.textBox5.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OldLace;
            this.button1.Location = new System.Drawing.Point(11, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Поиск \r\nстудента\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Find);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OldLace;
            this.button2.Location = new System.Drawing.Point(129, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Удаление сдудента из \r\nсписка";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Delete);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.OldLace;
            this.button3.Location = new System.Drawing.Point(334, 352);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 50);
            this.button3.TabIndex = 1;
            this.button3.Text = "Добавление студента в\r\nсписок";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.AddNodeClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.OldLace;
            this.button4.Location = new System.Drawing.Point(11, 419);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 49);
            this.button4.TabIndex = 1;
            this.button4.Text = "Очистка списка";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ClearList);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.OldLace;
            this.button5.Location = new System.Drawing.Point(138, 419);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(190, 49);
            this.button5.TabIndex = 1;
            this.button5.Text = "Вывод списка по\r\nгруппе";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.OldLace;
            this.button6.Location = new System.Drawing.Point(334, 419);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(201, 49);
            this.button6.TabIndex = 1;
            this.button6.Text = "Вывод всего списка";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.PrintAll);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Wheat;
            this.button7.Location = new System.Drawing.Point(758, 430);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 28);
            this.button7.TabIndex = 1;
            this.button7.Text = "Выход";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.ExitApplication);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "группа";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.OldLace;
            this.button8.Location = new System.Drawing.Point(541, 352);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(201, 50);
            this.button8.TabIndex = 3;
            this.button8.Text = "Удаление студента из начала списка";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.OldLace;
            this.button9.Location = new System.Drawing.Point(541, 418);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(201, 50);
            this.button9.TabIndex = 4;
            this.button9.Text = "Удаление студента из конца списка";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(847, 509);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Shulzhenko Kyrsovaya";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

