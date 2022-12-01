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
        private SpellDataProvider loader;
        private Dictionary<string, int> effectCost;

        public SpellEffectFactory()
        {
            this.loader = SpellDataProvider.GetInstance();
            this.effectCost = new Dictionary<string, int>();
            foreach (var item in loader.GetSpellEffects())
            {
                this.effectCost.Add(item.Key, item.Value);
            }
        }

        public AbstractSpellEffect CreateEffect(string effectName)
        {
            if (effectCost.Keys.Contains(effectName))
            {
                if (effectName == "OnHitDamageEffect")
                {
                    return new OnHitDamageEffect(this.effectCost[effectName], -50);
                }
                else if (effectName == "HealEffect")
                {
                    return new HealEffect(this.effectCost[effectName], 25);
                }
                else if (effectName == "SpeedUpEffect")
                {
                    return new SpeedUpEffect(this.effectCost[effectName]);
                }
                else if (effectName == "FrostbiteEffect")
                {
                    return new FrostbiteEffect(this.effectCost[effectName]);
                }
            }
            return null;
        }
    }
}
