using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Method
{
    public partial class Form2 : Form
    {
        double[,] arrA = new double[5, 6];
        double diagonal_element, flag;
        int i, j, k, l, div = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.Controls.RemoveByKey("x" + Convert.ToString(i) + Convert.ToString(j));
                }
                this.Controls.RemoveByKey("s" + Convert.ToString(i));
            }

            for (int i = 0; i < row_num; i++)
            {
                string X = Convert.ToString(Math.Round(arrA[i, col_num - 1], 2));

                Label label = new Label
                {
                    Height = label1.Size.Height,
                    Width = label1.Size.Width + 100,
                    Font = new Font(label1.Font.ToString(), label1.Font.Size),
                    Name = "s" + Convert.ToString(i),
                    Text = $"x{Convert.ToString(i + 1)} = {X}",
                    Location = new Point(50, 50 + i * 35)
                };
                this.Controls.Add(label);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            makerMMM();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        int row_num, col_num;
        string txt;

        public Form2(double[,] x, int max, int min)
        {
            InitializeComponent();
            arrA = x;
            col_num = max;
            row_num = min;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            createM(arrA);
        }

        public void createM(double[,] x)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.Controls.RemoveByKey("x" + Convert.ToString(i) + Convert.ToString(j));
                }
            }

            for (int i = 0; i < row_num; i++)
            {
                for (int j = 0; j < col_num; j++)
                {
                    try
                    {
                        int n = Convert.ToInt32(Math.Round(x[i, j], 2));
                        txt = (j + 1 == col_num) ? $" | {n} " : $"{n}";
                        Label al = new Label
                        {
                            Height = label1.Size.Height,
                            Width = label1.Size.Width,
                            Font = new Font(label1.Font.ToString(), label1.Font.Size),
                            Name = "x" + Convert.ToString(i) + Convert.ToString(j),
                            Text = txt,
                            Location = new Point(50 + j * 87, 50 + i * 35)
                        };
                        this.Controls.Add(al);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: выдаёт 'не число'");
                        button1.Visible = false;
                        button3.Visible = false;
                        i = 7;
                        j = 7;
                    }
                }
            }
        }

        public void makerMMM()
        {
            for (i = 0; i < row_num; i++)
            {
                for (j = 0; j < col_num; j++)
                {
                    if (i == j && col_num - 1 != j)
                    {
                        partially_pivot(arrA, i, j);

                        diagonal_element = arrA[i, j];
                        k = i;
                        l = j;

                        for (l = 0; l < col_num; l++)
                        {
                            //for making the diagonal element 1
                            arrA[k, l] /= diagonal_element;
                            div++;
                        }


                        for (k = 0; k < row_num; k++)
                        {
                            //setting flag = the element on respective row which is exactly below the concerned diagonal element
                            flag = arrA[k, j];

                            for (l = 0; l < col_num; l++)
                                if (k != i)
                                {
                                    //performing row operation to male all the elements = 0, except diagonal element
                                    arrA[k, l] = (arrA[k, l]) - flag * (arrA[i, l]);
                                }

                        }
                    }
                }
            }
            createM(arrA);
        }

        void partially_pivot(double[,] arrA, int pivot_row, int pivot_col)
        {
            double temp;
            int i, large_pivot_row = pivot_row;

            for (i = pivot_row; i < row_num; i++)
            {
                //to find greatest among the pivot column column
                if (arrA[i, pivot_col] > arrA[large_pivot_row, pivot_col])
                {
                    large_pivot_row = i;
                }
            }

            if (pivot_row != large_pivot_row)
            {
                //to interchange the rows
                for (i = 0; i < col_num; i++)
                {
                    temp = arrA[large_pivot_row, i];
                    arrA[large_pivot_row, i] = arrA[pivot_row, i];
                    arrA[pivot_row, i] = temp;
                }
            }
        }
    }
}
