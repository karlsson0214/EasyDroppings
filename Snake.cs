using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EasyMonoGame;
using EasyDroppings;

namespace DroppingsSolution
{
    /// <summary>
    /// An object of the class represents a snake.
    /// </summary>
    internal class Snake : Actor
    {

        private float speed;
        private int score;

        public Snake()
        {
            speed = 200f;
        }

        /// <summary>
        /// Call once per frame to update the snake's internal state.
        /// </summary>
        /// <param name="gameTime">A GameTime object that represents the time in the game.</param>
        public override void Update(GameTime gameTime)
        {
            // Move the snake based on input.
            var keyState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyState.IsKeyDown(Keys.Left))
            {
                IsFlippedHorizontally = true;
                X = Position.X  - speed * deltaTime;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                IsFlippedHorizontally = false;
                X= Position.X + speed * deltaTime;
            }
            // Wrap the snake around the screen.
            if (Position.X < 0)
            {
                X = Position.X + World.Width;
            }
            else if (Position.X > World.Width)
            {
                X = Position.X - World.Width;
            }
            if (IsTouching(typeof(Plum)))
            {
                RemoveTouching(typeof(Plum));
                score += 1;
                World.ShowText("Score: " + score, 100, 100);
            }


        }
    }
}
