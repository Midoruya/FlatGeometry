using System;
using System.Collections.Generic;
using System.Linq;
using FlatGeometry.Service;
using Xunit;
using Xunit.Abstractions;

namespace FlatGeometry.Test
{
    public class TriangleTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TriangleTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(TriangleNotInitData))]
        public void Error_init_triangle(List<double> side)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(side));
        }

        [Theory]
        [MemberData(nameof(TriangleData))]
        public void Correct_perimeter_calculations(List<double> side, double resultPerimeter, double resultArea, TriangleType type)
        {
            Triangle triangle = new Triangle(side);
            Assert.Equal((int)(triangle.GetPerimeter() * 10000), (int)(resultPerimeter * 10000));
        }
        
        [Theory]
        [MemberData(nameof(TriangleData))]
        public void Correct_area_calculations(List<double> side, double resultPerimeter, double resultArea, TriangleType type)
        {
            Triangle triangle = new Triangle(side);
            Assert.Equal((int)(triangle.GetArea() * 10000), (int)(resultArea * 10000));
        }
        
        [Theory]
        [MemberData(nameof(TriangleData))]
        public void Correct_triangle_type(List<double> side, double resultPerimeter, double resultArea, TriangleType type)
        {
            Triangle triangle = new Triangle(side);
            Assert.Equal(triangle.GetTriangleType(), type);
            Assert.Equal(triangle.Type, type);
        }
        
        public static IEnumerable<Object[]> TriangleData()
        {
            yield return new object[] { new List<double> { 28, 46, 51 }, 125, 639.647119512001, TriangleType.Acute };
            yield return new object[] { new List<double> { 23, 23, 23 }, 69, 229.063719300984, TriangleType.Acute };
        }
        public static IEnumerable<Object[]> TriangleNotInitData()
        {
            yield return new object[] { new List<double> { -1, 0, 0, 4 } };
            yield return new object[] { new List<double> { -1, 0, 0 } };
            yield return new object[] { new List<double> { -0.8, 0, 0 } };
            yield return new object[] { new List<double> { -0.2, 0, 0 } };
            yield return new object[] { new List<double> { 0, 0, 0 } };
            yield return new object[] { new List<double> { 1, 0, 0 } };
            yield return new object[] { new List<double> { 1, -1, 0 } };
            yield return new object[] { new List<double> { 1, -0.8, 0 } };
            yield return new object[] { new List<double> { 1, -0.2, 0 } };
            yield return new object[] { new List<double> { 1, 0, 0, } };
            yield return new object[] { new List<double> { 1, 1, 0, } };
            yield return new object[] { new List<double> { 1, 1, -1 } };
            yield return new object[] { new List<double> { 1, 1, -0.8 } };
            yield return new object[] { new List<double> { 1, 1, -0.2 } };
            yield return new object[] { new List<double> { 1, 1, 0 } };
            yield return new object[] { new List<double> { 5, 3, 8 } };
        }
    }
}