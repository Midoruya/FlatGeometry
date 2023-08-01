using System;
using System.Collections.Generic;
using System.Linq;
using FlatGeometry.Interface;

namespace FlatGeometry.Service
{
    public class Triangle : IFigure
    {
        public double OneSide { get; }
        public double TwoSide { get; }
        public double ThreeSide { get; }
        private readonly Lazy<TriangleType> _type;
        public TriangleType Type => _type.Value;

        public Triangle(List<double> side)
        {
            List<double> copySide = side.ToList();
            if (copySide.Count > 3)
                throw new ArgumentException("Triangle can't have more than 3 sides");
            if (!copySide.TrueForAll(x => x > 0))
                throw new ArgumentException("Triangle sides can't negative value");
            copySide.Sort();
            ThreeSide = copySide[2];
            TwoSide = copySide[1];
            OneSide = copySide[0];

            if (OneSide + TwoSide <= ThreeSide) 
                throw new ArgumentException($"Invalid triangle {nameof(ThreeSide)} > amounts of other");
            if (ThreeSide + TwoSide <= OneSide) 
                throw new ArgumentException($"Invalid triangle {nameof(OneSide)} > amounts of other");
            if (ThreeSide + TwoSide <= TwoSide) 
                throw new ArgumentException($"Invalid triangle {nameof(TwoSide)} > amounts of other");
            
            _type = new Lazy<TriangleType>(GetTriangleType);
        }

        public double GetPerimeter() => OneSide + TwoSide + ThreeSide;

        public double GetArea()
        {
            var s = GetPerimeter() / 2;
            return Math.Sqrt(s * (s - OneSide) * (s - TwoSide) * (s - ThreeSide));
        }

        public TriangleType GetTriangleType() => (Math.Pow(OneSide, 2) - Math.Pow(ThreeSide, 2) - Math.Pow(TwoSide, 2)) switch
        {
            > Accuracy => TriangleType.Obtuse,
            < Accuracy and > -Accuracy => TriangleType.Right,
            < -Accuracy => TriangleType.Acute,
            _ => throw new ArgumentOutOfRangeException()
        };

        private const double Accuracy = 0.01;
    }
}