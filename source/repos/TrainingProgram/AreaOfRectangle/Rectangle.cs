namespace AreaOfShapes
{
    public class Rectangle
    {
        public float Length { get; set; }
        public float Breath { get; set; }

        public double AreaOfRectangle()
        {
            return Length * Breath;
        }
    }
}
