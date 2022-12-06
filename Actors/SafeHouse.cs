using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class SafeHouse : AbstractActor
    {
        public SafeHouse()
        {
            this.animation = new Animation("resources/safehouse.png", 160, 140);
            this.animation.Start();
        }

        public override void Update()
        {
        }
    }
}
