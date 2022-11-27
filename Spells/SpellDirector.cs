using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class SpellDirector : ISpellDirector
    {
        private ProjectileSpellBuilder projectileSpellBuilder;
        private SelfCastSpellBuilder selfCastSpellBuilder;
        private IWizard wizard;

        private List<string> spells;

        public SpellDirector(IWizard wizard)
        {
            this.projectileSpellBuilder = new ProjectileSpellBuilder();
            this.selfCastSpellBuilder = new SelfCastSpellBuilder(wizard);
            this.wizard = wizard;
            this.spells = new List<string>();
            this.spells.Add("Into the Fray!");
            this.spells.Add("icicle");
        }

        public ISpell Build(string spellName)
        {
            if (this.spells.Contains(spellName))
            {
                if(spellName == "icicle")
                {
                    if(this.wizard.GetMana() >= 25)
                    {
                        this.wizard.ChangeMana(-25);
                        this.projectileSpellBuilder.Spell = spellName;
                        return this.projectileSpellBuilder.AddEffect("frostbite").CreateSpell(wizard);
                    }
                }
                else if(spellName == "Into the Fray!")
                {
                    if(this.wizard.GetMana() >= 50)
                    {
                        this.wizard.ChangeMana(-50);
                        this.selfCastSpellBuilder.Spell = spellName;
                        ISpell spell = this.selfCastSpellBuilder.AddEffect("speedup").AddEffect("heal").CreateSpell(wizard);
                        this.wizard.GetWorld().AddActor((IActor)spell);
                        return spell;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
