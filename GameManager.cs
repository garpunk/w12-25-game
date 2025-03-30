using Raylib_cs;
using System;
using System.Collections.Generic;



class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;
    private Player _player;
    private List<GameObject> _gameObjects;
    private int _score;
    private int _lives;
    private Random _random;
    private bool _gameOver;

    public GameManager()
    {
        _title = "CSE 210 Game";
        _player = new Player(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 40);
        _gameObjects = new List<GameObject>();
        _score = 0;
        _lives = 3;
        _random = new Random();
        _gameOver = false;
    }

    public void Run()
    {
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            if (_gameOver)
            {
                ShowGameOverScreen();
            }
            else
            {
                HandleInput();
                ProcessActions();
                DrawElements();
            }
        }

        Raylib.CloseWindow();
    }

    private void HandleInput()
    {
        _player.HandleInput();
    }

    private void ProcessActions()
    {
        if (_random.Next(100) < 2)
            _gameObjects.Add(new Bomb(_random.Next(0, SCREEN_WIDTH - 20), 0));
        if (_random.Next(100) < 2)
            _gameObjects.Add(new Reward(_random.Next(0, SCREEN_WIDTH - 20), 0));

  for (int i = _gameObjects.Count - 1; i >= 0; i--)
{
    _gameObjects[i].Update();

    
    if (GameObject.CheckCollision(_player, _gameObjects[i]))  
    {
        if (_gameObjects[i] is Bomb)
            _lives--;
        else if (_gameObjects[i] is Reward)
            _score++;

        _gameObjects.RemoveAt(i); 
    }
    else if (_gameObjects[i].GetTopEdge() > SCREEN_HEIGHT)  
    {
        _gameObjects.RemoveAt(i);  
    }
}

        if (_lives <= 0) 
            _gameOver = true; 
    }

    private void DrawElements()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        _player.Draw();
        foreach (var obj in _gameObjects)
            obj.Draw();
        Raylib.DrawText($"Score: {_score}", 10, 10, 20, Color.Black);
        Raylib.DrawText($"Lives: {_lives}", 10, 40, 20, Color.Black);
        Raylib.EndDrawing();
    }

    private void ShowGameOverScreen()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawText("GAME OVER", SCREEN_WIDTH / 2 - 100, SCREEN_HEIGHT / 2 - 40, 40, Color.Red);
        Raylib.DrawText($"Final Score: {_score}", SCREEN_WIDTH / 2 - 100, SCREEN_HEIGHT / 2, 30, Color.White);
        Raylib.DrawText("Press ESC to exit", SCREEN_WIDTH / 2 - 100, SCREEN_HEIGHT / 2 + 40, 20, Color.Gray);
        Raylib.EndDrawing();
    }
}
