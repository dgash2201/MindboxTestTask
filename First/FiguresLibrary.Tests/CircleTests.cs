using FiguresLibrary.Figures;

namespace FiguresLibrary.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1.0)]
        public void NotThrowIfRadiusIsCorrect(double radius)
        {
            var exception = Record.Exception(() => new Circle(radius));
            Assert.Null(exception);
        }


        [Theory]
        [InlineData(0.0)]
        [InlineData(-2.0)]
        public void ThrowsIfRadiusIsNotPositive(double radius)
        {
            var message = $"Круг с радиусом {radius} создан успешно, хотя он неположительный";
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Theory]
        [InlineData(1.0, Math.PI)]
        public void CalculateAreaCorrectly(double radius, double expected)
        {
            var actual = new Circle(radius).Area;
            Assert.Equal(expected, actual, double.Epsilon);
        }
    }
}