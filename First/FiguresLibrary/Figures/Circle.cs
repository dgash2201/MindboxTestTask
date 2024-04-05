using System;
using System.IO;

namespace FigureLibrary.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : IFigure
    {
        private readonly double _radius;

        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius => _radius;

        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Area => CalculateArea();

        /// <summary>
        /// Создать круг
        /// </summary>
        /// <param name="radius">Длина радиуса. Положительное число</param>
        /// <exception cref="ArgumentException">Если радиус меньше или равен нулю</exception>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException($"Нельзя создать круг с таким радиусом : {radius} - неположительное число");
            }
                
            _radius = radius;
        }

        private double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}