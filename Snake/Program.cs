using System;
using System.Collections.Generic;
using System.Threading;
using SnakeLib;

namespace SnakeCode
{
    class Program
    {
        static List<Circle>Snake = new List<Circle>();
        static Circle Food = new Circle();
        static Canvas canvas = new Canvas();
        static void Main(string[] args)
        {
            new Settings();
            OnStart();

            while (Settings.GameOver is false)
            {
                StartGame();
                Thread.Sleep(150);
            }
        }

        static void OnStart()
        {
            //to look better
            Console.CursorVisible = false;

            MakeSnake();
            GenerateFood();
            return;
        }

        static void StartGame()
        {
            WriteScreen();
            UpdateScreen();
            SnakeFunctions.ManageInput();
            return;
        }

        static void MakeSnake()
        {
            //adding head
            Snake.Clear();
            Circle head = new Circle();
            head.X = 0;
            head.Y = 0;
            Snake.Add(head);
            
            //add tail
            Circle tail = new Circle();
            tail.X = 1;
            tail.Y = 0;
            Snake.Add(tail);

        }
        static void GenerateFood()
        {
            Random r = new Random();
            Food.X = r.Next(0, Settings.ScreenWidth);
            Food.Y = r.Next(0, Settings.ScreenHeight);
            return;
        }

        static void WriteScreen()
        {
            Console.Clear();

            Canvas.Reset();
            //SnakeFunctions.WriteUI();

            //to represent snake as charaters
            for(int i = 0; i < Snake.Count; i++)
            {
                if(i == 0)
                {
                    Canvas.Add("@", Snake[i].X + 1, Snake[i].Y + 1);
                }
                else
                {
                    Canvas.Add("0", Snake[i].X + 1, Snake[i].Y + 1);
                }
                
            }
            //to represent food as a charater
            Canvas.Add("#", Food.X + 1, Food.Y + 1);
            
            Canvas.Write();
            return;
        }

        
        static void UpdateScreen()
        {
            MoveSnake();
            Eat();
            Die();
            
            return;
        }

        static void MoveSnake()
        {
            for(int i = Snake.Count - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    //to move head
                    switch(Settings.direction)
                    {
                        case Settings.Direction.Up:
                            Snake[i].Y--;
                        break;
                        case Settings.Direction.Down:
                            Snake[i].Y++;
                        break;
                        case Settings.Direction.Left:
                           Snake[i].X--;
                        break;
                        case Settings.Direction.Right:
                            Snake[i].X++;
                        break;
                    }
                }
                else
                {
                    //to move tail
                    Snake[i].X = Snake[i-1].X;
                    Snake[i].Y = Snake[i-1].Y;
                }
            }
            return;
        }

        static void Eat()
        {
            Settings.isFoodEaten = Snake[0].X == Food.X && Snake[0].Y == Food.Y;

            if(Settings.isFoodEaten == true)
            {
                //add more tail
                Circle tail = new Circle();
                tail.X = Snake[Snake.Count - 1].X;
                tail.Y = Snake[Snake.Count - 1].Y;
                Snake.Add(tail);
                
                //add points
                Settings.Score += Settings.Points;
                
                GenerateFood();
            }
            return;
        }

        static void Die()
        {
            //to die when the player crosses the tail
            for(int i = 1; i < Snake.Count; i++)
            {
                Settings.GameOver = Snake[0].X == Snake[i].X && Snake[0].Y == Snake[i].Y ||

                //to die when the player crosses the end of the canvas
                Snake[0].Y == -1 || Snake[0].X == -1 || Snake[0].Y == 16 || Snake[0].X == 16;

                //reset the game
                if(Settings.GameOver == true)
                { 
                    Console.WriteLine("GameOver");
                    string input = Console.ReadLine();
                    if(input == "exit")
                    {
                        Environment.Exit(0);
                    }
                    Main(null); //to reset the game  
                }
            }
            return;
        }
    }
}