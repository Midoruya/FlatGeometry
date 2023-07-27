using System.ComponentModel;

namespace FlatGeometry
{
    public enum TriangleType
    {
        [Description("all angles < 90")]
        Acute,
        [Description("One angle > 90")]
        Obtuse,
        [Description("One angle equal to 90")]
        Right,
    }
}