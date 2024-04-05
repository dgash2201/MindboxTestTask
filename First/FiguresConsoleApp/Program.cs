using FigureLibrary.Figures;

namespace FiguresConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Circle(7.0);

            Console.WriteLine("Площадь круга:{0}", figure.Area);
            
            figure = new Triangle(3, 4, 5);

            Console.WriteLine("Площадь триугольника: {0}", figure.Area);
        }
    }
}
