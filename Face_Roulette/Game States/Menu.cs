using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Menu : IScene
{
    public Texture2D button;
    public Rectangle buttonSize;
    public Color buttoncolor;
    public SpriteFont title, buttonF;
    public bool ispressed= false;

    Scene Scene;
    MouseState lastmouseState;
    

    public Menu(Scene scene, Texture2D button)
    {
        Scene = scene;
        this.button = button;
        buttonSize = new Rectangle(675, 480, 250, 100); //for pressing (button position)
    }
    public void LoadMenu(ContentManager Content)
    {
        button = Content.Load<Texture2D>("button");
        title = Content.Load<SpriteFont>("title");
        buttonF = Content.Load<SpriteFont>("scoreF");
    }
    public void Update(GameTime gameTime)
    {
        MouseState currentMouse = Mouse.GetState();
        Point mousePos = currentMouse.Position; // think mouse is point
        buttoncolor = Color.LightSkyBlue;

        if (buttonSize.Contains(mousePos)) // check mouse pos 
        {
            if (currentMouse.LeftButton == ButtonState.Pressed&& lastmouseState.LeftButton == ButtonState.Released)
            {
                ispressed= true;
            }
            if(ispressed && currentMouse.LeftButton==ButtonState.Pressed)
            {
                buttoncolor = Color.Gray; //when pressed - darker color
            }
            else if(!ispressed)
            {
                buttoncolor= Color.GhostWhite; // not pressed but on the button- lighter color
            }

            if (currentMouse.LeftButton == ButtonState.Released && ispressed)
            {
                ispressed=false;
                Scene.ChangeState("game");
            }

        }
        lastmouseState = currentMouse;
    }

    public void DrawScreen(SpriteBatch spriteBatch)
    {
        
        spriteBatch.DrawString(title, "FACE ROULETTE", new Vector2(400, 200), Color.BlueViolet);
        spriteBatch.Draw(button, buttonSize, buttoncolor);
        spriteBatch.DrawString(buttonF, "PLAY", new Vector2(720, 500), Color.White);
    }
}