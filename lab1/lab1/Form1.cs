using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label8.Text = "";
            if (numericUpDown4.Value < numericUpDown5.Value)
            {
                label8.Text = "Макс значение не м.б. меньше мин значения!";
                return;
            }

            int count, current = 0;

            count = (Convert.ToInt32(numericUpDown2.Value) - Convert.ToInt32(numericUpDown1.Value)) / Convert.ToInt32(numericUpDown3.Value) + 1;
            for (int n = Convert.ToInt32(numericUpDown1.Value); n <= Convert.ToInt32(numericUpDown2.Value); n += Convert.ToInt32(numericUpDown3.Value))
            {
                int[] vptr = new int[n];
                Random rand = new Random();
                for (int j = 0; j < n; j++)
                {
                    vptr[j] = rand.Next(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown4.Value));
                }
                if (checkBox1.Checked)
                {
                    dataGridView1.ColumnCount = n + 1;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = "Исходный массив";
                    for (int j = 0; j < n; j++)
                    {
                        dataGridView1.Rows[i].Cells[j + 1].Value = vptr[j];
                    }

                    i++;
                }

                sort(vptr, n);
                current += 1;
                progressBar1.Value = 100 * current / count;
            }
        }
        private void sort(int[] p, int n)
        {
            int k = 0, sr = 0, obm = 0, m = 0;
            for (int j = 0; j < n; j++)
            {
                if (p[j] == 0) k++;
                else p[j - k] = p[j];
            }
            n -= k;
            sr += n;
            if (n == 0)
            {
                label8.Text = "В массиве одни нули";
                return;
            }
            for (m = 0; m < n - 1; m++)
                for (int j = m + 1; j < n; j++)
                {
                    if (p[m] > 0 && p[j] > 0 && p[m] < p[j])
                    {
                        swap(ref p[m], ref p[j]);
                        obm++;
                    }
                    if (p[m] < 0 && p[j] < 0 && p[m] > p[j])
                    {
                        swap(ref p[m], ref p[j]);
                        obm++;
                    }
                    sr += 6;
                }
            if (checkBox1.Checked)
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = "Получен массив";
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j + 1].Value = p[j];
                }

                i++;
            }

            if (Convert.ToInt32(numericUpDown1.Value) == Convert.ToInt32(numericUpDown2.Value))
            {
                label8.Text = "Количество сравнений=" + Convert.ToString(sr) + " Количество обменов=" + Convert.ToString(obm);
            }
            if (checkBox2.Checked)
            {
                chart1.Series[0].Points.AddXY(n, sr);
                chart2.Series[0].Points.AddXY(n, obm);
            }
        }
        void swap(ref int x, ref int y)
        {
            int z = x;
            x = y;
            y = z;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            i = 0;
        }
        int n, m;


        private void button3_Click(object sender, EventArgs e)
        {

            int i, j, k, q;
            button3.Enabled = false;
            if (numericUpDown8.Value < numericUpDown9.Value)
            {
                label16.Text = "Макс значение не м.б. меньше мин значения!";
                return;
            }
            n = Convert.ToInt32(numericUpDown6.Value);
            m = Convert.ToInt32(numericUpDown6.Value);
            int[,] ptr;
            ptr = new int[m, n];
            Random rand = new Random();
            dataGridView2.AutoResizeColumns();
            dataGridView2.ColumnCount = n;
            for (i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add();
                for (j = 0; j < m; j++)
                {
                    ptr[i, j] = rand.Next(Convert.ToInt32(numericUpDown9.Value), Convert.ToInt32(numericUpDown8.Value));
                    dataGridView2.Rows[i].Cells[j].Value = ptr[i, j];
                }
            }
            q = 0;
            k = 0;
            int[] arr = new int[n];
            for (q = 0; q < n; q++)
            {

                if (ptr[q, q] > Convert.ToInt32(numericUpDown7.Value))
                {
                    arr[k] = q;
                    k++;

                }

            }
            for (i = 0; i < k; i++)
            {
                for (j = arr[i] - i; j < n - 1; j++)
                {
                    for (int z = 0; z < n; z++)
                    {
                        ptr[j, z] = ptr[j + 1, z];
                    }

                }


            }

            if (k == n)
            {
                label16.Text = "В матрице удалены все строки";
                return;
            }
            if (k == 0)
            {
                label16.Text = "В матрице нет удаленных строк";
                return;
            }
            label16.Text = "В матрице удалено " + k + " строк(и)";
            int[] maxarr = new int[n - k];
            for (j = 0; j < m; j++)
            {

                for (i = 0; i < n - k; i++)
                {
                    maxarr[i] = ptr[i, j];
                }
                int max = GetMax(maxarr);
                ptr[n - k, j] = max;
            }
            dataGridView3.AutoResizeColumns();
            dataGridView3.ColumnCount = n;
            for (i = 0; i <= n - k; i++)
            {
                dataGridView3.Rows.Add();
                for (j = 0; j < m; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = ptr[i, j];
                }
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            button3.Enabled = true;
            label16.Text = "";
        }

        private int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];

            }
            return max;
        }
    }
}
