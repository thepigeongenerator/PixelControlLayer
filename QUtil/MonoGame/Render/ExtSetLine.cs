using System;
using Microsoft.Xna.Framework;

namespace QUtil.MonoGame.Render;

public static class ExtSetLine
{
    /// <param name="pcl">the pixel control layer to set the line to</param>
    /// <param name="x1">the X coordinate of the start of the line</param>
    /// <param name="y1">the Y coordinate of the start of the line</param>
    /// <param name="x2">the X coordinate of the end of the line</param>
    /// <param name="y2">the Y coordinate of the end of the line</param>
    /// <param name="colour">specifies what colour the line should be</param>
    public static void SetLine(this PixelControlLayer pcl, int x1, int y1, int x2, int y2, Color colour)
    {
        // calculate the distance to travel on each coordinate
        int dx = x2 - x1;
        int dy = y2 - y1;

        // calculate the ammount of steps to take and the incrementation for each axis
        // if division by 0; the value becomes NaN, so it won't cause any problems
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
        float ix = dx / (float)steps;
        float iy = dy / (float)steps;

        // set start position for each axis
        float x = x1;
        float y = y1;

        // for each step; set the point and increment the coordinate by the specified amount.
        for (int i = 0; i <= steps; i++)
        {
            pcl.SetPoint((int)x, (int)y, colour);
            x += ix;
            y += iy;
        }
    }
}