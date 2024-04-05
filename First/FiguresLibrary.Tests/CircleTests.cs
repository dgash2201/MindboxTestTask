using FigureLibrary.Figures;

namespace FigureLibrary.Tests
{
    public class CircleTests
    {
        /// <summary>
        /// Исключение не выбрасывается, если радиус круга корректен
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        [Theory]
        [InlineData(1.0)]
        public void NotThrowIfRadiusIsCorrect(double radius)
        {
            var exception = Record.Exception(() => new Circle(radius));
            Assert.Null(exception);
        }

        /// <summary>
        /// Выбрасывается исключение, если радиус круга неположителен
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        [Theory]
        [InlineData(0.0)]
        [InlineData(-2.0)]
        public void ThrowsIfRadiusIsNotPositive(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        /// <summary>
        /// Высчитывается ли площадь корретно
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <param name="expected">Ожидаемое значение площади</param>
        [Theory]
        [InlineData(1.0, Math.PI)]
        public void CalculateAreaCorrectly(double radius, double expected)
        {
            var actual = new Circle(radius).Area;
            Assert.Equal(expected, actual, double.Epsilon);
        }
    }
}