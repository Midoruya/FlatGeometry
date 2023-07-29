using System;
using System.Collections;
using System.Collections.Generic;
using FlatGeometry.Service;
using Xunit;
using Xunit.Abstractions;

namespace FlatGeometry.Test
{
    public class CircleTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CircleTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(CircleData), parameters: true)]
        public void Error_init_circle(double radius, double resultPerimeter, double resultArea)
        {
            if (radius > 0)
                return;
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Theory]
        [MemberData(nameof(CircleData), parameters: false)]
        public void Correct_perimeter_calculations(double radius, double resultPerimeter, double resultArea)
        {
            if (radius <= 0)
                return;
            double perimeter = new Circle(radius).GetPerimeter();
            Assert.Equal((int)(perimeter * 10000), (int)(resultPerimeter * 10000));
        }

        [Theory]
        [MemberData(nameof(CircleData), parameters: false)]
        public void Correct_area_calculation(double radius, double resultPerimeter, double resultArea)
        {
            if (radius <= 0)
                return;
            double area = new Circle(radius).GetArea();
            Assert.Equal((int)(area * 10000), (int)(resultArea * 10000));
        }
        
        public static IEnumerable<Object[]> CircleData(bool isException = false)
        {
            if (isException)
            {
                yield return new object[] { -1.5, null, null };
                yield return new object[] { -1, null, null };
                yield return new object[] { -0.8, null, null };
                yield return new object[] { -0.2, null, null };
                yield return new object[] { 0, null, null };
                yield break;
            }
            yield return new object[] { 0.2, 1.25663706143592, 0.125663706143592 };
            yield return new object[] { 0.8, 5.02654824574367, 2.01061929829747 };
            yield return new object[] { 1, 6.28318530717959, 3.14159265358979 };
            yield return new object[] { 1.5, 9.42477796076938, 7.06858347057703 };
        }
    }
}