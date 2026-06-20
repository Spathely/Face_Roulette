using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite
{
    public Texture2D texture;
    public Vector2 position;

    public Sprite(Texture2D tex,Vector2 pos)
    {
        texture= tex;
        position=pos;
    }
}