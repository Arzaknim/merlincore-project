using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Items
{
    public class Jar : AbstractActor, IItem
    {
        public Jar()
        {
            this.animation = new Animation("resources/sprites/jar_empty.png", 16, 16);
            this.animation.Start();
        }

        public override void Update()
        {
        }
    }
}
