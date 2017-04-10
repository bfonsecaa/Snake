using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private int direction = 0;
        private int score = 1;
        private Timer timer = new Timer();
        private Random rand = new Random();
        private Graphics graphics;
        private Snake snake;
        private Food food;


        public Form1()
        {
            InitializeComponent();
            snake = new Snake();
            food = new Food(rand);
            timer.Interval = 45;
            timer.Tick += Update;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    if (mainMenu.Visible)
                    {
                        mainMenu.Visible = false;
                        timer.Start();
                    }
                    break;
                case Keys.Space:
                    if (!mainMenu.Visible)
                    {
                        if (timer.Enabled)
                            timer.Enabled = false;
                        else
                            timer.Enabled = true;
                    }
                    break;
                case Keys.Right:
                    if (direction != 2)
                        direction = 0;
                    break;
                case Keys.Down:
                    if (direction != 3)
                        direction = 1;
                    break;
                case Keys.Left:
                    if (direction != 0)
                        direction = 2;
                    break;
                case Keys.Up:
                    if (direction != 1)
                        direction = 3;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            snake.Draw(graphics);
            food.Draw(graphics);
        }

        private void Update(object sender, EventArgs e)
        {
            snake.Move(direction);
            for (int i = 1; i < snake.body.Length; i++)
                if (snake.body[0].IntersectsWith(snake.body[i]))
                    Restart();

            if (snake.body[0].X < 0 || snake.body[0].X > 990)
                Restart();

            if (snake.body[0].Y < 0 || snake.body[0].Y > 690)
                Restart();

            if (snake.body[0].IntersectsWith(food.food))
            {
                score++;
                snake.Grow();
                food.Generate(rand);
            }

            this.Invalidate();
        }

        private void Restart()
        {
            timer.Stop();
            graphics.Clear(SystemColors.Control);
            snake = new Snake();
            food = new Food(rand);
            direction = 0;
            score = 1;
            mainMenu.Visible = true;
        }
    }
}
