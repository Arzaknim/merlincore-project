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
    public class HealingPotionBase
    {
        private static HealingPotionBase instance;
        private Animation animation;
        public static HealingPotionBase GetInstance()
        {
            if (instance == null)
            {
                instance = new HealingPotionBase();
            }

            return instance;
        }

        private HealingPotionBase()
        {
            this.animation = new Animation("resources/sprites/healingpotion_full.png", 16, 16);
        }

        public Animation GetAnimation()
        {
            return this.animation;
        }
    }
}
