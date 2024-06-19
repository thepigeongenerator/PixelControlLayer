# `ThePigeonGenerator.MonoGame.Render.PixelControlLayer`

`PixelControlLayer`([`GraphicsDevice`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.GraphicsDevice.html))
`PixelControlLayer`([`GraphicsDevice`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.GraphicsDevice.html), `int`, `int`)

## fields

| Definition                                                                                                      | Summary                                     |
| --------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| `readonly` [`Texture2D`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.Texture2D.html) texture | the buffer as a texture for drawing.        |
| `readonly` [`Color`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Color.html) buffer                              | stores the state of each pixel as an array. |
| `readonly` `int` `Width`                                                                                        | shorthand to get the texture's width.       |
| `readonly` `int` `Height`                                                                                       | shorthand to get the texture's height.      |


## methods
| Definition                                                                                                                    | Summary                                   |
| ----------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------- |
| `void` `Draw`([`SpriteBatch`](https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html) `spriteBatch`) | Draws `texture` using `spritebatch`       |
| `void` `ClearBuffer`()                                                                                                        | Shorthand for clearing `buffer`           |
