using System.Numerics;

namespace PT_Lab2
{
    /// <summary>
    /// Класс формы для решения кубического уравнения
    /// </summary>
    public partial class CubicEq : Form
    {
        /// <summary>
        /// переменная указывающая на то, что является причиной закрытия формы, если она равна true,
        /// то форма закрывается для того чтоб перейти сразу на форму для кубического уравнения, иначе, её просто закрыли кнопкой закрытия окна
        /// </summary>
        private bool formSwitching = false;
        /// <summary>
        /// Конструктор класса формы
        /// </summary>
        public CubicEq()
        {
            InitializeComponent();
        }
        /// <summary>
        /// обработчик события закрытия формы
        /// если форма закрыта не путём кнопки смены формы, а просто закрытием окна, то показывается стартовое окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CubicEq_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!formSwitching)
                Singleton.StartForm.Show();
        }

        /// <summary>
        /// обработчик нажатия кнопки перехода к форме квадратного уравнения
        /// присваивает свойству стартовой формы отображающему текущую форму новое значение и открывает её
        /// закрытие предыдущей формы происходит автоматически при переопределении свойства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gotoSquareEq_Click(object sender, EventArgs e)
        {
            formSwitching = true;
            Form frm = new SquareEq();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            StartForm.CurrentForm = frm;
            StartForm.CurrentForm.Show();
        }

        private void CubicEq_Load(object sender, EventArgs e)
        {
            mode1.Checked = true;
        }
        /// <summary>
        /// обрабочик события изменения текста в в полях коэффициентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        /// <summary>
        /// обработчик события ввода в поля для корней
        /// просто запрещает ввод, опустошая переменную символа ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void x1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)(Keys.None);
        }

        /// <summary>
        /// Обработчик установки первого режима - очищает индикатор ошибки, очищает поля для корней
        /// Выводит описание режима
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode1_CheckedChanged(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = x3Box.Text = "";
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 1:\n" +
                "Processing happens in the form class event handler";
        }
        /// <summary>
        /// Обработчик установки второго режима - очищает индикатор ошибки, очищает поля для корней
        /// Выводит описание режима
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode2_CheckedChanged(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = x3Box.Text = "";
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 2:\n" +
                            "Processing happens in the form class method";
        }
        /// <summary>
        /// Обработчик установки третьего режима - очищает индикатор ошибки, очищает поля для корней
        /// Выводит описание режима
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode3_CheckedChanged(object sender, EventArgs e)
        {
            x1Box.Text = x2Box.Text = x3Box.Text = "";
            errorProvider1.Clear();
            descriptionBox.Text = "Mode 3:\n" +
                "Creates a new class instance, which represents cubic equation";
        }

        /// <summary>
        /// обработчик события нажатия кнопки в текстовом поле для коэффициентов(проверка ввода)(используется всеми полями для ввода коэффициентов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = ((TextBox)sender).Text;// создание временной переменной с текстом в текущем поле
            if (char.IsDigit(e.KeyChar))// если вводимый символ - цифра
            {
                if (double.Parse(s + e.KeyChar) > 100000)// если с вводимым символом значение будет больше 100000, то ввод не будет произведён
                {
                    e.KeyChar = (char)Keys.None;
                    return;
                }
            }
            // если вводимый символ - минус, запятая, цифра, отмена символа, стрелка влево или вправо, то будет происходить проверка, иначе ввод произведён не будет
            if (e.KeyChar == '-' || e.KeyChar == ',' || Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                // если ввод производится не в начале строки и символ - минус, то ввод не будет произведён
                if (((TextBox)sender).SelectionStart != 0 && e.KeyChar == '-')
                    e.KeyChar = (char)Keys.None;
                // если символ - запятая
                if (e.KeyChar == ',')
                {
                    // если строка пустая, ввод не будет произведён
                    if (s.Length == 0)
                        e.KeyChar = (char)Keys.None;
                    // если длинна строки больше нуля
                    if (s.Length > 0)
                    {
                        // если предыдущий символ не цифра или значение в строке больше или равно 100000, то запятая не введётся
                        if (!char.IsDigit(s[s.Length - 1]) || double.Parse(s + e.KeyChar) >= 100000)
                            e.KeyChar = (char)Keys.None;
                    }
                }
            }
            else e.KeyChar = (char)Keys.None;
        }
        /// <summary>
        /// обработчик нажатия кнопки вычисления квадратного уравнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processButton_Click(object sender, EventArgs e)
        {
            // очистка полей корней
            x1Box.Text = x2Box.Text = x3Box.Text = "";
            // если какое-то из полей для коэффициентов пустое, то выведется сообщение об ошибке
            if (aBox.Text.Length == 0 || bBox.Text.Length == 0 || cBox.Text.Length == 0 || dBox.Text.Length == 0)
            {
                errorProvider1.SetError(groupBox1, "Empty Field(-s)");
                return;
            }
            errorProvider1.Clear();
            double a = default; double b = default; double c = default; double d = default;
            // попытка инициализировать значения коэффициентов
            try
            {
                a = double.Parse(aBox.Text);
                b = double.Parse(bBox.Text);
                c = double.Parse(cBox.Text);
                d = double.Parse(dBox.Text);
            }
            catch (Exception ex)// если не получается преобразовать данные из поля, выводится сообщение об ошибке
            {
                errorProvider1.SetError(groupBox1, ex.Message);
                return;
            }
            // если установлен первый режим, происходит вычисление непосредственно в обработчике
            if (mode1.Checked)
            {
                // Вычисление происходит по тригонометрической формуле Виета
                double x1 = default, A, B, C, x2r, x3r, Q, R, S;
                Complex x2c = default, x3c = default;
                // если а == 0 то уравнение не является кубическим
                if (a == 0)
                {
                    errorProvider1.SetError(aBox, "Error: not cubic equation - A should not be zero");
                }
                A = b / a; B = c / a; C = d / a; //приведение коэффициентов 
                Q = (Math.Pow(A, 2) - (3 * B)) / 9;
                R = (2 * Math.Pow(A, 3) - 9 * A * B + 27 * C) / 54;
                S = Math.Pow(Q, 3) - Math.Pow(R, 2);
                if (S > 0)// если S > 0 то у уравнения 3 действительных корня
                {
                    double fi = Math.Acos(R / Math.Sqrt(Math.Pow(Q, 3))) / 3;
                    x1 = -2 * Math.Sqrt(Q) * Math.Cos(fi) - A / 3;
                    x2r = -2 * Math.Sqrt(Q) * Math.Cos(fi + (2 * Math.PI) / 3) - A / 3;
                    x3r = -2 * Math.Sqrt(Q) * Math.Cos(fi - (2 * Math.PI) / 3) - A / 3;
                    x1Box.Text = x1.ToString("0.000;-0.000;0");
                    x2Box.Text = x2r.ToString("0.000;-0.000;0");
                    x3Box.Text = x3r.ToString("0.000;-0.000;0");
                }
                else if (S < 0)// если S < 0, то у уравнения один реальный корень и два комплексных
                {
                    if (Q > 0)
                    {

                        var fi = Math.Acosh(Math.Abs(R) / Math.Sqrt(Math.Pow(Q, 3))) / 3;
                        x1 = -2 * Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - A / 3;
                        x2c = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - A / 3 + Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                        x3c = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - A / 3 - Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                    }
                    if (Q < 0)
                    {
                        var fi = Math.Asinh(Math.Abs(R) / Math.Sqrt(Math.Pow(Math.Abs(Q), 3))) / 3;
                        x1 = -2 * Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - A / 3;
                        x2c = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - A / 3 + Complex.ImaginaryOne * Math.Sqrt(3 * Math.Abs(Q)) * Math.Cosh(fi);
                        x3c = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - A / 3 - Complex.ImaginaryOne * Math.Sqrt(3 * Math.Abs(Q)) * Math.Cosh(fi);
                    }
                    if (Q == 0)
                    {
                        x1 = -Math.Cbrt(C - Math.Pow(A, 3) / 27) - A / 3;
                        x2c = -((A + x1) / 2) + (Complex.ImaginaryOne / 2) * Math.Sqrt(Math.Abs(((A - 3 * x1) * (A + x1)) - 4 * B));
                        x3c = -((A + x1) / 2) - (Complex.ImaginaryOne / 2) * Math.Sqrt(Math.Abs(((A - 3 * x1) * (A + x1)) - 4 * B));
                    }
                    x1Box.Text = x1.ToString("0.000;-0.000;0");
                    x2Box.Text = x2c.Real.ToString("0.000") + " " + x2c.Imaginary.ToString("+ 0.000;- 0.000") + "i";
                    x3Box.Text = x3c.Real.ToString("0.000") + " " + x3c.Imaginary.ToString("+ 0.000;- 0.000") + "i";
                }
                else if (S == 0)// если S == 0, то уравнение вырожденное и у уравнения два действительных корня
                {
                    x1 = -2 * Math.Cbrt(R) - A / 3;
                    x2r = Math.Cbrt(R) - A / 3;
                    x1Box.Text = x1.ToString("0.000;-0.000;0");
                    x2Box.Text = x2r.ToString("0.000;-0.000;0");
                    x3Box.Text = "NO VALUE: DEGENERATE EQUATION";
                }
                else errorProvider1.SetError(groupBox1, "Not existent equation");
            }
            // если выбран второй режим, то вычисление производится в методе класса формы
            if (mode2.Checked)
            {
                try
                {
                    string[] res = Solution(a, b, c, d);
                    x1Box.Text = res[0];
                    x2Box.Text = res[1];
                    x3Box.Text = res[2];
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
        /// <summary>
        /// Обработчик нажатия кнопки очистки полей - очищает все поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            aBox.Text = bBox.Text = cBox.Text = dBox.Text = x1Box.Text = x2Box.Text = x3Box.Text = "";
        }
        /// <summary>
        /// Решение кубического уравнения Тригонометрической формулой Виета 
        /// уравнение приводится делением на а, чтобы коэффициент при x^3 был равен 1
        /// </summary>
        /// <param name="_a">коэффициент при x^3</param>
        /// <param name="_b">коэффициент при x^2</param>
        /// <param name="_c">коэффициент при x</param>
        /// <param name="_d">свободный коэффициент</param>
        /// <returns>массив строк, каждая из которых отображает корень уравнения в соответсвии с индексом в массиве</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        private string[] Solution(double _a, double _b, double _c, double _d)
        {
            double a, b, c, x1 = default, x2r = default, x3r = default, Q, R, S;
            Complex x2c = default, x3c = default;
            // если а == 0 то уравнение не является кубическим
            if (_a == 0)
            {
                throw new ArgumentException("Error: not cubic equation - A should not be zero");
            }
            a = _b / _a; b = _c / _a; c = _d / _a; //приведение коэффициентов 
            Q = (Math.Pow(a, 2) - (3 * b)) / 9;
            R = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;
            S = Math.Pow(Q, 3) - Math.Pow(R, 2);
            if (S > 0)// если S > 0 то у уравнения 3 действительных корня
            {
                double fi = Math.Acos(R / Math.Sqrt(Math.Pow(Q, 3))) / 3;
                x1 = -2 * Math.Sqrt(Q) * Math.Cos(fi) - a / 3;
                x2r = -2 * Math.Sqrt(Q) * Math.Cos(fi + (2 * Math.PI) / 3) - a / 3;
                x3r = -2 * Math.Sqrt(Q) * Math.Cos(fi - (2 * Math.PI) / 3) - a / 3;
                return new string[] { x1.ToString("0.000;-0.000;0"), x2r.ToString("0.000;-0.000;0"), x3r.ToString("0.000;-0.000;0") };
            }
            if (S < 0)// если S < 0, то у уравнения один реальный корень и два комплексных
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
            if (S == 0)// если S == 0, то уравнение вырожденное и у уравнения два действительных корня
            {
                x1 = -2 * Math.Cbrt(R) - a / 3;
                x2r = Math.Cbrt(R) - a / 3;
                return new string[] { x1.ToString("0.000;-0.000;0"), x2r.ToString("0.000;-0.000;0"), "NO VALUE: DEGENERATE EQUATION" };
            }
            throw new Exception("Not existent equation");
        }
    }
}


