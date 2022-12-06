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
        private SpellInfo info;
        private IcicleSpellBase icicle;
        //private AbstractWizardCharacter wizard;

        private string spellToExecute;

        public string Spell
        {
            get { return this.spellToExecute; }
            set { this.spellToExecute = value; }
        }

        public ProjectileSpellBuilder()
        {
            this.factory = new SpellEffectFactory();
            this.NewEmptyEffectsList();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName == "FrostbiteEffect")
            {
                ((List<ICommand>)this.effects).Add(this.factory.CreateEffect(effectName));
            }
            else if(effectName == "OnHitDamageEffect")
            {
                ((List<ICommand>)this.effects).Add(this.factory.CreateEffect(effectName));
            }
            return this;
        }

        public ISpellBuilder SetSpellInfo(SpellInfo info)
        {
            this.info = info;
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            if (this.Spell == "icicle")
            {
                this.icicle = IcicleSpellBase.GetInstance(info);
                ISpell spell = new ProjectileSpell((AbstractCharacter)wizard, 10, 160, this.effects, this.icicle.GetAnimation());
                (spell as ProjectileSpell).GetAnimation().Start();
                /*this.OnAddedToWorld(caster.GetWorld());*/
                this.NewEmptyEffectsList();
                return spell;
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

        private void NewEmptyEffectsList()
        {
            this.effects = new List<ICommand>();
        }
    }
}
