using System;
using Microsoft.Xna.Framework;

namespace QUtil.MonoGame.Render;

public static class ExtSetLine
{
    //TODO: too eepy to figure this out, it does work. But you should go read and understand this:
    //https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
    public static void SetLine(this PixelControlLayer pcl, int x1, int y1, int x2, int y2, Color colour)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;
        int d = 2 * dx - dy;

        int y = y1;

        for (int x = x1; x < x2; x++)
        {
            pcl.SetPoint(x, y, colour);

            if (d > 0)
            {
                y++;
                d -= 2 * dx;
            }

            d += 2 * dy;
        }
        throw new NotImplementedException();
    }
}