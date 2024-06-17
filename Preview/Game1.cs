using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QUtil.MonoGame.Render;

namespace Preview;

public class Game1 : Game
{
    private readonly Dictionary<int, (int, int)[]> _boxCache;
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private PixelControlLayer _pixelControlLayer;
    private bool isPressing;
    private Point startPoint;
    private Point endPoint;
    private int radius;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _boxCache = new();
        isPressing = false;
    }

    protected override void Initialize()
    {
        _pixelControlLayer = new PixelControlLayer(_graphics.GraphicsDevice);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        MouseState m = Mouse.GetState();
        if (m.LeftButton == ButtonState.Pressed)
        {
            if (isPressing == false)
            {
                startPoint = new Point(
                    Math.Clamp(m.Position.X, 0, _graphics.GraphicsDevice.Viewport.Width - 1),
                    Math.Clamp(m.Position.Y, 0, _graphics.GraphicsDevice.Viewport.Height - 1));
                isPressing = true;
            }

            endPoint = new Point(
                Math.Clamp(m.Position.X, 0, _graphics.GraphicsDevice.Viewport.Width - 1),
                Math.Clamp(m.Position.Y, 0, _graphics.GraphicsDevice.Viewport.Height - 1)
            );
            radius = (int)(startPoint - endPoint).ToVector2().Length();
            radius = Math.Clamp(radius, 0, Math.Min(
                Math.Min(startPoint.X, _graphics.GraphicsDevice.Viewport.Width - startPoint.X),
                Math.Min(startPoint.Y, _graphics.GraphicsDevice.Viewport.Height - 1 - startPoint.Y)));
        }

        if (m.LeftButton == ButtonState.Released)
        {
            if (isPressing == true)
            {
                startPoint = Point.Zero;
                endPoint = Point.Zero;
                isPressing = false;
            }
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        if (isPressing)
        {
            //_pixelControlLayer.SetLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, Color.White);
            //_pixelControlLayer.SetBox(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, Color.White);
            _pixelControlLayer.SetCircle(startPoint.X, startPoint.Y, radius, Color.White);
        }
        _pixelControlLayer.Draw(_spriteBatch);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
