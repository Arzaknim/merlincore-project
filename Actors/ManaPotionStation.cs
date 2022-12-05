using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Factories;
using MartinMatta_MerlinCore.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class ManaPotionStation : AbstractPotionStation
    {

        public ManaPotionStation()
        {
            this.type = PotionType.MANA;
            this.animation = new Animation("resources/manapotionstation.png", 64, 64);
            this.animation.Start();
        }
    }
}
