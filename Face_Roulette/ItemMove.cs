using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
public class Moving
{
    public Vector2 pos; //for each item pos
    public int targetway; //further,target,end
    public bool isonScreen;
    public bool isselected;
    public float currentscale;

}
public class ItemMovement
{
    Face face;
    Items item;

    public Vector2[] eyeways, noseways, mouthways; //start,futher,target,end pos

    public Moving[] Currenteyes = new Moving[4],
                    Currentnoses = new Moving[4],
                    Currentmouths = new Moving[4];
    public float spawn = 0f,
                 speed = 200f;

    public int stage = 0; //eye-nose-mouth-fin
    public ItemMovement(Face currentFace, Items currentItem)
    {
        face = currentFace;
        item = currentItem;
        Reset();

    }
    public void Reset() // item pos here
    {
        spawn = 0f;
        stage = 0;

        eyeways = new Vector2[]
        {
            new Vector2(400,410), /*[0] start pos*/  new Vector2(200,410), //[1] further pos
            new Vector2(640,410), /*[2] target pos*/ new Vector2(1000,410)  //[3] end pos
        };
        noseways = new Vector2[]
        {
            new Vector2(400,460), new Vector2(200,460), new Vector2(640,460), new Vector2(1000,460)
        };

        mouthways = new Vector2[]
        {
            new Vector2(400,550), new Vector2(200,550), new Vector2(640,550), new Vector2(1000,550)
        };

        for (int i = 0; i < 4; i++)
        {
            Currenteyes[i] = new Moving()
            {
                pos = eyeways[0], //start pos 
                targetway = 1,// go to the further pos
                isonScreen = false,
                currentscale = 0.3f

            };
            Currentnoses[i] = new Moving()
            {
                pos = noseways[0],
                targetway = 1,
                isonScreen = false,
                currentscale = 0.3f

            };
            Currentmouths[i] = new Moving()
            {
                pos = mouthways[0],
                targetway = 1,
                isonScreen = false,
                currentscale = 0.3f

            };
        }
        Currenteyes[0].isonScreen = true;


    }
    public void ChangeStage(GameTime gameTime)
    {
        float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        switch (stage)
        {
            case 0: ItemMove(Currenteyes, eyeways, time); break;
            case 1: ItemMove(Currentnoses, noseways, time); break;
            case 2: ItemMove(Currentmouths, mouthways, time); break;
                //case3 levelcheck()
        }
    }
    public void ItemMove(Moving[] movingitems, Vector2[] ways, float time)// itemlerin dönmesi
    {
        bool anyselected = false;
        for (int i = 0; i < 4; i++)
        {
            if (movingitems[i].isselected)
            { anyselected = true; }
        }
        if (!anyselected)
        {
            spawn += time;

            if (spawn >= 1.6f) // spawn
            {
                for (int i = 0; i < 4; i++)
                {
                    if (!movingitems[i].isonScreen)
                    {
                        movingitems[i].isonScreen = true;
                        movingitems[i].pos = ways[0]; //start pos
                        movingitems[i].targetway = 1; //target - further pos
                        movingitems[i].currentscale = 0.3f;
                        movingitems[i].isselected= false;
                        break;
                    }
                }
                spawn = 0f; //reset time
            }

        }

        for (int i = 0; i < 4; i++) //item movement
        {
            if (movingitems[i].isonScreen) // i for chosen item
            {

                Vector2 waypoint = ways[movingitems[i].targetway]; // tw=1 ways[1] = goin to further

                if (Math.Abs(movingitems[i].pos.X - waypoint.X) <= 4f) //mutlak değer 
                {
                    movingitems[i].pos = waypoint;

                    if(movingitems[i].isselected && movingitems[i].targetway==2)//when choose the item change stage
                    {
                        movingitems[i].currentscale=1.0f;
                        stage++;
                        spawn=0f;
                        if(stage==1)
                        {Currentnoses[0].isonScreen=true;}
                        else if(stage==2)
                        {Currentmouths[0].isonScreen=true;}
                        break;
                    }

                    switch (movingitems[i].targetway)
                    {
                        case 1: movingitems[i].currentscale = 0.5f; break;
                        case 2: movingitems[i].currentscale = 1.2f; break;
                        case 3: movingitems[i].currentscale = 0.8f; break;
                    }

                    if (movingitems[i].targetway < ways.Length - 1)
                    {
                        movingitems[i].targetway++;
                    }
                    else //go back to start 
                    {
                        movingitems[i].pos = ways[0];
                        movingitems[i].targetway = 1;
                        movingitems[i].currentscale = 0.3f;
                        movingitems[i].isonScreen = false;
                    }
                }
                else
                {
                    if (movingitems[i].pos.X < waypoint.X) //move right
                    {
                        movingitems[i].pos.X += speed * time;
                    }
                    else if (movingitems[i].pos.X > waypoint.X) // move left
                    {
                        movingitems[i].pos.X -= speed * time;
                    }

                    switch(movingitems[i].targetway)
                    {
                        case 1:if (movingitems[i].currentscale < 0.5f)
                            movingitems[i].currentscale += (0.2f / (200f / speed)) * time; break; // scale difference / (x.pos difference/speed)*time
                        
                        
                        case 2:if(movingitems[i].isselected)
                            {
                                if (movingitems[i].currentscale < 1.0f)
                            movingitems[i].currentscale += (0.5f / (440f / speed)) * time; break;
                            }
                            else
                            {
                                if (movingitems[i].currentscale < 1.2f)
                            movingitems[i].currentscale += (0.7f / (400f / speed)) * time; break;
                            }
                       
                        
                        case 3:if (movingitems[i].currentscale < 0.8f)
                            movingitems[i].currentscale += (0.4f / (400f / speed)) * time; break;
                    }
                   
                }
            }
        }
    }

    public void DrawItems(SpriteBatch sp)
    {
        List<Texture2D> eyeT = new List<Texture2D>();
        foreach (var eye in face.choseneyes)
        {
            if (eye.Value != null)
            { eyeT.Add(eye.Value); }
        }
        for (int Ei = eyeT.Count - 1; Ei >= 0; Ei--)
        {
            if (Ei < 4 && Currenteyes[Ei].isonScreen)
            {
                Rectangle rec = item.ScaleItem(Currenteyes[Ei].pos, Currenteyes[Ei].currentscale);
                sp.Draw(eyeT[Ei], rec, Color.White);
            }
        }
        List<Texture2D> noseT = new List<Texture2D>();
        foreach (var nose in face.chosennoses)
        {
            if (nose.Value != null)
            { noseT.Add(nose.Value); }
        }
        for (int Ni = noseT.Count - 1; Ni >= 0; Ni--)
        {
            if (Ni < 4 && Currentnoses[Ni].isonScreen)
            {
                Rectangle rec = item.ScaleItem(Currentnoses[Ni].pos, Currentnoses[Ni].currentscale);
                sp.Draw(noseT[Ni], rec, Color.White);
            }
        }
        List<Texture2D> mouthT = new List<Texture2D>();
        foreach (var mouth in face.chosenmouths)
        {
            if (mouth.Value != null)
            { mouthT.Add(mouth.Value); }
        }
        for (int Mi = mouthT.Count - 1; Mi >= 0; Mi--)
        {
            if (Mi < 4 && Currentmouths[Mi].isonScreen)
            {
                Rectangle rec = item.ScaleItem(Currentmouths[Mi].pos, Currentmouths[Mi].currentscale);
                sp.Draw(mouthT[Mi], rec, Color.White);
            }
        }
    }

}