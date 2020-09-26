using System;

namespace SnakeLib
{
    public class Settings
    {
        public enum Direction
        { Up, Down, Left, Right }

        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static bool isFoodEaten { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            ScreenWidth = 16;
            ScreenHeight = 16;
            Score = 0;
            Points = 100;
            GameOver = false;
            isFoodEaten = false;
            direction = Direction.Down;
        }
    }
}
