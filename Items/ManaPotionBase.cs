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
    public class ManaPotionBase
    {
        private static ManaPotionBase instance;
        private Animation animation;
        public static ManaPotionBase GetInstance()
        {
            if (instance == null)
            {
                instance = new ManaPotionBase();
            }

            return instance;
        }

        private ManaPotionBase()
        {
            this.animation = new Animation("resources/sprites/manapotion_full.png", 16, 16);
        }

        public Animation GetAnimation()
        {
            return this.animation;
        }
    }
}
