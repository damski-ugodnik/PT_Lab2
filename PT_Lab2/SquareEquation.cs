namespace PT_Lab2
{
    /// <summary>
    /// Класс квадратного уравнения, отображает само уравнение с коэффициентами и корнями
    /// </summary>
    public class SquareEquation
    {
        /// <summary>
        /// Поля уравнения, инициализируемые в конструкторе
        /// </summary>
        private readonly double a, b, c, x1, x2, discriminant;

        /// <summary>
        /// Конструктор класса квадратного уравнения
        /// </summary>
        /// <param name="_a">коэффициент при x^2</param>
        /// <param name="_b">коэффициент при х</param>
        /// <param name="_c">свободный коэффициент</param>
        /// <exception cref="Exception">возникает при нессответсвии виду уравнения или если уравнение не имеет решения</exception>
        public SquareEquation(double _a, double _b, double _c)
        {
            a = _a; b = _b; c = _c;
            if (a == 0)// если а==0 то уравнение не квадратное
            {
                throw new Exception("Not a square equation: A should not be zero");
            }
            discriminant = b * b - 4 * a * c;//вычисление дискриминанта
            if (discriminant < 0)// если дискриминант меньше нуля, то уравнение не имеет решения
            {
                throw new Exception("Equation does not have a solution:\n" +
                    "discriminant less than zero");
            }
            // вычисление корней
            x1 = Math.Round(((-b) - Math.Sqrt(discriminant)) / (2 * a), 3);
            x2 = Math.Round(((-b) + Math.Sqrt(discriminant)) / (2 * a), 3);
        }

        /// <summary>
        /// Первый корень уравнения
        /// </summary>
        public string X1 { get { return x1.ToString(); } }
        /// <summary>
        /// Второй корень уравнения
        /// </summary>
        public string X2 { get { return x2.ToString(); } }
    }
}
