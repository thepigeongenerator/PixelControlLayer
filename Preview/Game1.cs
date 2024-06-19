using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThePigeonGenerator.MonoGame.Render;

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
                startPoint = new Point(m.Position.X, m.Position.Y);
                isPressing = true;
            }


            endPoint = new Point(m.Position.X, m.Position.Y);
            radius = (int)(startPoint - endPoint).ToVector2().Length();

            _pixelControlLayer.SetCircle(startPoint.X, startPoint.Y, radius, Color.White);
            _pixelControlLayer.SetBox(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, Color.Blue);
            _pixelControlLayer.SetLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, Color.Green);
            _pixelControlLayer.SetPoint(startPoint.X, startPoint.Y, Color.Red);
        }

        if (isPressing == true && m.LeftButton == ButtonState.Released)
        {
            startPoint = Point.Zero;
            endPoint = Point.Zero;
            isPressing = false;
        }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        _pixelControlLayer.Draw(_spriteBatch);

        _spriteBatch.End();
        _pixelControlLayer.ClearBuffer();

        base.Draw(gameTime);
    }
}
