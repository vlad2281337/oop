using System;
using System.Collections.Generic;
using System.Text;

namespace _09
{
    public class Rectangle
    {
        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        private double RightX => X + Width;

        private double BottomY => Y + Height;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        public bool IntersectsWith(Rectangle rectangle)
            => FirstIntersectsSecond(this, rectangle) || FirstIntersectsSecond(rectangle, this);


        // Check if top left or top right point of first is inside the second 
        private static bool FirstIntersectsSecond(Rectangle first, Rectangle second)
            => first.X >= second.X && first.X <= second.RightX &&
                (second.Y >= first.Y && second.Y <= first.BottomY ||
                    second.BottomY >= first.Y && second.BottomY <= first.BottomY);
    }
}
