using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class Items : Sprite
{
    public Dictionary<int, Texture2D> eyes = new Dictionary<int, Texture2D>();
    public Dictionary<int, Texture2D> noses = new Dictionary<int, Texture2D>();
    public Dictionary<int, Texture2D> mouths = new Dictionary<int, Texture2D>();
    public int width,height;
    
    public Items(Texture2D tex, Vector2 pos) : base(tex,pos)
    {
        width=320;
        height=160;
    }
    public Rectangle ScaleItem(Vector2 pos,float scale)
    {
        int currentwidth= (int)(this.width*scale);
        int currentheight= (int)(this.height*scale);
        
        int offsetX= (currentwidth-this.width)/2; //scaled from center point
        int offsetY= (currentheight-this.height)/2;

        return new Rectangle((int)pos.X-offsetX,(int)pos.Y-offsetY,currentwidth,currentheight);

    }
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
        for (int i=1; i <=8; i++)
        {
            mouths.Add(i,Content.Load<Texture2D>("mouths/a"+i));
        }
    }
  
}
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