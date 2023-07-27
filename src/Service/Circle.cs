using System;
using FlatGeometry.Interface;

namespace FlatGeometry.Service
{
    public class Circle : IFigure
    {
        private double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException($"{nameof(radius)} can 't be negative or zero value");
            Radius = radius;
        }

        public double GetPerimeter() => 2 * Math.PI * Radius;

        public double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }
}