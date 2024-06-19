using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThePigeonGenerator.MonoGame.Render;

public class PixelControlLayer
{
    public readonly Texture2D texture;
    public Color[] buffer;


    /// <summary>
    /// creates the pixel control layer's internal texture, defines the texture's width and height automatically using <see cref="GraphicsDevice.Viewport"/>
    /// </summary>
    public PixelControlLayer(GraphicsDevice graphicsDevice)
    {
        texture = new(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        ClearBuffer();
    }

    /// <summary>
    /// creates the pixel control layer's internal texture, defines the texture's width and height manually
    /// </summary>
    public PixelControlLayer(GraphicsDevice graphicsDevice, int width, int height)
    {
        texture = new(graphicsDevice, width, height);
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
    public void Draw(SpriteBatch spriteBatch, Vector2? position = null)
    {
        //convert the colour array to a 2D texture
        texture.SetData(buffer);

        //draw the texture
        spriteBatch.Draw(texture, position.GetValueOrDefault(Vector2.Zero), Color.White);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ClearBuffer()
    {
        buffer = new Color[Width * Height];
    }
}
