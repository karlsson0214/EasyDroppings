using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DroppingsSolution;
using EasyMonoGame;
using Microsoft.Xna.Framework;

namespace EasyDroppings
{
    internal class DroppingsWorld : World
    {
        private Random random = new Random();
        public DroppingsWorld() : base(600, 800)
        {
            // Tile background with file "bluerock" in the Content folder.
            BackgroundTileName = "bluerock";

            // Create a snake object.
            Snake snake = new Snake();
            // Add the snake to the world at position (300, 700).
            // Set the snake image to the file "snake" in the Content folder.
            Add(snake, "snake", 300, 700);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (random.NextDouble() < gameTime.ElapsedGameTime.TotalSeconds)
            {
                Add(new Plum(), "plum", random.Next(0, Width), 0);
            }

        }
    }
}
