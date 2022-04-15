using System.Numerics;

namespace PT_Lab2
{
    public class CubicEquation
    {
        // Уравнение имеет вид x^3 + ax^2 + bx + c = 0
        // Если первый коэффициент не равен 1, все коэффициенты разделяются на первый,
        // Тем самым приводя его к нужному виду
        private readonly double a, b, c, x1, x2r, x3r, Q, R, S;
        private readonly Complex x2c, x3c;

        /// <summary>
        /// Решение кубического уравнения Тригонометрической формулой Виета 
        /// уравнение приводится делением на а, чтобы коэффициент при x^3 был равен 1
        /// </summary>
        /// <param name="_a">коэффициент при x^3</param>
        /// <param name="_b">коэффициент при x^2</param>
        /// <param name="_c">коэффициент при x</param>
        /// <param name="_d">свободный коэффициент</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public CubicEquation(double _a, double _b, double _c, double _d)
        {
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
            }
            else if (S < 0)// если S < 0, то у уравнения один реальный корень и два комплексных
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
            }
            else if (S == 0)// если S == 0, то уравнение вырожденное и у уравнения два действительных корня
            {
                x1 = -2 * Math.Cbrt(R) - a / 3;
                x2r = Math.Cbrt(R) - a / 3;
            }
            else throw new Exception("Not existent equation");
        }
        /// <summary>
        /// Первый корень уравнения
        /// </summary>
        public string X1 { get { return x1.ToString("0.000;-0.000;0"); } }
        /// <summary>
        /// Второй корень уравнения, может быть либо комплексным либо действительным в зависимости от значения S
        /// </summary>
        public string X2
        {
            get
            {
                if (S < 0)
                    return x2c.Real.ToString("0.000") + " " + x2c.Imaginary.ToString("+ 0.000;- 0.000") + "i";
                else
                    return x2r.ToString();
            }
        }
        /// <summary>
        /// Второй третий уравнения, может быть либо комплексным либо действительным либо не иметь значения в зависимости от значения S
        /// </summary>
        public string X3
        {
            get
            {
                if (S < 0)
                    return x3c.Real.ToString("0.000") + " " + x3c.Imaginary.ToString("+ 0.000;- 0.000") + "i";
                if (S == 0)
                    return "NO VALUE: DEGENERATE EQUATION";
                else return x3r.ToString();
            }
        }
    }
}
