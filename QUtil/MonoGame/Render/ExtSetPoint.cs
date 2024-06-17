using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace QUtil.MonoGame.Render;

public static class ExtSetPoint
{
    /// <summary>
    /// sets a point at a specific location at the screen. Compile with flag <c>QUTIL_MONOGAME_RENDER_DISABLE_OUT_OF_RANGE_PROTECTION</c>
    /// </summary>
    /// <param name="pcl"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="colour"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetPoint(this PixelControlLayer pcl, int x, int y, Color colour)
    {
        if (x >= 0 && x < pcl.Width && y >= 0 && y < pcl.Height)
        {
            pcl.buffer[y * pcl.Width + x] = colour;
        }
    }
}