using System;
using System.Collections.Generic;
using System.Linq;
using FlatGeometry.Interface;

namespace FlatGeometry.Service
{
    public class Triangle : IFigure
    {
        public double LargeSide { get; }
        public double MediumSide { get; }
        public double SmallSide { get; }

        public Triangle(List<double> side)
        {
            List<double> copySide = side.ToList();
            if (!copySide.TrueForAll(x => x > 0))
                throw new ArgumentException("Triangle sides can't negative value");
            copySide.Sort();
            SmallSide = copySide[2];
            MediumSide = copySide[1];
            LargeSide = copySide[0];

            if (LargeSide + MediumSide <= SmallSide) 
                throw new ArgumentException($"Invalid triangle {nameof(SmallSide)} > amounts of other");
            if (SmallSide + MediumSide <= LargeSide) 
                throw new ArgumentException($"Invalid triangle {nameof(LargeSide)} > amounts of other");
            if (SmallSide + MediumSide <= MediumSide) 
                throw new ArgumentException($"Invalid triangle {nameof(MediumSide)} > amounts of other");
            
        }

        public double GetPerimeter() => LargeSide + MediumSide + SmallSide;

        public double GetArea()
        {
            var s = GetPerimeter() / 2;
            return Math.Sqrt(s * (s - LargeSide) * (s - MediumSide) * (s - SmallSide));
        }

        public TriangleType GetTriangleType() => (Math.Pow(LargeSide, 2) - Math.Pow(SmallSide, 2) - Math.Pow(MediumSide, 2)) switch
        {
            > Accuracy => TriangleType.Obtuse,
            < Accuracy and > -Accuracy => TriangleType.Right,
            < -Accuracy => TriangleType.Acute,
            _ => throw new ArgumentOutOfRangeException()
        };

        private const double Accuracy = 0.01;
    }
}