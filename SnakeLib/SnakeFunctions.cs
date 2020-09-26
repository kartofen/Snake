using System;

namespace SnakeLib
{
    public class SnakeFunctions
    {
        public static void WriteUI()
        {
            Console.WriteLine(@"
   _____             _        
  / ____|           | |       
 | (___  _ __   __ _| | _____ 
  \___ \| '_ \ / _` | |/ / _ \
  ____) | | | | (_| |   <  __/
 |_____/|_| |_|\__,_|_|\_\___|           
            
            ");
            Console.WriteLine("Score: " + Settings.Score + "\n");
            Console.WriteLine("");
        }

        public static void ManageInput()
        {
            ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();

            if(Console.KeyAvailable == true)
            {
                PressedKey = Console.ReadKey();
            }

            switch(PressedKey.Key)
            {
                case ConsoleKey.W:
                    if(Settings.direction != Settings.Direction.Down)
                    {
                        Settings.direction = Settings.Direction.Up;
                    }
                break;
                case ConsoleKey.A:
                    if(Settings.direction != Settings.Direction.Right)
                    {
                        Settings.direction = Settings.Direction.Left;
                    }
                break;
                case ConsoleKey.S:
                    if(Settings.direction != Settings.Direction.Up)
                    {
                        Settings.direction = Settings.Direction.Down;
                    }
                break;
                case ConsoleKey.D:
                    if(Settings.direction != Settings.Direction.Left)
                    {
                        Settings.direction = Settings.Direction.Right;
                    }
                break;
            }
            return;
        }
    }
}