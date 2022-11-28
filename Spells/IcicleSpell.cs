﻿using MartinMatta_MerlinCore.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class IcicleSpell : ProjectileSpell
    {
        public IcicleSpell(AbstractCharacter caster, int speed, int range, IEnumerable<ICommand> effects) : base(caster, speed, range, effects)
        {
            this.animation = new Animation("resources/icicle.png", 9, 6);
            this.OnAddedToWorld(caster.GetWorld());
            this.SetAnimation(this.animation);
            this.GetAnimation().Start();
        }
    }
}
