using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class InGame : IScene
{
    public Texture2D head; // head original size 250x250
    public  Texture2D bscore, score;
    public  SpriteFont scoref, bscoref;
    public void LoadUIs(ContentManager Content)
    {
        head = Content.Load<Texture2D>("face");
        score = Content.Load<Texture2D>("button");
        bscore = Content.Load<Texture2D>("bscore");
        scoref = Content.Load<SpriteFont>("scoreF");
        bscoref = Content.Load<SpriteFont>("bscoreF");
    }

    public void Update(GameTime gameTime)
    {
        
    }

     public void DrawScreen(SpriteBatch spriteBatch) //main screen original size 480x800
    {
        spriteBatch.Draw(head, new Rectangle(400, 160, 800, 800), Color.White);
        spriteBatch.Draw(score, new Rectangle(675, 0, 250, 100), Color.White);
        spriteBatch.Draw(bscore, new Rectangle(1350, 0, 250, 150), Color.White);
        spriteBatch.DrawString(scoref, "0000", new Vector2(725, 25), Color.White);
        spriteBatch.DrawString(bscoref, "0010", new Vector2(1420, 80), Color.White);
        spriteBatch.DrawString(bscoref, "BEST", new Vector2(1410, 10), Color.Crimson);
    }
}