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
    public class ProjectileSpellBuilder : ISpellBuilder
    {

        private SpellEffectFactory factory;
        private IEnumerable<ICommand> effects;
        //private AbstractWizardCharacter wizard;

        private string spellToExecute;

        public string Spell
        {
            get { return this.spellToExecute; }
            set { this.spellToExecute = value; }
        }

        public ProjectileSpellBuilder()
        {
            this.effects = new List<ICommand>();
            this.factory = new SpellEffectFactory();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName == "frostbite")
            {
            }
            else if(effectName == "OnHitDamage")
            {
                this.effects.Append(this.factory.CreateEffect(effectName));
            }
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            if (this.Spell == "icicle")
            {
                return new IcicleSpell((AbstractCharacter)wizard, 10, 160);
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
    }
}
