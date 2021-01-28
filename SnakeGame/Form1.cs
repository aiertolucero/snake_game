using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private SnakeNodes Snake = new SnakeNodes();
        private SnakeNode lastNode = new SnakeNode();
        private SnakeNode headNode = new SnakeNode();
        private SnakeNode food = new SnakeNode();

     
        public Form1()
        {
            InitializeComponent();

            StartGame();
        }

        private void StartGame()
        {
            new Settings();

            gameoverlbl.Visible = false;
            LaunchTimer();

            //Initialize SnakeSnake
            Snake.headNode = null;
            headNode = new SnakeNode(35, 10);
            Snake.headNode = headNode;
            Snake.AddToEnd(35, 9);
            Snake.AddToEnd(35, 8);

            score.Text = Settings.Score.ToString();
            GenerateFood();

        }

        //Place random food object
        private void GenerateFood()
        {
            int maxXPos = pictureBoxArena.Size.Width / Settings.Width;
            int maxYPos = pictureBoxArena.Size.Height / Settings.Height;

            Random random = new Random();
            food = new SnakeNode(random.Next(0, maxXPos),random.Next(0, maxYPos));
        }
        
        private void LaunchTimer()
        {
            timer.Stop();
            timer = new Timer();
            timer.Interval = 1000 / Settings.Speed;
            timer.Tick += UpdateScreen;
            timer.Start();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check for Game Over
            if (Settings.GameOver)
            {
                //Check if Enter is pressed
                if (UserInput.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (UserInput.KeyPressed(Keys.Right) && Settings.direction != SnakeDirection.Left)
                    Settings.direction = SnakeDirection.Right;
                else if (UserInput.KeyPressed(Keys.Left) && Settings.direction != SnakeDirection.Right)
                    Settings.direction = SnakeDirection.Left;
                else if (UserInput.KeyPressed(Keys.Up) && Settings.direction != SnakeDirection.Down)
                    Settings.direction = SnakeDirection.Up;
                else if (UserInput.KeyPressed(Keys.Down) && Settings.direction != SnakeDirection.Up)
                    Settings.direction = SnakeDirection.Down;

                MovePlayer();
            }

            pictureBoxArena.Invalidate();

        }

        private void MovePlayer()
        {
            SnakeNodes NewSnake = new SnakeNodes();
            SnakeNode prevNode = new SnakeNode();

            for (; Snake.headNode != null; Snake.headNode = Snake.headNode.next)
            {
                if (Snake.headNode.x == headNode.x && Snake.headNode.y == headNode.y)
                {
                    prevNode.x = Snake.headNode.x;
                    prevNode.y = Snake.headNode.y;

                    switch (Settings.direction)
                    {
                        case SnakeDirection.Right:
                            Snake.headNode.x++;
                            break;
                        case SnakeDirection.Left:
                            Snake.headNode.x--;
                            break;
                        case SnakeDirection.Up:
                            Snake.headNode.y--;
                            break;
                        case SnakeDirection.Down:
                            Snake.headNode.y++;
                            break;
                    }

                    NewSnake.AddToEnd(Snake.headNode.x, Snake.headNode.y);
                    headNode = Snake.headNode;

                    //Get maximum X and Y Pos
                    int maxXPos = pictureBoxArena.Size.Width / Settings.Width;
                    int maxYPos = pictureBoxArena.Size.Height / Settings.Height;

                    //Detect collission with game borders.
                    if (Snake.headNode.x < 0 || Snake.headNode.y < 0
                        || Snake.headNode.x >= maxXPos || Snake.headNode.y >= maxYPos)
                    {
                        Die();
                    }


                    //Detect collission with body
                    var bodyNode = Snake.headNode.next;
                    while (bodyNode != null)
                    {
                        if (bodyNode.x == Snake.headNode.x && bodyNode.y == Snake.headNode.y)
                            Die();
                        bodyNode = bodyNode.next;
                    }

                    //Detect collision with food piece
                    if (Snake.headNode.x == food.x && Snake.headNode.y == food.y)
                    {
                        Eat();
                    }
                }
                else
                {
                    NewSnake.AddToEnd(prevNode.x, prevNode.y);
                    prevNode.x = Snake.headNode.x;
                    prevNode.y = Snake.headNode.y;
                }

                
            }
            Snake = NewSnake;

        }

        private void Eat()
        {
            //Add Node to Snake
            var currentNode = headNode;
            while (currentNode.next != null)
                currentNode = currentNode.next;
            Snake.AddToEnd(currentNode.x, currentNode.y);


            //Update Score
            Settings.Score += Settings.Points;
            score.Text = Settings.Score.ToString();

            if (Settings.Score % 10 == 0)
            {
                Settings.Speed += 10;
                timer.Interval = 1000 / Settings.Speed;
            }

            GenerateFood();
        }

        private void Die()
        {
            Settings.GameOver = true;
        }

        private void pictureBoxArena_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                //Draw snake
                for (SnakeNode currentNode = Snake.headNode; currentNode != null; currentNode = currentNode.next)
                {
                    Brush snakeColour = currentNode == Snake.headNode ? Brushes.Beige : Brushes.Green;

                    //Draw snake
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(currentNode.x * Settings.Width,
                                      currentNode.y * Settings.Height,
                                      Settings.Width, Settings.Height));
              
                }

                //Draw Food
                canvas.FillEllipse(Brushes.Red,
                    new Rectangle(food.x * Settings.Width,
                         food.y * Settings.Height, Settings.Width, Settings.Height));
            }
            else
            {
                string gameOver = "GAME OVER!!\nPress Enter to try again";
                gameoverlbl.Text = gameOver;
                gameoverlbl.Visible = true;
            }
        }

        private void ResetSettings()
        {
            Settings.Score = 0;
            Settings.Speed = 15;
            Settings.GameOver = false;
            Settings.direction = SnakeDirection.Down;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            UserInput.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            UserInput.ChangeState(e.KeyCode, false);
        }
       
    }
}
