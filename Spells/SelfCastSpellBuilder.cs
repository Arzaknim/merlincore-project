using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        private AbstractWizardCharacter wizard;

        private SpeedUpSpeedStrategy speedUpSpeedStrategy;


        public SelfCastSpellBuilder(IWizard wizard)
        {
            this.wizard = (AbstractWizardCharacter)wizard;
            this.speedUpSpeedStrategy = new SpeedUpSpeedStrategy();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName == "heal")
            {
                this.wizard.ChangeHealth(+25);
            }
            else if(effectName == "speedup")
            {
                this.wizard.SetSpeedStrategy(this.speedUpSpeedStrategy);
            }
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            return new IntoTheFraySpell();
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
