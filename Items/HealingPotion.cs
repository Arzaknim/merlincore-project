using MartinMatta_MerlinCore.Actors;
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
    public class HealingPotion : Jar, IUsable
    {
        private int dosage;
        private HealingPotionBase instance;

        public HealingPotion(int dosage)
        {
            this.instance = HealingPotionBase.GetInstance();
            this.dosage = dosage;
            this.animation = this.instance.GetAnimation();
            this.animation.Start();
        }

        public override void Update()
        {
        }

        public void Use(IActor actor)
        {
            (actor as AbstractCharacter).ChangeHealth(this.dosage);
        }
    }
}
