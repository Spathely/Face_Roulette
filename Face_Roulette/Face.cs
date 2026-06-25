using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class Face
{
    Items item= new Items(null,Vector2.Zero);
    public ItemMovement itemM;
    public Random random = new Random();
    public float display = 3.0f; // time of face showing
    public float faceopacity = 1.0f,eyeopacity= 1.0f,noseopacity= 1.0f,mouthopacity=1.0f;
    public float time = 0f, fadetime = 0.3f; // for disappearing
    public string Countdown= "3";
    public Texture2D targetEye, targetNose, targetMouth;
    public Dictionary<int, Texture2D> choseneyes = new Dictionary<int, Texture2D>(),
                                      chosennoses = new Dictionary<int, Texture2D>(),
                                      chosenmouths = new Dictionary<int, Texture2D>();
                
  
    public float turntime=0f, turnDuration= 3.0f; 

    public Face()
    {
        itemM= new ItemMovement(this,item);
    }
    public void CreateFace(Dictionary<int, Texture2D> eyes, Dictionary<int, Texture2D> noses, Dictionary<int, Texture2D> mouths) //create random face
    {
        choseneyes.Clear(); chosennoses.Clear(); chosenmouths.Clear();
        time = 0f;
        faceopacity = 1.0f;
        int EID = 1; int NID = 1; int MID = 1; // chosen items no's

        while (choseneyes.Count < 4)//EYE
        {
            Texture2D eyeT = eyes[random.Next(1, 13)];

            if (!choseneyes.ContainsValue(eyeT))
            {
                choseneyes.Add(EID, eyeT); //1,g4 tex (example)
                EID++;
            }
        }

        while (chosennoses.Count < 4)//NOSE
        {
            Texture2D noseT = noses[random.Next(1, 9)];

            if (!chosennoses.ContainsValue(noseT))
            {
                chosennoses.Add(NID, noseT);
                NID++;
            }
        }
        while (chosenmouths.Count < 4)//MOUTHS
        {
            Texture2D mouthT = mouths[random.Next(1, 9)];

            if (!chosenmouths.ContainsValue(mouthT))
            {
                chosenmouths.Add(MID, mouthT);
                MID++;
            }
        }

        targetEye = choseneyes[random.Next(1, 5)];
        targetNose = chosennoses[random.Next(1, 5)];
        targetMouth= chosenmouths[random.Next(1,5)];
        if (itemM != null)
        {
            itemM.Reset();
        }


    }
    public void DrawFace(SpriteBatch sp,SpriteFont count)// draw random face
    {
        if (time< display)//for countdown
        {
            sp.DrawString(count,Countdown,new Vector2(775,170),Color.Red);
        }
        if (targetEye != null)
        {
            sp.Draw(targetEye, new Rectangle(640, 410, item.width, item.height), Color.White * faceopacity); //item w=320,h=160
        }
        if (targetNose != null)
        {
            sp.Draw(targetNose, new Rectangle(640, 460, item.width, item.height), Color.White * faceopacity);
        }
        if (targetMouth != null)
        {
            sp.Draw(targetMouth, new Rectangle(640, 550, item.width, item.height), Color.White * faceopacity);
        }
    }

    public void GameTour(GameTime gameTime) //countdown
    {
        time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (itemM != null && time >=(display+fadetime))
        {
            itemM.ChangeStage(gameTime);
            
        }
        
        switch((int)time)
        {
            case 0: Countdown= "3"; break;
            case 1: Countdown= "2"; break;
            case 2: Countdown= "1"; break;
        }
        if (time >= display)
        {
            faceopacity -= (float)gameTime.ElapsedGameTime.TotalSeconds / fadetime;
            if (faceopacity < 0.0f)
            {
                faceopacity = 0.0f;
            }
        }
       
    }
    public void CheckFace()
    {
        
    }
   

}