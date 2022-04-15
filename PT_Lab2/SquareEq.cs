namespace PT_Lab2
{
    /// <summary>
    /// Класс формы для решения квадратного уравнения
    /// </summary>
    public partial class SquareEq : Form
    {
        /// <summary>
        /// переменная указывающая на то, что является причиной закрытия формы, если она равна true,
        /// то форма закрывается для того чтоб перейти сразу на форму для кубического уравнения, иначе, её просто закрыли кнопкой закрытия окна
        /// </summary>
        private bool formSwitching = false;

        public SquareEq()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mode1.Checked = true;// установка первого режима 
        }
        /// <summary>
        /// обработчик события закрытия формы
        /// если форма закрыта не путём кнопки смены формы, а просто закрытием окна, то показывается стартовое окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquareEq_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!formSwitching)
                Singleton.StartForm.Show();
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
            x1Box.Text = x2Box.Text = "";// очистка полей для корней уравнения
            // если какое-то из полей для коэффициентов пустое, то выведется сообщение об ошибке
            if (aBox.Text.Length == 0 || bBox.Text.Length == 0 || cBox.Text.Length == 0)
            {
                errorProvider1.SetError(groupBox1, "Empty Field(-s)");
                return;
            }
            errorProvider1.Clear();// очистка индиктора ошибки
            double a = default; double b = default; double c = default;
            // попытка инициализировать значения коэффициентов
            try
            {
                a = double.Parse(aBox.Text);
                b = double.Parse(bBox.Text);
                c = double.Parse(cBox.Text);
            }
            catch (Exception ex)// если не получается преобразовать данные из поля, выводится сообщение об ошибке
            {
                errorProvider1.SetError(groupBox1, ex.Message);
                return;
            }
            // если установлен первый режим, происходит вычисление непосредственно в обработчике
            if (mode1.Checked)
            {
                if (a == 0)// если первый коэфф. равен нулю, то это не квадратное уравнение, уведомление об ошибке и завершение процесса
                {
                    errorProvider1.SetError(processButton, "Not a square equation: A should not be zero");
                    return;
                }

                double discriminant = b * b - 4 * a * c;// вычисление дискриминанта

                // если дискриминант меньше нуля, то уравнение не имеет решения, ссобщение об ошибке, завершение процесса 
                if (discriminant < 0)
                {
                    errorProvider1.SetError(processButton, "Equation does not have a solution:\n" +
                        "discriminant less than zero");
                    return;
                }
                // вывод в поля для корней результата где Х1,2 = ((-b) +- Math.Sqrt(discriminant)) / 2 * a
                x1Box.Text = (Math.Round(((-b) - Math.Sqrt(discriminant)) / (2 * a), 3)).ToString();
                x2Box.Text = (Math.Round(((-b) + Math.Sqrt(discriminant)) / (2 * a), 3)).ToString();
            }
            // если выбран второй режим, то вычисление производится в методе класса формы
            if (mode2.Checked)
            {
                // попытка решения
                try
                {
                    double[] solution = Solution(a, b, c); // создание массива чисел, куда будет записан результат в виде двух корней
                    // вывод результата в поля: первый элемент массива - первый корень, второй - второй корень
                    x1Box.Text = solution[0].ToString();
                    x2Box.Text = solution[1].ToString();
                }// если в методе сгенерировалось исключение, то выводится сообщение об ошибке
                catch (Exception ex)
                {
                    errorProvider1.SetError(processButton, ex.Message);
                }
            }
            // если выбран третий режим, то вычисление происходит в отдельном классе - создаётся экземпляр, который представляет из себя уравнение с корнями и коэффициентами
            if (mode3.Checked)
            {
                try
                {
                    SquareEquation equation = new SquareEquation(a, b, c);// создание экземпляра класса с переданными значениями коэффициентами
                    // вывод корней в виде свойств экземпляра класса
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
        /// обрабочик события изменения текста в в полях коэффициентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();// очистка индикатора ошибки
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
        /// метод вычисления квадратного уравнения
        /// </summary>
        /// <param name="a">коэффициент при x^2</param>
        /// <param name="b">коэффициент при х</param>
        /// <param name="c">свободный коэффициент</param>
        /// <returns>массив из двух элеметов: первый - первый корень, второй -  второй корень/returns>
        /// <exception cref="Exception">возникает при нессответсвии виду уравнения или если уравнение не имеет решения</exception>
        private double[] Solution(double a, double b, double c)
        {
            // если а == 0, то это не квадратное уравнение, генерация исключения 
            if (a == 0)
            {
                throw new Exception("Not a square equation: A should not be zero");
            }
            double discriminant = b * b - 4 * a * c;// вычисление дискриминанта
            // если дискриминант меньше нуля, то уравнение не имеет решений, генерация исключения
            if (discriminant < 0)
            {
                throw new Exception("Equation does not have a solution:\n" +
                    "discriminant less than zero");
            }
            // вычисление корней
            double x1 = Math.Round(((-b) - Math.Sqrt(discriminant)) / (2 * a), 3);
            double x2 = Math.Round(((-b) + Math.Sqrt(discriminant)) / (2 * a), 3);
            return new double[] { x1, x2 };
        }
        /// <summary>
        /// обработчик нажатия кнопки перехода к форме кубического уравнения
        /// присваивает свойству стартовой формы отображающему текущую форму новое значение и открывает её
        /// закрытие предыдущей формы происходит автоматически при переопределении свойства
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
        /// Обработчик установки первого режима - очищает индикатор ошибки, очищает поля для корней
        /// Выводит описание режима
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
        /// Обработчик установки второго режима - очищает индикатор ошибки, очищает поля для корней
        /// Выводит описание режима
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
        /// Обработчик установки третьего режима - очищает индикатор ошибки, очищает поля для корней
        /// Выводит описание режима
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
        /// Обработчик нажатия кнопки очистки полей - очищает все поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            aBox.Text = bBox.Text = cBox.Text = x1Box.Text = x2Box.Text = "";
        }
    }
}