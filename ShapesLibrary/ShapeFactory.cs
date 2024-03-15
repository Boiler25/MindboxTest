using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLibrary
{
    public class ShapeFactory
    {
        public static IShape CreateShape(params double[] parameters)
        {
            if (parameters.Length == 1)
            {
                if (parameters[0] <= 0)
                    throw new ArgumentException("Радиус должен быть положительным числом.", nameof(parameters));

                return new Circle(parameters[0]);
            }

            if (parameters.Length == 3)
            {
                if (parameters[0] <= 0 || parameters[1] <= 0 || parameters[2] <= 0)
                    throw new ArgumentException("Длины сторон должны быть положительными числами.");

                if (parameters[0] + parameters[1] <= parameters[2] ||
                    parameters[0] + parameters[2] <= parameters[1] ||
                    parameters[1] + parameters[2] <= parameters[0])
                    throw new ArgumentException("Треугольник с такими сторонами не существует.");

                return new Triangle(parameters[0], parameters[1], parameters[2]);
            }

            throw new ArgumentException("Некорректное количество параметров.");
        }
    }
}
