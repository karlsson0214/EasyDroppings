using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EasyMonoGame;

namespace DroppingsSolution
{
    /// <summary>
    /// An object of the class represents a snake.
    /// </summary>
    internal class Snake : Actor
    {

        private float speed;
        private float speedBoostFactor = 1f;
        private const int RIGHT = 1;
        private const int LEFT = 2;
        private int lastDirection = RIGHT;
        private float speedBoostTime = 0f;


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
            if (keyState.IsKeyDown(Keys.Left))
            {
                IsFlippedHorizontally = true;
                X = Position.X  - speed * speedBoostFactor * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                IsFlippedHorizontally = false;
                X= Position.X + speed * speedBoostFactor * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
            speedBoostTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (speedBoostTime < 0)
            {
                speedBoostFactor = 1f;
            }

        }


        public void StartSpeedBoost()
        {
            speedBoostFactor = 2f;
            speedBoostTime = 5f;

        }
    }
}
