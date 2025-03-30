using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;


abstract class GameObject
{
    protected int _x, _y, _width = 20, _height = 20;
    protected Color _color;

    public int Y => _y;
    public int GetY() => _y;
    public GameObject(int x, int y, Color color)
    {
        _x = x;
        _y = y;
        _color = color;
    }

      public int GetLeftEdge() => _x;
      public int GetRightEdge() => _x + _width;
      public int GetTopEdge() => _y;
      public int GetBottomEdge() => _y + _height;

    public virtual void Update()
    {
        _y += 5; // Moves the object downward
    }

    public void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, _color);
    }

   public static bool CheckCollision(GameObject first, GameObject second)
{
    bool isHit = false;

    if (first.GetLeftEdge() < second.GetRightEdge() &&   
        first.GetRightEdge() > second.GetLeftEdge() &&   
        first.GetBottomEdge() > second.GetTopEdge() &&   
        first.GetTopEdge() < second.GetBottomEdge())     
    {
        isHit = true;
    }

    return isHit;
}
}