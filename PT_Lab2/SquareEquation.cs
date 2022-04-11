namespace PT_Lab2
{
    internal class SquareEquation
    {
        private readonly double a, b, c, x1, x2, discriminant;

        public SquareEquation(double _a, double _b, double _c)
        {
            a = _a; b = _b; c = _c;
            if(a == 0)
            {
                throw new Exception("Not a square equation: A should not be zero");
            }
            discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                throw new Exception("Equation does not have a solution:\n" +
                    "discriminant less than zero");
            }
            x1 = Math.Round(((-b) - Math.Sqrt(discriminant)) / 2 * a, 3);
            x2 = Math.Round(((-b) + Math.Sqrt(discriminant)) / 2 * a, 3);
        }

        public string X1 { get { return x1.ToString(); } }
        public string X2 { get { return x2.ToString(); } }


        public string getInfo()
        {
            return string.Format("{0}x^2 + {1}x + {2} = 0\n" +
                "x1 = {3}\n" +
                "x2 = {4}\n" +
                "Discriminant = ", a, b, c, x1, x2, discriminant);
        }
    }
}
