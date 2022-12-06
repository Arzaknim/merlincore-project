using MartinMatta_MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Effects
{
    public class FrostbiteEffect : AbstractSpellEffect
    {
        public FrostbiteEffect(int cost) : base(cost)
        {
        }

        public override void Execute()
        {
            if(this.target is AbstractCharacter)
            {
                this.target.SetSpeedStrategy(new ModifiedSpeedStrategy());
            }
        }
    }
}
