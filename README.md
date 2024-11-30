# `ThePigeonGenerator.MonoGame.PixelControlLayer`

A library to allow for setting individual pixels in a MonoGame project. Is easily extendable with your own functions for more advanced drawing.

## Installation
### Windows in Visual Studio:
1. Follow the steps [here](https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio#nuget-package-manager).
2. Search the package namespace seen above.
### Universal:
1. Select the [package](https://github.com/thepigeongenerator/PixelControlLayer/pkgs/nuget/ThePigeonGenerator.MonoGame.Render) under the `Packages` tab on the right.
2. Select the version you'd like to install
3. Run the command listed above in the directory of the project you wish to install the package in.

| Default* Extensions                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `SetPoint`(`this` [`PixelControlLayer`](./docs/PixelControlLayer.md) pcl, `int` x, `int` y, [`Color`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Color.html) colour)                      |
| `SetLine`(`this` [`PixelControlLayer`](./docs/PixelControlLayer.md) pcl, `int` x1, `int` y1, `int` x2, `int` y2, [`Color`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Color.html) colour) |
| `SetBox`(`this` [`PixelControlLayer`](./docs/PixelControlLayer.md) pcl, `int` x1, `int` y1, `int` x2, `int` y2, [`Color`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Color.html) colour)  |
| `SetCircle`(`this` [`PixelControlLayer`](./docs/PixelControlLayer.md) pcl, `int` centreX, `int` centreY, [`Color`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Color.html) colour)         |

_\*It is possible to add more extensions yourself; read more about the different components you're able to modify in [`PixelControlLayer`](./docs/PixelControlLayer.md)_

## Example

```cs
protected override void Initialize()
{
    // define the pixel control layer using the graphics device to set the correct internal texture size
    _pixelControlLayer = new PixelControlLayer(_graphics.GraphicsDevice);

    // OR: define your own size
    _pixelControlLayer = new PixelControlLayer(_graphics.GraphicsDevice, 64, 64);

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

    _pixelControlLayer.Draw(_spriteBatch); // assumes the default position of (0, 0)

    _spriteBatch.End();
    _pixelControlLayer.ClearBuffer(); // clear the internal buffer *after* drawing, otherwise it'll fail to draw

    base.Draw(gameTime);
}
```
