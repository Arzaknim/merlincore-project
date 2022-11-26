using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName == "frostbite")
            {

            }
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }
    }
}
