using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class InGame : IScene
{
    public Texture2D head; // head original size 250x250
    public  Texture2D bscore, score;
    public  SpriteFont scoref, bscoref,count;
    public int currentscore=0;
    private List<int> scores= new List<int>(){0};
    Face face;
    Items items;
    private Scene scene;
    ItemMovement itemMove;
    private bool isNewLvl=false;
    private MouseState laststate;
    
    public InGame(Scene currentScene)
    {
        this.scene = currentScene;
    }
    public void LoadUIs(ContentManager Content)
    {
        head = Content.Load<Texture2D>("face");
        score = Content.Load<Texture2D>("button");
        bscore = Content.Load<Texture2D>("bscore");
        scoref = Content.Load<SpriteFont>("scoreF");
        bscoref = Content.Load<SpriteFont>("bscoreF");
        count= Content.Load<SpriteFont>("count");
        
        face= new Face();
        items= new Items(null,Vector2.Zero);
        
        items.LoadItems(Content);
        face.CreateFace(items.eyes, items.noses, items.mouths);
        itemMove=face.itemM;

        isNewLvl=true;
        laststate=Mouse.GetState();
    }
    public void NewLevel()
    {
        if(face.CheckFace())
        {
            currentscore++;
            if(currentscore>scores.Max())
            {
               scores.Add(currentscore); 
            }
            itemMove.Reset();
            if(items != null)
            {
               face.CreateFace(items.eyes,items.noses,items.mouths);  
            }
           
        }
        else
        {
            currentscore=0;
            scene.ChangeState("lose");
        }
    }

    public void Update(GameTime gameTime)
    {
        if(isNewLvl && face != null)
        {
            face.GameTour(gameTime);
            if(itemMove!=null &&face.time>=(face.display+face.fadetime))
            {
                if(itemMove.stage<3)
                {
                   CheckClicked();
                }
                
                if(itemMove.stage==3)
                {
                    NewLevel();
                }
            }
        }
    }

    public void CheckClicked()
    {
        MouseState mouse= Mouse.GetState();
        if(mouse.LeftButton== ButtonState.Pressed && laststate.LeftButton==ButtonState.Released)
        {
            switch(itemMove.stage)
            {
                case 0: if(LockItem(itemMove.Currenteyes,itemMove.eyeways))
                    {}break;
                case 1:if(LockItem(itemMove.Currentnoses,itemMove.noseways))
                    {}break;
                 case 2:if(LockItem(itemMove.Currentmouths,itemMove.mouthways))
                    {}break;
            }
            
        }
        laststate=mouse;
    }

    private bool LockItem(Moving[] movingitem,Vector2[] ways)
    {
        int selecteditem= -1; //nothing selected
        
        for(int i=0; i<4; i++)
        {
            if(movingitem[i].isonScreen && movingitem[i].targetway==2) // if it is go to target pos
            {
                selecteditem=i;
                break;
            }
        }
        if(selecteditem!=-1)
        {
            for (int i=0; i<4;i++)
            {
                if(i==selecteditem)
                {
                    movingitem[i].currentscale=1.0f; //turning normal scale
                    movingitem[i].isselected=true;
                }
                else
                {
                    movingitem[i].isonScreen=false;
                }
            }
            return true;
        }

        return false;
    }

     public void DrawScreen(SpriteBatch spriteBatch) //main screen 1600x960
    {
        spriteBatch.Draw(head, new Rectangle(400, 160, 800, 800), Color.White);
        spriteBatch.Draw(score, new Rectangle(675, 0, 250, 100), Color.White);
        spriteBatch.Draw(bscore, new Rectangle(1350, 0, 250, 150), Color.White);
        spriteBatch.DrawString(scoref, currentscore.ToString("D4"), new Vector2(725, 25), Color.White);
        int bestscore=scores[^1];
        spriteBatch.DrawString(bscoref, bestscore.ToString("D4"), new Vector2(1420, 80), Color.White);
        spriteBatch.DrawString(bscoref, "BEST", new Vector2(1410, 10), Color.Crimson);
       if(isNewLvl && face!=null && face.itemM != null)
        {
            if(face.time <(face.display + face.fadetime)) 
            {
                face.DrawFace(spriteBatch,count);
            }
            else // show items after face showned
            {
                itemMove.DrawItems(spriteBatch);
            }
            
        }
        
    }
}