namespace PT_Lab2
{
    public partial class SquareEq : Form
    {
        #region variables 
        #endregion

        public SquareEq()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mode1.Checked = true;
        }

        private void aBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = ((TextBox)sender).Text;
            if ((e.KeyChar == '-' || e.KeyChar == ',' || Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) && s.Length < 10)
            {
                if (s.Length != 0 && e.KeyChar == '-')
                    e.KeyChar = (char)Keys.None;
                if ((s.Length == 0 || s.Contains(',')) && e.KeyChar == ',')
                    e.KeyChar = (char)Keys.None;
            }
            else e.KeyChar = (char)Keys.None;
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            double a = double.Parse(aBox.Text);
            double b = double.Parse(bBox.Text);
            double c = double.Parse(cBox.Text);
            if (mode1.Checked)
            {
                double discriminant = b * b - 4 * a * c;
                if (discriminant < 0)
                {
                    errorProvider1.SetError(processButton, "Equation does not have a solution:\n" +
                        "discriminant less than zero");
                    return;
                }
                x1Box.Text = (Math.Round(((-b) - Math.Sqrt(discriminant)) / 2 * a, 3)).ToString();
                x2Box.Text = (Math.Round(((-b) + Math.Sqrt(discriminant)) / 2 * a, 3)).ToString();
            }
            if (mode2.Checked)
            {
                try
                {
                    double[] solution = Solution(a, b, c);
                    x1Box.Text = solution[0].ToString();
                    x2Box.Text = solution[1].ToString();
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(processButton, ex.Message);
                }
            }
            if (mode3.Checked)
            {
                try
                {
                    SquareEquation equation = new SquareEquation(a, b, c);
                    x1Box.Text = equation.X1;
                    x2Box.Text = equation.X2;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(processButton, ex.Message);
                }
            }
        }

        private void aBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void x1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)(Keys.None);
        }

        private void mode3_CheckedChanged(object sender, EventArgs e)
        {
            descriptionBox.Text = "Mode 3:\n" +
                "Creates a new class instance, which represents square equation: " +
                "has 3 coefficients and 2 roots, they are read-only and are assigned in constructor";
        }

        private double[] Solution(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                throw new Exception("Equation does not have a solution:\n" +
                    "discriminant less than zero");
            }
            double x1 = Math.Round(((-b) - Math.Sqrt(discriminant)) / 2 * a, 3);
            double x2 = Math.Round(((-b) + Math.Sqrt(discriminant)) / 2 * a, 3);
            return new double[] { x1, x2 };
        }

        private void gotoCubicEq_Click(object sender, EventArgs e)
        {
            Form frm = new CubicEq();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }
    }
}