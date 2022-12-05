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
            this.NewEmptyEffectsList();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName == "HealEffect")
            {
                ((List<ICommand>)this.effects).Add(this.factory.CreateEffect(effectName));
            }
            else if(effectName == "SpeedUpEffect")
            {
                //this.wizard.SetSpeedStrategy(this.speedUpSpeedStrategy);
                ((List<ICommand>)this.effects).Add(this.factory.CreateEffect(effectName));
            }
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            ISpell spell = new SelfCastSpell(this.effects);
            this.NewEmptyEffectsList();
            return spell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            //throw new NotImplementedException();
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            //throw new NotImplementedException();
            return this;
        }

        public void NewEmptyEffectsList()
        {
            this.effects = new List<ICommand>();
        }
    }
}
