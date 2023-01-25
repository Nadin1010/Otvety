using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HHTaskLibrary.Circle;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HHTaskLibrary
{
    public class Circle : Shape //площадь круга по радиусу
    {
        public double Radius { get; set; }

        public Circle(string typeName, double radius) : base(typeName)
        {
            Radius = radius;
        }

        public override double Square()
        {
            return Math.Round(3.14f * Math.Pow(Radius, 2), 1);
        }

        public abstract class Shape
        {
            public string TypeName { get; set; }

            public Shape(string typeName)
            {
                TypeName = typeName;
            }

            public abstract double Square();

            public override string ToString()
            {
                return $"Текущий тип фигуры: " + TypeName; //здесь можно задать тип фигуры
            }

            public static class ShapePrototype
            {
                public static double Square(Shape shape)
                {
                    return shape.Square();
                }
            }
            public class Triangle : Shape //площадь треугольника по трем сторонам
            {
                public double EdgeA { get; set; }
                public double EdgeB { get; set; }
                public double EdgeC { get; set; }

                public Triangle(string typeName, double a, double b, double c) : base(typeName)
                {
                    if (isExist(a, b, c))
                    {
                        EdgeA = a;
                        EdgeB = b;
                        EdgeC = c;
                    }
                }

                public override double Square()
                {
                    var p = (EdgeA + EdgeB + EdgeC) / 2;
                    var square = Math.Sqrt(p * (p - EdgeA) * (p - EdgeB) * (p - EdgeC));
                    return square;
                }

                private bool isExist(double a, double b, double c) //исключения для треугольника
                {
                    if (a < 0 || b < 0 || c < 0)
                    {
                        throw new TriangleException("Такого треугольника не существует(сторона(ы) меньше 0)");
                    }

                    if (a > (b + c) || b > (a + c) || c > (a + b))
                    {
                        throw new TriangleException("Такого треугольника не существует(сторона больше суммы двух других)");
                    }

                    return true;
                }

                public bool isStraightTriangle() //проверка на то является ли треугольник прямоугольным
                {
                    bool isStraight = (EdgeA == Math.Sqrt(Math.Pow(EdgeB, 2) + Math.Pow(EdgeC, 2))
                                       || EdgeB == Math.Sqrt(Math.Pow(EdgeA, 2) + Math.Pow(EdgeC, 2))
                                       || EdgeC == Math.Sqrt(Math.Pow(EdgeA, 2) + Math.Pow(EdgeB, 2)));

                    return isStraight;
                }
            }
            public class TriangleException : Exception
            {
                public TriangleException(string message) : base(message)




        [TestClass]
                public class TriangleTests // юнит тесты
                {
                    [TestMethod]
                    public void isStraightTriangle_NotStraight_ReturnFalse()
                    {
                        //Arrange
                        var triangle = new Triangle("Треугольник", 2, 3, 4);

                        //Act
                        var result = triangle.isStraightTriangle();

                        //Assert
                        Assert.IsFalse(result);
                    }

                    [TestMethod]
                    public void Square_3and4and5_Return6()
                    {
                        //Arrange
                        var triangle = new Triangle("Треугольник", 3, 4, 5);
                        double expected = 6;

                        //Act
                        var result = triangle.Square();

                        //Assert
                        Assert.AreEqual(expected, result);
                    }
                }
                public class CircleTest
                {
                    [TestMethod]
                    public void Square_5_Return78_5()
                    {
                        //Arrange
                        var circle = new Circle("Круг", 5);
                        double expected = 78.5;

                        //Act
                        var result = circle.Square();

                        //Assert
                        Assert.AreEqual(expected, result);
                    }
                }

            }
        }
    } 
}

               
        
  
