using FigureLibrary.Figures;

namespace FigureLibrary.Tests
{
    public class TriangleTests
    {
        /// <summary>
        /// Исключение не выбрасывается, если длины сторон треугольника корректны
        /// </summary>
        /// <param name="first">Значение длины первой стороны треугольника</param>
        /// <param name="second">Значение длины второй стороны треугольника</param>
        /// <param name="third">Значение длины третьей стороны треугольника</param>
        [Theory]
        [InlineData(3.0, 4.0, 5.0)]
        public void NotThrowWithCorrectSides(double first, double second, double third)
        {
            var exception = Record.Exception(() => new Triangle(first, second, third));
            Assert.Null(exception);
        }

        /// <summary>
        /// Выбрасывается исключение, если длина какой-либо из сторон треугольника отрицательна
        /// </summary>
        /// <param name="first">Значение длины первой стороны треугольника</param>
        /// <param name="second">Значение длины второй стороны треугольника</param>
        /// <param name="third">Значение длины третьей стороны треугольника</param>
        [Theory]
        [InlineData(-3.0, 4.0, 5.0)]
        [InlineData(3.0, -4.0, 5.0)]
        [InlineData(3.0, 4.0, -5.0)]
        public void ThrowsIfSideIsNegative(double first, double second, double third)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(first, second, third));
        }

        /// <summary>
        /// Выбрасывается исключение, если не соблюдено неравенство треугольника
        /// </summary>
        /// <param name="first">Значение длины первой стороны треугольника</param>
        /// <param name="second">Значение длины второй стороны треугольника</param>
        /// <param name="third">Значение длины третьей стороны треугольника</param>
        [Theory]
        [InlineData(3.0, 4.0, 7.0)]
        public void ThrowsIfTriangleUnequalityNotObserved(double first, double second, double third)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(first, second, third));
        }


        /// <summary>
        /// Высчитывается ли площадь корректно
        /// </summary>
        /// <param name="first">Значение длины первой стороны треугольника</param>
        /// <param name="second">Значение длины второй стороны треугольника</param>
        /// <param name="third">Значение длины третьей стороны треугольника</param>
        /// <param name="expected">Ожидаемое значение площади</param>
        [Theory]
        [InlineData(3.0, 4.0, 5.0, 6.0)]
        public void CalculateAreaCorrectly(double first, double second, double third, double expected)
        {
            var actual = new Triangle(first, second, third).Area;
            Assert.Equal(expected, actual, double.Epsilon);
        }

        /// <summary>
        /// Корректно ли работает проверка на то, прямоугольный ли треугольник
        /// </summary>
        /// <param name="first">Значение длины первой стороны треугольника</param>
        /// <param name="second">Значение длины второй стороны треугольника</param>
        /// <param name="third">Значение длины третьей стороны треугольника</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Theory]
        [InlineData(3.0, 4.0, 5.0, true)]
        [InlineData(3.0, 4.0, 6.0, false)]
        public void IsRightWorksCorrectly(double first, double second, double third, bool expected)
        {
            var actual = new Triangle(first, second, third).IsRight;
            Assert.Equal(expected, actual);
        }
    }
}