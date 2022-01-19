using System;
using Raylib_cs;
using System.Numerics;



Raylib.InitWindow(1900,1080, "The Game");


Raylib.SetTargetFPS(60);


Texture2D Kratos = Raylib.LoadTexture("Kratos.png");
Texture2D hell = Raylib.LoadTexture("Hell_stage.png");

Rectangle Kratosrect = new Rectangle(100,50, Kratos.width,Kratos.height);

string level = "hell";
float speed = 15;

while(!Raylib.WindowShouldClose())
{
    
    
    if(level == "hell"  || level == "fairy_land"  || level == "Abyss")
    {
        Vector2 movement = ReadMovement(speed);

        Kratosrect.x += movement.X;
        Kratosrect.y += movement.Y;
    }
    
    
    if (level == "hell")
    {

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.BLACK);

    Raylib.DrawTexture(hell,0,0,Color.BLACK);

    Raylib.DrawTexture(Kratos,(int)Kratosrect.x, (int)Kratosrect.y, Color.WHITE);

    Raylib.EndDrawing();

    }

}




static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if(Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;
    if(Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;

    return movement;
}

