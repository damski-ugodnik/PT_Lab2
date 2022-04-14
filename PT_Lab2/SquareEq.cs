namespace PT_Lab2
{
    /// <summary>
    /// ����� ����� ��� ������� ����������� ���������
    /// </summary>
    public partial class SquareEq : Form
    {
        /// <summary>
        /// ���������� ����������� �� ��, ��� �������� �������� �������� �����, ���� ��� ����� true,
        /// �� ����� ����������� ��� ���� ���� ������� ����� �� ����� ��� ����������� ���������, �����, � ������ ������� ������� �������� ����
        /// </summary>
        private bool formSwitching = false;

        public SquareEq()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mode1.Checked = true;// ��������� ������� ������ 
        }
        /// <summary>
        /// ���������� ������� �������� �����
        /// ���� ����� ������� �� ���� ������ ����� �����, � ������ ��������� ����, �� ������������ ��������� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquareEq_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!formSwitching)
                Singleton.StartForm.Show();
        }
        /// <summary>
        /// ���������� ������� ������� ������ � ��������� ���� ��� �������������(�������� �����)(������������ ����� ������ ��� ����� �������������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = ((TextBox)sender).Text;// �������� ��������� ���������� � ������� � ������� ����
            if (char.IsDigit(e.KeyChar))// ���� �������� ������ - �����
            {
                if (double.Parse(s + e.KeyChar) > 100000)// ���� � �������� �������� �������� ����� ������ 100000, �� ���� �� ����� ���������
                {
                    e.KeyChar = (char)Keys.None;
                    return;
                }
            }
            // ���� �������� ������ - �����, �������, �����, ������ �������, ������� ����� ��� ������, �� ����� ����������� ��������, ����� ���� ��������� �� �����
            if (e.KeyChar == '-' || e.KeyChar == ',' || Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                // ���� ���� ������������ �� � ������ ������ � ������ - �����, �� ���� �� ����� ���������
                if (((TextBox)sender).SelectionStart != 0 && e.KeyChar == '-')
                    e.KeyChar = (char)Keys.None;
                // ���� ������ - �������
                if (e.KeyChar == ',')
                {
                    // ���� ������ ������, ���� �� ����� ���������
                    if (s.Length == 0)
                        e.KeyChar = (char)Keys.None;
                    // ���� ������ ������ ������ ����
                    if (s.Length > 0)
                    {
                        // ���� ���������� ������ �� ����� ��� �������� � ������ ������ ��� ����� 100000, �� ������� �� �������
                        if (!char.IsDigit(s[s.Length - 1]) || double.Parse(s + e.KeyChar) >= 100000)
                            e.KeyChar = (char)Keys.None;
                    }
                }
            }
            else e.KeyChar = (char)Keys.None;
        }
        /// <summary>
        /// ���������� ������� ������ ���������� ����������� ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processButton_Click(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = "";// ������� ����� ��� ������ ���������
            // ���� �����-�� �� ����� ��� ������������� ������, �� ��������� ��������� �� ������
            if (aBox.Text.Length == 0 || bBox.Text.Length == 0 || cBox.Text.Length == 0)
            {
                errorProvider1.SetError(groupBox1, "Empty Field(-s)");
                return;
            }
            errorProvider1.Clear();// ������� ��������� ������
            double a = default; double b = default; double c = default;
            // ������� ���������������� �������� �������������
            try
            {
                a = double.Parse(aBox.Text);
                b = double.Parse(bBox.Text);
                c = double.Parse(cBox.Text);
            }
            catch (Exception ex)// ���� �� ���������� ������������� ������ �� ����, ��������� ��������� �� ������
            {
                errorProvider1.SetError(groupBox1, ex.Message);
                return;
            }
            // ���� ���������� ������ �����, ���������� ���������� ��������������� � �����������
            if (mode1.Checked)
            {
                if (a == 0)// ���� ������ �����. ����� ����, �� ��� �� ���������� ���������, ����������� �� ������ � ���������� ��������
                {
                    errorProvider1.SetError(processButton, "Not a square equation: A should not be zero");
                    return;
                }

                double discriminant = b * b - 4 * a * c;// ���������� �������������

                // ���� ������������ ������ ����, �� ��������� �� ����� �������, ��������� �� ������, ���������� �������� 
                if (discriminant < 0)
                {
                    errorProvider1.SetError(processButton, "Equation does not have a solution:\n" +
                        "discriminant less than zero");
                    return;
                }
                // ����� � ���� ��� ������ ���������� ��� �1,2 = ((-b) +- Math.Sqrt(discriminant)) / 2 * a
                x1Box.Text = (Math.Round(((-b) - Math.Sqrt(discriminant)) / 2 * a, 3)).ToString();
                x2Box.Text = (Math.Round(((-b) + Math.Sqrt(discriminant)) / 2 * a, 3)).ToString();
            }
            // ���� ������ ������ �����, �� ���������� ������������ � ������ ������ �����
            if (mode2.Checked)
            {
                // ������� �������
                try
                {
                    double[] solution = Solution(a, b, c); // �������� ������� �����, ���� ����� ������� ��������� � ���� ���� ������
                    // ����� ���������� � ����: ������ ������� ������� - ������ ������, ������ - ������ ������
                    x1Box.Text = solution[0].ToString();
                    x2Box.Text = solution[1].ToString();
                }// ���� � ������ ��������������� ����������, �� ��������� ��������� �� ������
                catch (Exception ex)
                {
                    errorProvider1.SetError(processButton, ex.Message);
                }
            }
            // ���� ������ ������ �����, �� ���������� ���������� � ��������� ������ - �������� ���������, ������� ������������ �� ���� ��������� � ������� � ��������������
            if (mode3.Checked)
            {
                try
                {
                    SquareEquation equation = new SquareEquation(a, b, c);// �������� ���������� ������ � ����������� ���������� ��������������
                    // ����� ������ � ���� ������� ���������� ������
                    x1Box.Text = equation.X1;
                    x2Box.Text = equation.X2;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(processButton, ex.Message);
                }
            }
        }
        /// <summary>
        /// ��������� ������� ��������� ������ � � ����� �������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();// ������� ���������� ������
        }
        /// <summary>
        /// ���������� ������� ����� � ���� ��� ������
        /// ������ ��������� ����, ��������� ���������� ������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void x1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)(Keys.None);
        }
        /// <summary>
        /// ����� ���������� ����������� ���������
        /// </summary>
        /// <param name="a">����������� ��� x^2</param>
        /// <param name="b">����������� ��� �</param>
        /// <param name="c">��������� �����������</param>
        /// <returns>������ �� ���� ��������: ������ - ������ ������, ������ -  ������ ������/returns>
        /// <exception cref="Exception">��������� ��� ������������� ���� ��������� ��� ���� ��������� �� ����� �������</exception>
        private double[] Solution(double a, double b, double c)
        {
            // ���� � == 0, �� ��� �� ���������� ���������, ��������� ���������� 
            if (a == 0)
            {
                throw new Exception("Not a square equation: A should not be zero");
            }
            double discriminant = b * b - 4 * a * c;// ���������� �������������
            // ���� ������������ ������ ����, �� ��������� �� ����� �������, ��������� ����������
            if (discriminant < 0)
            {
                throw new Exception("Equation does not have a solution:\n" +
                    "discriminant less than zero");
            }
            // ���������� ������
            double x1 = Math.Round(((-b) - Math.Sqrt(discriminant)) / 2 * a, 3);
            double x2 = Math.Round(((-b) + Math.Sqrt(discriminant)) / 2 * a, 3);
            return new double[] { x1, x2 };
        }
        /// <summary>
        /// ���������� ������� ������ �������� � ����� ����������� ���������
        /// ����������� �������� ��������� ����� ������������� ������� ����� ����� �������� � ��������� �
        /// �������� ���������� ����� ���������� ������������� ��� ��������������� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gotoCubicEq_Click(object sender, EventArgs e)
        {
            formSwitching = true;
            Form frm = new CubicEq();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            StartForm.CurrentForm = frm;
            StartForm.CurrentForm.Show();
        }
        /// <summary>
        /// ���������� ��������� ������� ������ - ������� ��������� ������, ������� ���� ��� ������
        /// ������� �������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode1_CheckedChanged(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = "";
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 1:\n" +
                "Processing happens in the form class event handler";
        }
        /// <summary>
        /// ���������� ��������� ������� ������ - ������� ��������� ������, ������� ���� ��� ������
        /// ������� �������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode2_CheckedChanged(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = "";
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 2:\n" +
                            "Processing happens in the form class method";
        }
        /// <summary>
        /// ���������� ��������� �������� ������ - ������� ��������� ������, ������� ���� ��� ������
        /// ������� �������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode3_CheckedChanged(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = "";
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 3:\n" +
                "Creates a new class instance, which represents square equation: " +
                "has 3 coefficients and 2 roots, they are read-only and are assigned in constructor";
        }
        /// <summary>
        /// ���������� ������� ������ ������� ����� - ������� ��� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            aBox.Text = bBox.Text = cBox.Text = x1Box.Text = x2Box.Text = "";
        }
    }
}