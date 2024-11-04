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
            Position = new Vector2(300, 700);
            ImageName = "snake";
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
                // If the snake face a new direction, flip it.
                if (lastDirection == RIGHT)
                {
                    IsFlippedHorizontally = true;
                    lastDirection = LEFT;
                }
                SetX(Position.X  - speed * speedBoostFactor * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                // If the snake face a new direction, flip it.
                if (lastDirection == LEFT)
                {
                    IsFlippedHorizontally = false;
                    lastDirection = RIGHT;
                }
                SetX(Position.X + speed * speedBoostFactor * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            // Wrap the snake around the screen.
            if (Position.X < 0)
            {
                SetX(Position.X + World.Width);
            }
            else if (Position.X > World.Width)
            {
                SetX(Position.X - World.Width);
            }
            speedBoostTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (speedBoostTime < 0)
            {
                speedBoostFactor = 1f;
            }

        }

        /*
        public bool CollidesWith(Plum plum)
        {
            return Vector2.Distance(position, plum.Position) < Radius + plum.Radius;
        }
        public bool CollidesWith(Pumpkin pumpkin)
        {
            return Vector2.Distance(position, pumpkin.Position) < Radius + pumpkin.Radius;
        }
        public bool CollidesWith(Cherry cherry)
        {
            return Vector2.Distance(position, cherry.Position) < Radius + cherry.Radius;
        }
        */
        public void StartSpeedBoost()
        {
            speedBoostFactor = 2f;
            speedBoostTime = 5f;

        }
    }
}
