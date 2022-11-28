using MartinMatta_MerlinCore.Spells.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class SpellEffectFactory
    {
        public SpellEffect CreateEffect(string effectName)
        {
            if(effectName == "OnHitDamage")
            {
                return new OnHitDamageEffect(-50);
            }
            return null;
        }
    }
}
