using Raylib_cs;
using System;
using System.Collections.Generic;

class Player : GameObject
{
    public Player(int x, int y) : base(x, y, Color.Red) 
    { 
        _width =  60;
    }

    public void HandleInput()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left) && _x > 0)
            _x -= 10;
        if (Raylib.IsKeyDown(KeyboardKey.Right) && _x < GameManager.SCREEN_WIDTH - _width)
            _x += 10;
    }
}