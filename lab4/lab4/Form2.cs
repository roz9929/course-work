using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    struct Department
    {
        public string FIO;
        public string Addres;
        public string Name;
        public int TeacherCount;
        public Department(string f, string a, string n, int t)//конструктор
        {
            FIO = f;
            Addres = a;
            TeacherCount = t;
            Name = n;
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Название кафедры";
            dataGridView1.Columns[1].HeaderText = "ФИО зав.каф.";
            dataGridView1.Columns[2].HeaderText = "Количество преподавателей";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].HeaderText = "Название кафедры";
            dataGridView2.Columns[1].HeaderText = "ФИО зав.каф.";
            dataGridView2.Columns[2].HeaderText = "Количество преподавателей";
            dataGridView2.Columns[3].HeaderText = "Адрес";
            dataGridView2.RowHeadersVisible = false;

        }
        Department[] department = new Department[10];
        int cout = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            department[cout].Name = textBox1.Text;
            department[cout].FIO = textBox2.Text;
            department[cout].TeacherCount = Convert.ToInt32(numericUpDown1.Text);
            department[cout].Addres = textBox4.Text;
            dataGridView1.Rows.Add(department[cout].Name, department[cout].FIO, department[cout].TeacherCount, department[cout].Addres);
            cout++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int select = Convert.ToInt32(textBox3.Text);
            foreach (Department wSel in department)
            {
                if (wSel.TeacherCount > select)
                    dataGridView2.Rows.Add(wSel.Name, wSel.FIO, wSel.TeacherCount, wSel.Addres);
            }
        }

        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void выполнитьЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
