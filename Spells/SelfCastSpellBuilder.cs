using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
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
        private IEnumerable<ICommand> effects;
        private SpeedUpSpeedStrategy speedUpSpeedStrategy;
        private SpellEffectFactory factory;

        private string spellToExecute;

        public string Spell
        {
            get { return this.spellToExecute; }
            set { this.spellToExecute = value; }
        }


        public SelfCastSpellBuilder(IWizard wizard)
        {
            this.wizard = (AbstractWizardCharacter)wizard;
            this.speedUpSpeedStrategy = new SpeedUpSpeedStrategy();
            this.factory = new SpellEffectFactory();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName == "Heal")
            {
                ((List<ICommand>)this.effects).Add(this.factory.CreateEffect(effectName));
            }
            else if(effectName == "SpeedUp")
            {
                //this.wizard.SetSpeedStrategy(this.speedUpSpeedStrategy);
                ((List<ICommand>)this.effects).Add(this.factory.CreateEffect(effectName));
            }
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            if(this.Spell == "Into the Fray!")
            {
                return new IntoTheFraySpell(this.effects);
            }
            return null;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }

        public void EmptyEffectsList()
        {
            this.effects = new List<ICommand>();
        }
    }
}
