using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Effects
{
    public class OnHitDamageEffect : SpellEffect
    {
        private int deltaHP;

        public OnHitDamageEffect(int deltaHP)
        {
            this.deltaHP = deltaHP;
        }

        public override void Execute()
        {
            this.target.ChangeHealth(deltaHP);
        }
    }
}
