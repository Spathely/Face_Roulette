using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

class Level
{
    public Random random = new Random();
    public Texture2D currentEye, currentNose, currentMouth;
    Items items;
    public void LevelManage()
    {

    }
    public void CreateFace(Dictionary<int, Texture2D> eyes, Dictionary<int, Texture2D> noses, Dictionary<int, Texture2D> mouths)
    {

        currentEye = eyes[random.Next(1, 13)];
        currentNose = noses[random.Next(1, 9)];


    }
    public void DrawFace(SpriteBatch sp)
    {
        if (currentEye != null)
        {
            sp.Draw(currentEye, new Rectangle(640, 410, 320, 160), Color.White);
        }
        if (currentNose != null)
        {
            sp.Draw(currentNose, new Rectangle(640, 460, 320, 160), Color.White);
        }


    }





}