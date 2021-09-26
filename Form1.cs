using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing.Drawing2D;
using org.mariuszgromada.math.mxparser;
using AngouriMath;
using AngouriMath.Extensions;
using static AngouriMath.MathS;
using static AngouriMath.Entity;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using MathNet.Symbolics;
using Express = MathNet.Symbolics.SymbolicExpression;

namespace grahpics
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.Title.Text = "График";
        }

            private void zedGraphControl1_Load(object sender, EventArgs e)
            {

            }
         
            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox3_TextChanged(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void textBox4_TextChanged(object sender, EventArgs e)
            {

            }

            private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
            {
            try
            {
                GraphPane pane = zedGraphControl1.GraphPane;               
                pane.CurveList.Clear();
                PointPairList list = new PointPairList();
                double min = Convert.ToDouble(textBox1.Text);
                double max = Convert.ToDouble(textBox2.Text);
                double ep = Convert.ToDouble(textBox3.Text);
                double del = 0.01 * ep;
                double a = min;
                double b = max;
                double h = (Math.Abs(a + b)) / 100;
                
                var expr = Express.Parse(textBox4.Text);
                Func<double, double> f = expr.Compile("x");

                while (b - a >= ep)
                {

                    double x = (a + b) / 2;
                    double x1 = x - (del / 2);
                    double x2 = x + (del / 2);

                    double f1 = f(x1);
                    double f2 = f(x2);

                    if (f1 == f2)
                    {
                        a = x1;
                        b = x2;
                    }
                    else if (f1 < f2)
                    {
                        b = x2;
                    }
                    else
                    {
                        a = x1;
                    }
                }
                double xmin = (a + b) / 2;
                double fmin = f(xmin);

                label5.Text = xmin.ToString();
                label6.Text = fmin.ToString();


                for (double x = min; x <= max; x += h)
                {                   
                    list.Add(x, f(x));
                }

                
                LineItem myCurve = pane.AddCurve("Sinc", list, Color.Pink, SymbolType.None);
                zedGraphControl1.AxisChange();
                // Обновляем график
                zedGraphControl1.Invalidate();

            }
                catch (Exception err)
                {
                    MessageBox.Show($"Ошибочка вышла: \n {err.Message}");
                }

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }
        }
    }

