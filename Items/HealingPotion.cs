﻿using MartinMatta_MerlinCore.Actors;
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
        private Animation fullAnimation;

        public HealingPotion(int dosage)
        {
            this.dosage = dosage;
            this.fullAnimation = new Animation("resources/sprites/healingpotion_full.png", 16, 16);
            this.animation = this.fullAnimation;
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
