using Xunit;
using PT_Lab2;
using System;

namespace UnitTestingProj
{
    public class UnitTest1
    {
        /// <summary>
        /// ������������ ������� ����������� ��������� � �������������� ������ ����
        /// </summary>
        [Fact]
        public void TestSquare_DiscMoreThanZero()
        {
            double x1_actual, x2_actual, x1_expected = -9, x2_expected = -1;
            SquareEquation equation = new SquareEquation(1,10,9);// �������� ����������
            x1_actual = double.Parse(equation.X1);
            x2_actual = double.Parse(equation.X2);
            Assert.Equal(x1_expected, x1_actual);
            Assert.Equal(x2_expected, x2_actual);
        }
        /// <summary>
        /// ������������ ������� ����������� ��������� � ��������������  ������ ����
        /// </summary>
        [Fact]
        public void TestSquare_DiscIsZero()
        {
            double x1_actual, x2_actual;
            SquareEquation equation = new SquareEquation(2, 4, 2);
            x1_actual = double.Parse(equation.X1);
            x2_actual = double.Parse(equation.X2);
            Assert.Equal(x2_actual, x1_actual);// �������� �� ��������� ������, �.� ��� ������� ������������� ��� ������ ���� ����� 
            double x_expected = -1;
            Assert.Equal(x_expected, x1_actual);// �������� �� ��������� � �������� ���������
        }
        /// <summary>
        /// �������� �� ������������ ���������� � ������ �������������� ������������� 
        /// </summary>
        [Fact]
        public void TestSquare_DiscLessThanZero()
        {
            Assert.ThrowsAny<Exception>(()=> new SquareEquation(10, 1, 5));
        }
        /// <summary>
        /// �������� �� ��������� ���������� � ������ ���� � == 0, ����� ��������� �� �������� ����������
        /// </summary>
        [Fact]
        public void TestSquare_NotSquaretEq()
        {
            Assert.ThrowsAny<Exception>(() => new SquareEquation(0, 1, 5));
        }
        /// <summary>
        /// ������������ ������� ����������� ��������� ��� S > 0
        /// ������ ���� ��� �������������� �����
        /// </summary>
        [Fact]
        public void TestCubic_S_MoreThanZero()
        {
            double x1_actual, x2_actual, x3_actual;
            double x1_expected = -0.021, x2_expected = 197.130, x3_expected = 0.021;
            CubicEquation equation = new CubicEquation(23, -4534, 2, 2);
            x1_actual = Math.Round(double.Parse(equation.X1), 3);
            x2_actual = Math.Round(double.Parse(equation.X2), 3);
            x3_actual = Math.Round(double.Parse(equation.X3), 3);
            Assert.Equal(x1_expected, x1_actual);
            Assert.Equal(x2_expected, x2_actual);
            Assert.Equal(x3_expected, x3_actual);
        }
        /// <summary>
        /// ������������ ������� ����������� ��������� ��� S < 0
        /// ���� �������������� ������ � ��� �����������
        /// </summary>
        [Fact]
        public void TestCubic_S_LessThanZero()
        {
            string x1_actual, x2_actual, x3_actual;
            string x1_expected ="-1,000" , x2_expected = "-0,000 + 1,414i" , x3_expected= "-0,000 - 1,414i";
            CubicEquation equation = new CubicEquation(1, 1, 2, 2);
            x1_actual = equation.X1;
            x2_actual = equation.X2;
            x3_actual = equation.X3;
            Assert.Equal(x1_expected, x1_actual);
            Assert.Equal(x2_expected, x2_actual);
            Assert.Equal(x3_expected , x3_actual);
        }
        /// <summary>
        /// ������������ ������� ����������� ��������� ��� S==0
        /// ��� �������������� ����� - ����������� ���������
        /// </summary>
        [Fact]
        public void TestCubic_S_IsZero()
        {
            string x1_actual, x2_actual, x3_actual;
            string x1_expected = "0", x2_expected = "0", x3_expected = "NO VALUE: DEGENERATE EQUATION";
            CubicEquation equation = new CubicEquation(1,0, 0, 0);
            x1_actual = equation.X1;
            x2_actual = equation.X2;
            x3_actual = equation.X3;
            Assert.Equal(x1_expected, x1_actual);
            Assert.Equal(x2_expected, x2_actual);
            Assert.Equal(x3_expected, x3_actual);
        }
        /// <summary>
        /// ������������ ������� ����������� ��������� ��� ������������ ����������, ����� � == 0, �.� �������� �� �������� ����������
        /// </summary>
        [Fact]
        public void TestCubic_NotCubicEq()
        {
            Assert.Throws<ArgumentException>(() => new CubicEquation(0, 1, 2, 2));
        }
    }
}