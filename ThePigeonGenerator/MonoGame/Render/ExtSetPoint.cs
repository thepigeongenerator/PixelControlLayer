using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace ThePigeonGenerator.MonoGame.Render;

public static class ExtSetPoint
{
    /// <param name="pcl">the pixel control layer to set the pixel to</param>
    /// <param name="colour">sets the colour of the pixel</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetPoint(this PixelControlLayer pcl, int x, int y, Color colour)
    {
        if (x >= 0 && x < pcl.Width && y >= 0 && y < pcl.Height)
        {
            pcl.buffer[y * pcl.Width + x] = colour;
        }
    }
}