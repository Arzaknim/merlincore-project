using MartinMatta_MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Effects
{
    public class SpeedUpEffect : AbstractSpellEffect
    {
        public override void Execute()
        {
            this.target.SetSpeedStrategy(new SpeedUpSpeedStrategy());
        }
    }
}
