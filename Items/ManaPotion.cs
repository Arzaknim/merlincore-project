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

    public class ManaPotion : Jar, IUsable
    {
        private int dosage;
        private ManaPotionBase instance;

        public ManaPotion(int dosage)
        {
            this.instance = ManaPotionBase.GetInstance();
            this.dosage = dosage;
            this.animation = this.instance.GetAnimation();
            this.animation.Start();
        }

        public override void Update()
        {
        }

        public void Use(IActor actor)
        {
            (actor as AbstractWizardCharacter).ChangeMana(this.dosage);
        }
    }
}
