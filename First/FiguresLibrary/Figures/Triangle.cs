using System;
using System.IO;

namespace FiguresLibrary.Figures
{
    /// <summary>�����������</summary>
    public class Triangle : IFigure
    {
        private readonly double _first;
        private readonly double _second;
        private readonly double _third;

        /// <summary>
        /// ����������� �������������, ���� a^2 + b^2 = c^2, ��� c - ����� ���������� ������� ������������
        /// </summary>
        public bool IsRight => Math.Abs(_first * _first + _second * _second - _third * _third) < double.Epsilon;

        public double Area => CalculateArea();

        /// <summary>������� �����������</summary>
        /// <param name="first">����� ������ �������. ������������� �����</param>
        /// <param name="second">����� ������ �������. ������������� �����</param>
        /// <param name="third">����� ������� �������. ������������� �����</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double first, double second, double third)
        {
            if (first <= 0 || second <= 0 || third <= 0)
            {
                throw new ArgumentException($"���������� ������� ����������� � ������� ���������: {first}, {second}, {third} - �����-�� �� ��� ���������������");
            }

            var sides = new double[3] { first, second, third };
            Array.Sort(sides);

            if (sides[2] >= sides[0] + sides[1])
            {
                throw new ArgumentException($"���������� ������� ����������� � ������� ���������: {first}, {second}, {third} - �� ��������� ����������� ������������");
            }
                
            _first = sides[0];
            _second = sides[1];
            _third = sides[2];
        }
        
        /// <summary>���������� ������� ������������</summary>
        private double CalculateArea()
        {
            double semiperimeter = (_first + _second + _third) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - _first) * (semiperimeter - _second) * (semiperimeter - _third));
        }
    }
}