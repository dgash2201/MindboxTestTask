using FiguresLibrary.Figures;

namespace FiguresLibrary.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(3.0, 4.0, 5.0)]
        public void NotThrowWithCorrectSides(double first, double second, double third)
        {
            var exception = Record.Exception(() => new Triangle(first, second, third));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(-3.0, 4.0, 5.0)]
        [InlineData(3.0, -4.0, 5.0)]
        [InlineData(3.0, 4.0, -5.0)]
        public void ThrowsIfSideIsNegative(double first, double second, double third)
        {
            var message = $"Треугольник со сторонами {first}, {second}, {third} создан успешно, хотя некоторые из них отрицательные";
            Assert.Throws<ArgumentException>(() => new Triangle(first, second, third));
        }

        [Theory]
        [InlineData(3.0, 4.0, 7.0)]
        public void ThrowsIfTriangleUnequalityNotMet(double first, double second, double third)
        {
            var message = $"Треугольник со сторонами {first}, {second}, {third} создан успешно, хотя не соблюдено неравенство треугольника";
            Assert.Throws<ArgumentException>(() => new Triangle(first, second, third));
        }

        [Theory]
        [InlineData(3.0, 4.0, 5.0, 6.0)]
        public void CalculateAreaCorrectly(double first, double second, double third, double expected)
        {
            var actual = new Triangle(first, second, third).Area;
            Assert.Equal(expected, actual, double.Epsilon);
        }

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