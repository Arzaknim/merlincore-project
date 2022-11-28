using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Effects
{
    public class HealEffect : AbstractSpellEffect
    {
        private int deltaHP;

        public HealEffect(int deltaHP)
        {
            this.deltaHP = deltaHP;
        }

        public override void Execute()
        {
            this.target.ChangeHealth(this.deltaHP);
        }
    }
}
