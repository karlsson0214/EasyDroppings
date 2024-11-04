using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DroppingsSolution;
using EasyMonoGame;

namespace EasyDroppings
{
    internal class DroppingsWorld : World
    {
        public DroppingsWorld() : base(600, 800)
        {
            GameArt.Add("bluerock");
            GameArt.Add("cherries");
            GameArt.Add("herz");
            GameArt.Add("plum");
            GameArt.Add("pumpkin");
            GameArt.Add("skull");
            GameArt.Add("snake");


            BackgroundTileName = "bluerock";

            Snake snake = new Snake();
            Add(snake);


        }
    }
}
