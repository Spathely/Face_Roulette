using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public interface IScene
{
    public void Update(GameTime gameTime);
    public void DrawScreen(SpriteBatch spriteBatch);
}
public class Scene
{
    public Dictionary<string, IScene> scenes;
    private IScene currentscene;
    public ContentManager Content;
    public Scene()
    {
        scenes = new Dictionary<string, IScene>();
    }
    public void LoadScenes(ContentManager Content) //add scenes in dic
    {
       this.Content= Content;
        Menu menu = new Menu(this, null);
        InGame game = new InGame();
        Lose lose = new Lose(this, null);

        scenes.Add("menu", menu);
        scenes.Add("game", game);
        scenes.Add("lose", lose);


        ChangeState("menu");//first scene
    }
    public void ChangeState(string name)
    {
        switch (name)
        {
            case "menu":
                currentscene = scenes["menu"];
                ((Menu)currentscene).LoadMenu(this.Content);
                break;
            case "game":
                currentscene = scenes["game"];
                ((InGame)currentscene).LoadUIs(this.Content);
                break;
            case "lose":
                currentscene = scenes["lose"];
                ((Lose)currentscene).LoadMenu(this.Content);
                break;

        }
    }
    public void Update(GameTime gameTime)
    {
        if (currentscene != null)
        {
            currentscene.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        if (currentscene != null)
        {
            currentscene.DrawScreen(spriteBatch);
        }
    }
}