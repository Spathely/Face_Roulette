using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
public class Items : Sprite
{
    public Dictionary<int, Texture2D> eyes = new Dictionary<int, Texture2D>();
    public Dictionary<int, Texture2D> noses = new Dictionary<int, Texture2D>();
    public Dictionary<int, Texture2D> mouths = new Dictionary<int, Texture2D>();
    
    public Items(Texture2D tex, Vector2 pos) : base(tex,pos) { }
     public void LoadItems(ContentManager Content)
    {
        for (int i=1; i <=12; i++)
        {
            eyes.Add(i,Content.Load<Texture2D>("eyes/g"+i));
        }
        for (int i=1; i <=8; i++)
        {
            noses.Add(i,Content.Load<Texture2D>("noses/b"+i));
        }
    }
  
}