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
    public partial class Form1 : Form
    {
        int a = 2, b = 2;
        Dictionary<string, TextBox> amount = new Dictionary<string, TextBox>();

        double[,] XXX = new double[5, 6];

        bool next = false, labelText = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            amount.Clear();
            createM(a, b);
            button1.Visible = true;
            button2.Visible = true;
        }

        private void a1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = Convert.ToInt32(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            b = Convert.ToInt32(comboBox2.Text);
            b++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    amount["a" + Convert.ToString(i) + Convert.ToString(j)].Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            next = true;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (amount["a" + Convert.ToString(i) + Convert.ToString(j)].Text == "")
                    {
                        MessageBox.Show("Поля пысты!");
                        i = 50;
                        j = 5;
                        next = false;
                    }
                    else XXX[i, j] = Convert.ToDouble(amount["a" + Convert.ToString(i) + Convert.ToString(j)].Text);
                }
            }

            if (next)
            {
                this.Hide();
                new Form2(XXX, b, a).Show();
            }
        }

        public void createM(int x, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.Controls.RemoveByKey("x" + Convert.ToString(i) + Convert.ToString(j));
                    this.Controls.RemoveByKey("a" + Convert.ToString(i) + Convert.ToString(j));
                }
            }

            for (int i = 0; i < x; i++)
            {
                labelText = true;
                for (int j = 0; j < y; j++)
                {
                    string name = "a" + Convert.ToString(i) + Convert.ToString(j);
                    amount[name] = new TextBox
                    {
                        Height = a1.Size.Height,
                        Width = a1.Size.Width,
                        Font = new Font(a1.Font.ToString(), a1.Font.Size),
                        Name = name,
                        Location = new Point(14 + j * 86, 100 + i * 34)
                    };
                    amount[name].KeyPress += a1_KeyPress;
                    if (labelText)
                    {
                        string txt = ((j + 2) < y) ? ("x" + Convert.ToString(j + 1) + "+") : ("x" + Convert.ToString(j + 1) + "=");
                        if (txt == "x" + Convert.ToString(j + 1) + "=")
                            labelText = false;
                        Label label = new Label
                        {
                            Height = label1.Size.Height - 3,
                            Width = label1.Size.Width - 3,
                            Font = new Font(label1.Font.ToString(), label1.Font.Size),
                            BackColor = System.Drawing.Color.Transparent,
                            Name = "x" + Convert.ToString(i) + Convert.ToString(j),
                            Text = txt,
                            Location = new Point(58 + j * 87, 100 + i * 35)
                        };
                        this.Controls.Add(label);
                    }
                    this.Controls.Add(amount[name]);
                }
            }
        }
    }
}
