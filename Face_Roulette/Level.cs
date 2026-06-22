using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

class Level
{
    public Random random = new Random();
    public float display = 3.0f; // time of face showing
    public float opacity = 1.0f;
    public float time = 0f, fadetime = 0.3f; // for disappearing
    public string Countdown= "3";
    
    public Dictionary<int, Texture2D> choseneyes = new Dictionary<int, Texture2D>(),
                                      chosennoses = new Dictionary<int, Texture2D>(),
                                      chosenmouths = new Dictionary<int, Texture2D>();
    public Texture2D currentEye, currentNose, currentMouth;
    public void CreateFace(Dictionary<int, Texture2D> eyes, Dictionary<int, Texture2D> noses, Dictionary<int, Texture2D> mouths)
    {
        choseneyes.Clear(); chosennoses.Clear(); chosenmouths.Clear();
        time = 0f;
        opacity = 1.0f;
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

        currentEye = choseneyes[random.Next(1, 5)];
        currentNose = chosennoses[random.Next(1, 5)];



    }
    public void DrawFace(SpriteBatch sp,SpriteFont count)
    {
        if (time< display)//for countdown
        {
            sp.DrawString(count,Countdown,new Vector2(775,170),Color.Red);
        }
        if (currentEye != null)
        {
            sp.Draw(currentEye, new Rectangle(640, 410, 320, 160), Color.White * opacity);
        }
        if (currentNose != null)
        {
            sp.Draw(currentNose, new Rectangle(640, 460, 320, 160), Color.White * opacity);
        }
    }

    public void GameTour(GameTime gameTime)
    {
        time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        switch((int)time)
        {
            case 0: Countdown= "3"; break;
            case 1: Countdown= "2"; break;
            case 2: Countdown= "1"; break;
        }
        if (time >= display)
        {
            opacity -= (float)gameTime.ElapsedGameTime.TotalSeconds / fadetime;
            if (opacity < 0.0f)
            {
                opacity = 0.0f;
            }
        }
        if (time >= (display + fadetime))
        {

        }
    }




}