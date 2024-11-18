using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;

namespace EasyDroppings
{
    internal class Plum : Actor
    {
        private float speed = 0f;
        private float acceleration = 100f;
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            speed += acceleration * deltaTime;
            Y += speed * deltaTime;

            if (Y > World.Height)
            {
                World.RemoveActor(this);
            }
        }
    }
}