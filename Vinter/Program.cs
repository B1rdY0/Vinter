using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1900, 1080, "The Game");

Raylib.SetTargetFPS(60);


Texture2D Kratos = Raylib.LoadTexture("Kratos(EXsmall).png");
Texture2D Demonking = Raylib.LoadTexture("DemonKing(SmallFlip).png");
Texture2D hell = Raylib.LoadTexture("hell(1).png");
Texture2D KratosATT = Raylib.LoadTexture("Kraosswing");
Texture2D Fireball = Raylib.LoadTexture("Fireball");

// Fireball f1 = new Fireball();

List<Fireball> fireballs = new List<Fireball>();

Fireball f1 = new Fireball();
f1.rect.x = 50;
f1.rect.y = 50;
Fireball f2 = new Fireball();
f1.rect.x = 50;
f1.rect.y = 150;

fireballs.Add(f1);
fireballs.Add(f2);



Rectangle Kratosrect = new Rectangle(100, 385, Kratos.width, Kratos.height);
Rectangle DemonKingRect = new Rectangle(1600, 250, Demonking.width, Demonking.height);
Rectangle KratosSwing = new Rectangle(100, 385, Kratos.width, Kratos.height);
Rectangle Fireballrect = new Rectangle(20, 20, Fireball.width, Fireball.height);

string level = "hell";
float speed = 10;
float velocity = 0;
float Gravity = 5;
bool isGrounded = false;

Vector2 Fireballdirection = new Vector2(1, 0);

while (!Raylib.WindowShouldClose())
{


    if (level == "hell" || level == "fairy_land" || level == "Abyss")
    {
        Vector2 movement = ReadMovement(speed);

        Kratosrect.x += movement.X;
        Kratosrect.y += movement.Y;

        velocity += Gravity;
        if (movement.Length() > 0)
        {
            // Den här gör vectorn till 1 alltså normalizar
            Fireballdirection = Vector2.Normalize(movement);
        }



        if (Kratosrect.y >= 470 - Kratosrect.height)
        {
            velocity = 0;
            isGrounded = true;
            Kratosrect.y = 470 - Kratosrect.height;
        }
        else
        {
            isGrounded = false;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && isGrounded)
        {
            velocity = -35;
        }

        Kratosrect.y += velocity;
    }

    if (Kratosrect.x >= 1920 || Kratosrect.x < 0)
    {
        Kratosrect.x = 0;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTexture(KratosATT, 0, 0, Color.WHITE);

        Raylib.EndDrawing();
    }


    // if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
    // {

    // }

    if (level == "hell")
    {

        for (var i = 0; i < fireballs.Count; i++)
        {
            fireballs[i].Update();
        }


        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTexture(hell, 0, 0, Color.WHITE);

        Raylib.DrawTexture(Kratos, (int)Kratosrect.x, (int)Kratosrect.y, Color.WHITE);

        Raylib.DrawTexture(Demonking, (int)DemonKingRect.x, (int)DemonKingRect.y, Color.WHITE);

        for (int i = 0; i < fireballs.Count; i++)
        {
            fireballs[i].Draw();
        }

        Raylib.EndDrawing();

    }

}


static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;

    return movement;
}

