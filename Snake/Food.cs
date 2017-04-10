using System;
using System.Drawing;

namespace Snake
{
    public class Food
    {
        public Rectangle food;
        private int x, y, width = 10, height = 10;

        public Food(Random rand)
        {
            Generate(rand);
            food = new Rectangle(x, y, width, height);
        }

        public void Draw(Graphics graphics)
        {
            food.X = x;
            food.Y = y;
            graphics.FillRectangle(Brushes.Red, food);
        }

        public void Generate(Random rand)
        {
            x = rand.Next(0, 100) * 10;
            y = rand.Next(0, 70) * 10;
        }
    }
}
