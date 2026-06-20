using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class UI
{

    public static Texture2D head; // head size 250x250
    public static Texture2D bg, BestScore, Score;
    public static SpriteFont scoref, bscoref,title;


    public static void LoadUIs(ContentManager Content)
    {
        head = Content.Load<Texture2D>("face");
        Score = Content.Load<Texture2D>("score");
        BestScore = Content.Load<Texture2D>("bscore");
        bg = Content.Load<Texture2D>("bg");
        scoref = Content.Load<SpriteFont>("scoreF");
        bscoref = Content.Load<SpriteFont>("bscoreF");
        title = Content.Load<SpriteFont>("title");


    }

    public static void DrawScreen(SpriteBatch spriteBatch) //main screen size 480x800
    {
        spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 960), Color.White);
        spriteBatch.Draw(head, new Rectangle(400, 160, 800, 800), Color.White);
        spriteBatch.Draw(Score, new Rectangle(675, 0, 250, 100), Color.White);
        spriteBatch.Draw(BestScore, new Rectangle(1350, 0, 250, 150), Color.White);
        spriteBatch.DrawString(scoref,"0000",new Vector2(725,25), Color.White);
        spriteBatch.DrawString(bscoref,"0010",new Vector2(1420,80), Color.White);
        spriteBatch.DrawString(bscoref,"BEST",new Vector2(1410,10), Color.Crimson);
    }
    public static void DrawMenu(SpriteBatch spriteBatch)//use old textures
    {
        spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 960), Color.White);
        spriteBatch.DrawString(title,"FACE ROULETTE", new Vector2(400,200),Color.BlueViolet);
        spriteBatch.Draw(Score,new Rectangle(675, 480, 250, 100), Color.White); //same visual dont need to add new one
        spriteBatch.DrawString(scoref,"PLAY",new Vector2(750,500), Color.White);
    }


}