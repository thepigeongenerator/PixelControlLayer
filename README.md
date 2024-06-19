# ThePigeonGenerator.MonoGame.PixelControlLayer

## Default Extensions

- `SetBox(this PixelControlLayer pcl, int x1, int y1, int x2, int y2, Color colour)`
- `SetCircle(this PixelControlLayer pcl, int centreX, int centreY, Color colour)`
- `SetLine(this PixelControlLayer pcl, int x1, int y1, x2, y2, Color colour)`
- `SetPoint(this PixelControlLayer pcl, int x, int y, Color colour)`

It is possible to add more extensions yourself; read more about the different components you're able to modify in [`PixelControlLayer`](./docs/PixelControlLayer.md)

## Example

```cs
protected override void Initialize()
{
    // define the pixel control layer using the graphics device to set the correct internal texture size
    _pixelControlLayer = new PixelControlLayer(_graphics.GraphicsDevice);

    base.Initialize();
}
```

```cs
protected override void Update()
{
    // draw something to the pixel control layer
    _pixelControlLayer.SetCircle(50, 50, 10, Color.Red);

    base.Update(gameTime);
}
```

```cs
protected override void Draw(GameTime gameTime)
{
    GraphicsDevice.Clear(Color.Black);

    _spriteBatch.Begin();

    _pixelControlLayer.Draw(_spriteBatch);

    _spriteBatch.End();
    _pixelControlLayer.ClearBuffer(); // clear the internal buffer *after* drawing, otherwise it'll fail to draw

    base.Draw(gameTime);
}
```
