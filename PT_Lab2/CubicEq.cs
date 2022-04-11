using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace PT_Lab2
{
    public partial class CubicEq : Form
    {
        public CubicEq()
        {
            InitializeComponent();
        }

        private void CubicEq_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gotoSquareEq_Click(object sender, EventArgs e)
        {
            Form frm = new SquareEq();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void CubicEq_Load(object sender, EventArgs e)
        {
            mode1.Checked = true;
        }

        private void aBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void x1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)(Keys.None);
        }

        private void mode1_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 1:\n" +
                "Processing happens in the form class event handler";
        }

        private void mode2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 2:\n" +
                            "Processing happens in the form class method";
        }

        private void mode3_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 3:\n" +
                "Creates a new class instance, which represents square equation";
        }

        private void aBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = ((TextBox)sender).Text;
            if (char.IsDigit(e.KeyChar))
            {
                if (double.Parse(s + e.KeyChar) > 100000)
                {
                    e.KeyChar = (char)Keys.None;
                    return;
                }
            }
            if (e.KeyChar == '-' || e.KeyChar == ',' || Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                if (s.Length != 0 && e.KeyChar == '-')
                    e.KeyChar = (char)Keys.None;
                if ((s.Length == 0 || s.Contains(',')) && e.KeyChar == ',')
                    e.KeyChar = (char)Keys.None;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                ;
            }
            else e.KeyChar = (char)Keys.None;
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = x3Box.Text = "";
            if (aBox.Text.Length == 0 || bBox.Text.Length == 0 || cBox.Text.Length == 0 || dBox.Text.Length == 0)
            {
                errorProvider1.SetError(groupBox1, "Empty Field(-s)");
                return;
            }
            errorProvider1.Clear();
            double a = double.Parse(aBox.Text);
            double b = double.Parse(bBox.Text);
            double c = double.Parse(cBox.Text);
            double d = double.Parse(dBox.Text);
            if (mode1.Checked)
            {
                double x1 = default, x2r, x3r, Q, R, S;
                Complex x2c = default, x3c = default;
                if (a == 0)
                {
                    errorProvider1.SetError(aBox,"Error: not cubic equation - A should not be zero");
                }
                a = b / a; b = c / a; c = d / a; //приведение коэффициентов 
                Q = (Math.Pow(a, 2) - (3 * b)) / 9;
                R = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;
                S = Math.Pow(Q, 3) - Math.Pow(R, 2);
                if (S > 0)
                {
                    double fi = Math.Acos(R / Math.Sqrt(-Math.Pow(Q, 3))) / 3;
                    x1 = 2 * Math.Sqrt(-Q) * Math.Cos(fi) - a / 3;
                    x2r = 2 * Math.Sqrt(-Q) * Math.Cos(fi + (2 * Math.PI) / 3) - a / 3;
                    x3r = 2 * Math.Sqrt(-Q) * Math.Cos(fi - (2 * Math.PI) / 3) - a / 3;
                    x1Box.Text = x1.ToString("0.000;-0.000;0");
                    x2Box.Text = x2r.ToString("0.000;-0.000;0");
                    x3Box.Text = x3r.ToString("0.000;-0.000;0");
                }
                else if (S < 0)
                {
                    if (Q > 0)
                    {

                        var fi = Math.Acosh(Math.Abs(R) / Math.Sqrt(Math.Pow(Q, 3))) / 3;
                        x1 = -2 * Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3;
                        x2c = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3 + Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                        x3c = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3 - Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                    }
                    if (Q < 0)
                    {
                        var fi = Math.Asinh(Math.Abs(R) / Math.Sqrt(Math.Pow(Math.Abs(Q), 3))) / 3;
                        x1 = -2 * Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3;
                        x2c = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3 + Complex.ImaginaryOne * Math.Sqrt(3 * Math.Abs(Q)) * Math.Cosh(fi);
                        x3c = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3 - Complex.ImaginaryOne * Math.Sqrt(3 * Math.Abs(Q)) * Math.Cosh(fi);
                    }
                    if (Q == 0)
                    {
                        x1 = -Math.Cbrt(c - Math.Pow(a, 3) / 27) - a / 3;
                        x2c = -((a + x1) / 2) + (Complex.ImaginaryOne / 2) * Math.Sqrt(Math.Abs(((a - 3 * x1) * (a + x1)) - 4 * b));
                        x3c = -((a + x1) / 2) - (Complex.ImaginaryOne / 2) * Math.Sqrt(Math.Abs(((a - 3 * x1) * (a + x1)) - 4 * b));
                    }
                    x1Box.Text = x1.ToString("0.000;-0.000;0");
                    x2Box.Text = x2c.Real.ToString("0.000") + " " + x2c.Imaginary.ToString("+ 0.000;- 0.000") + "i";
                    x3Box.Text = x3c.Real.ToString("0.000") + " " + x3c.Imaginary.ToString("+ 0.000;- 0.000") + "i";
                }
                else if (S == 0)
                {
                    x1 = -2 * Math.Cbrt(R) - a / 3;
                    x2r = Math.Cbrt(R) - a / 3;
                    x1Box.Text = x1.ToString("0.000;-0.000;0");
                    x2Box.Text = x2r.ToString("0.000;-0.000;0");
                    x3Box.Text = "NO VALUE: DEGENERATE EQUATION";
                }
                else errorProvider1.SetError(groupBox1, "Not existent equation");
            }
            if (mode2.Checked)
            {
                try
                {
                    string[] res = Solution(a, b, c, d);
                    x1Box.Text = res[0];
                    x2Box.Text = res[1];
                    x3Box.Text = res[2];
                }catch (Exception ex)
                {
                    errorProvider1.SetError(processButton,ex.Message);
                }

            }
            if (mode3.Checked)
            {
                try
                {
                    CubicEquation equation = new CubicEquation(a, b, c, d);
                    x1Box.Text = equation.X1;
                    x2Box.Text = equation.X2;
                    x3Box.Text = equation.X3;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(processButton, ex.Message);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            aBox.Text = bBox.Text = cBox.Text = dBox.Text = x1Box.Text = x2Box.Text = x3Box.Text = "";
        }

        private string[] Solution(double _a, double _b, double _c, double _d)
        {
            double a, b, c, x1 = default, x2r = default, x3r = default, Q, R, S;
            Complex x2c = default, x3c = default;
            if (_a == 0)
            {
                throw new ArgumentException("Error: not cubic equation - A should not be zero");
            }
            a = _b / _a; b = _c / _a; c = _d / _a; //приведение коэффициентов 
            Q = (Math.Pow(a, 2) - (3 * b)) / 9;
            R = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;
            S = Math.Pow(Q, 3) - Math.Pow(R, 2);
            if (S > 0)
            {
                double fi = Math.Acos(R / Math.Sqrt(-Math.Pow(Q, 3))) / 3;
                x1 = 2 * Math.Sqrt(-Q) * Math.Cos(fi) - a / 3;
                x2r = 2 * Math.Sqrt(-Q) * Math.Cos(fi + (2 * Math.PI) / 3) - a / 3;
                x3r = 2 * Math.Sqrt(-Q) * Math.Cos(fi - (2 * Math.PI) / 3) - a / 3;
                return new string[] {x1.ToString("0.000;-0.000;0"), x2r.ToString("0.000;-0.000;0"), x3r.ToString("0.000;-0.000;0") };
            }
            if (S < 0)
            {
                if (Q > 0)
                {

                    var fi = Math.Acosh(Math.Abs(R) / Math.Sqrt(Math.Pow(Q, 3))) / 3;
                    x1 = -2 * Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3;
                    x2c = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3 + Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                    x3c = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3 - Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                }
                if (Q < 0)
                {
                    var fi = Math.Asinh(Math.Abs(R) / Math.Sqrt(Math.Pow(Math.Abs(Q), 3))) / 3;
                    x1 = -2 * Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3;
                    x2c = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3 + Complex.ImaginaryOne * Math.Sqrt(3 * Math.Abs(Q)) * Math.Cosh(fi);
                    x3c = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3 - Complex.ImaginaryOne * Math.Sqrt(3 * Math.Abs(Q)) * Math.Cosh(fi);
                }
                if (Q == 0)
                {
                    x1 = -Math.Cbrt(c - Math.Pow(a, 3) / 27) - a / 3;
                    x2c = -((a + x1) / 2) + (Complex.ImaginaryOne / 2) * Math.Sqrt(Math.Abs(((a - 3 * x1) * (a + x1)) - 4 * b));
                    x3c = -((a + x1) / 2) - (Complex.ImaginaryOne / 2) * Math.Sqrt(Math.Abs(((a - 3 * x1) * (a + x1)) - 4 * b));
                }
                return new string[] { x1.ToString("0.000;-0.000;0"), x2c.Real.ToString("0.000") + " " + x2c.Imaginary.ToString("+ 0.000;- 0.000") + "i", x3c.Real.ToString("0.000") + " " + x3c.Imaginary.ToString("+ 0.000;- 0.000") + "i" };
            }
                if (S == 0)
                {
                    x1 = -2 * Math.Cbrt(R) - a / 3;
                    x2r = Math.Cbrt(R) - a / 3;
                    return new string[] { x1.ToString("0.000;-0.000;0"), x2r.ToString("0.000;-0.000;0"), "NO VALUE: DEGENERATE EQUATION" };
                }
            throw new Exception("Not existent equation");
        }
    }
}
    

