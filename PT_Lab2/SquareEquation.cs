namespace PT_Lab2
{
    internal class SquareEquation
    {
        readonly double a, b, c, x1, x2, discriminant;

        public SquareEquation(double _a, double _b, double _c)
        {
            a = _a; b = _b; c = _c;
            discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                throw new Exception("Equation does not have a solution:\n" +
                    "discriminant less than zero");
            }
            x1 = Math.Round(((-b) - Math.Sqrt(discriminant)) / 2 * a, 3);
            x2 = Math.Round(((-b) + Math.Sqrt(discriminant)) / 2 * a, 3);
        }

        public string A { get { return a.ToString(); } }
        public string B { get { return b.ToString(); } }
        public string C { get { return c.ToString(); } }
        public string X1 { get { return x1.ToString(); } }
        public string X2 { get { return x2.ToString(); } }
        public string Discriminant { get { return discriminant.ToString(); } }


        public string getInfo()
        {
            return string.Format("{0}x^2 + {1}x + {2} = 0\n" +
                "x1 = {3}\n" +
                "x2 = {4}\n" +
                "Discriminant = ", a, b, c, x1, x2, discriminant);
        }
    }
}
