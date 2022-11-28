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

        private Dictionary<string, int> effectCost;
        Dictionary<string, SpellInfo> effectSpell;

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
                    this.projectileSpellBuilder.Spell = spellName;
                    this.projectileSpellBuilder.EmptyEffectsList();
                    ISpell spell = this.projectileSpellBuilder.AddEffect("Frostbite").AddEffect("OnHitDamage").CreateSpell(wizard);
                    int cost = spell.GetCost();
                    if(this.wizard.GetMana() >= cost)
                    {
                        this.wizard.ChangeMana(-cost);
                        this.wizard.GetWorld().AddActor((IActor)spell);
                        ((IActor)spell).SetPhysics(false);
                    }
                    else
                    {
                        spell = null;
                    }
                    return spell;
                }
                else if(spellName == "Into the Fray!")
                {
                    this.selfCastSpellBuilder.Spell = spellName;
                    this.selfCastSpellBuilder.EmptyEffectsList();

                    ISpell spell = this.selfCastSpellBuilder.AddEffect("SpeedUp").AddEffect("Heal").CreateSpell(wizard);
                    int cost = spell.GetCost();
                    if (this.wizard.GetMana() >= cost)
                    {
                        this.wizard.ChangeMana(-cost);
                    }
                    else
                    {
                        spell = null;
                    }
                    return spell;
                }
                return null;
            }
            return null;
        }
    }
}
