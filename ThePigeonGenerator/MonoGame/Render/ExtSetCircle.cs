using System;
using Microsoft.Xna.Framework;

namespace ThePigeonGenerator.MonoGame.Render;

public static class ExtSetCircle
{
    /// <param name="pcl">the pixel control layer to set the circle to</param>
    /// <param name="centreX">the X coordinate for the centre of the circle</param>
    /// <param name="centreY">the Y coordinate for the centre of the circle</param>
    /// <param name="radius">specifies what radius the circle should be</param>
    /// <param name="colour">specifies what colour the circle should be</param>
    /// <param name="circlePointCache">if not <see langword="null"/>, uses this to cache the points of the circles drawn to improve performance at the cost of ram. Use this if a lot of the same circles are drawn.</param>
    /// <exception cref="IndexOutOfRangeException"/>
    public static void SetCircle(this PixelControlLayer pcl, int centreX, int centreY, int radius, Color colour)
    {
        int circumference = (int)(MathF.Tau * radius);

        //store assign points if a circle cache has been given
        Point[] points = null;

        for (int i = 0; i < circumference; i++)
        {
            (float fX, float fY) = MathF.SinCos(MathF.Tau / circumference * i);
            int x = (int)(fX * radius) + radius;
            int y = (int)(fY * radius) + radius;

            pcl.SetPoint(x + centreX - radius, y + centreY - radius, colour);

            if (points != null)
            {
                points[i] = new Point(x, y);
            }
        }
    }
}