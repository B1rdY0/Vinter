using System;
using System.Numerics;
using Raylib_cs;


public class Fireball
{
    public Vector2 direction = new Vector2(1, 0);
    public Rectangle rect;
    public Texture2D image = Raylib.LoadTexture("Fireball.png");

    public Fireball()
    {
        rect = new Rectangle(50, 50, image.width, image.height);
    }

    public void Draw()
    {
        Raylib.DrawTexture(image, (int)rect.x, (int)rect.y, Color.WHITE);
    }

    public void Update()
    {
        rect.x += direction.X;
        rect.y += direction.Y;
    }

    

}