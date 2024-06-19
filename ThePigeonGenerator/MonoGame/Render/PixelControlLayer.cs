using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThePigeonGenerator.MonoGame.Render;

public class PixelControlLayer
{
    public readonly Texture2D texture;
    public Color[] buffer;

    public PixelControlLayer(GraphicsDevice graphicsDevice)
    {
        texture = new(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        ClearBuffer();
    }

    public int Height
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => texture.Bounds.Height;
    }

    public int Width
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => texture.Bounds.Width;
    }

    /// <summary>
    /// Draws the set colours to the screen and clears the internal buffer
    /// </summary>
    public void Draw(SpriteBatch spriteBatch)
    {
        //convert the colour array to a 2D texture
        texture.SetData(buffer);

        //draw the texture
        spriteBatch.Draw(texture, Vector2.Zero, Color.White);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ClearBuffer()
    {
        buffer = new Color[Width * Height];
    }
}
