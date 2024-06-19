#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ThePigeonGenerator.MonoGame.Render;

public static class ExtSetBox
{
    /// <param name="pcl">the pixel control layer to set the box to</param>
    /// <param name="x1">X position of corner 1</param>
    /// <param name="y1">Y position of corner 1</param>
    /// <param name="x2">X position of corner 2</param>
    /// <param name="y2">Y position of corner 2</param>
    /// <param name="colour">specifies what colour the box should be</param>
    /// <param name="boxPointCashe">if not <see langword="null"/>, uses this to cache the points of the boxes drawn to improve performance at the cost of ram. Use this if a lot of the same boxes are drawn.</param>
    /// <exception cref="IndexOutOfRangeException"/>
    public static void SetBox(this PixelControlLayer pcl, int x1, int y1, int x2, int y2, Color colour, Dictionary<int, Point[]>? boxPointCashe = null)
    {
        int originX = Math.Min(x1, x2);         //gets the origin in the X position
        int originY = Math.Min(y1, y2);         //gets the origin in the Y position
        int width = Math.Abs(x1 - x2);          //the absolute width
        int height = Math.Abs(y1 - y2);         //the absolute height
        int boxIndex = (width * 2) + height;    //the index at which the will be stored


        //use the box point cache, if available
        if (boxPointCashe != null && boxPointCashe.TryGetValue(boxIndex, out Point[]? cachedPoints))
        {
            //set the cached points
            for (int i = 0; i < cachedPoints.Length; i++)
            {
                pcl.SetPoint(cachedPoints[i].X + originX, cachedPoints[i].Y + originY, colour);
            }

            //done; just return
            return;
        }

        int index = 0;
        var points = new Point[(width << 1) + (height << 1)]; //bit shift, same as multiplying by 2 but negligably faster (the best kind of faster)

        //loop through the X axis of the box drawn
        for (int x = 0; x <= width; x++) // smaller than or equal to, in order to include the last corner
        {
            int posX = x + originX;
            pcl.SetPoint(posX, originY, colour);
            pcl.SetPoint(posX, originY + height, colour);

            if (boxPointCashe != null)
            {
                points[index] = new Point(x, 0);
                index++;

                points[index] = new Point(x, height);
                index++;
            }
        }

        //loop through the Y axis of the box drawn
        for (int y = 1; y < height; y++) //start at 1 in order to prevent overlap
        {
            //set the points
            int posY = y + originY;
            pcl.SetPoint(originX, posY, colour);
            pcl.SetPoint(originX + width, posY, colour);

            if (boxPointCashe != null)
            {
                points[index] = new Point(0, y);
                index++;

                points[index] = new Point(width, y);
                index++;
            }
        }

        if (boxPointCashe != null)
        {
            //add the newly created box to the storage
            boxPointCashe.Add(boxIndex, points);
        }
    }
}