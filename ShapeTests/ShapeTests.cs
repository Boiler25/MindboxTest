using NUnit.Framework;
using NUnit.Framework.Legacy;
using ShapesLibrary;

namespace ShapeTests
{
    public class ShapeTests
    {
        [Test]
        public void CircleAreaCalculation()
        {
            Circle circle = new Circle(5);
            ClassicAssert.AreEqual(Math.PI * 25, circle.GetArea(), 0.001); // Погрешность 0.001
        }

        [Test]
        public void CircleNegativeRadius()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-5));
        }

        [Test]
        public void TriangleAreaCalculation()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            ClassicAssert.AreEqual(6, triangle.GetArea(), 0.001); // Погрешность 0.001
        }

        [Test]
        public void TriangleNegativeSide()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-3, 4, 5));
        }

        [Test]
        public void TriangleNonexistentTriangle()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 5));
        }

        [Test]
        public void RightAngleTriangleCheck()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            ClassicAssert.IsTrue(triangle.IsRightAngleTriangle());

            Triangle triangle2 = new Triangle(5, 12, 13);
            ClassicAssert.IsTrue(triangle2.IsRightAngleTriangle());

            Triangle triangle3 = new Triangle(5, 6, 7);
            ClassicAssert.IsFalse(triangle3.IsRightAngleTriangle());
        }

        [Test]
        public void ShapeFactoryTest()
        {
            IShape circle = ShapeFactory.CreateShape(5);
            ClassicAssert.IsTrue(circle is Circle);

            IShape triangle = ShapeFactory.CreateShape(3, 4, 5);
            ClassicAssert.IsTrue(triangle is Triangle);

            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(0)); // Проверка некорректного радиуса
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(-5)); // Проверка отрицательного радиуса
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(3, 4, -5)); // Проверка отрицательной стороны треугольника
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(1, 2, 5)); // Проверка невозможных сторон треугольника
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(1, 2, 3, 4)); // Проверка некорректного количества параметров
        }
    }
}