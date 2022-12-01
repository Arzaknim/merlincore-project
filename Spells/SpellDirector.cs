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

        private SpellDataProvider loader;

        public SpellDirector(IWizard wizard)
        {
            this.projectileSpellBuilder = new ProjectileSpellBuilder();
            this.selfCastSpellBuilder = new SelfCastSpellBuilder(wizard);
            this.wizard = wizard;
            this.spells = new List<string>();
            /*this.spells.Add("Into the Fray!");
            this.spells.Add("icicle");*/
            this.effectSpell = new Dictionary<string, SpellInfo>();
            this.effectCost = new Dictionary<string, int>();
            this.loader = SpellDataProvider.GetInstance();
            foreach (var item in loader.GetSpellInfo())
            {
                this.effectSpell.Add(item.Key, item.Value);
                this.spells.Add(item.Key);
            }
            foreach (var item in loader.GetSpellEffects())
            {
                this.effectCost.Add(item.Key, item.Value);
            }
            Console.WriteLine();
        }

        public ISpell Build(string spellName)
        {
            if (this.spells.Contains(spellName))
            {
                if(spellName == "icicle")
                {
                    this.projectileSpellBuilder.Spell = spellName;
                    int cost = this.effectCost["FrostbiteEffect"] + this.effectCost["OnHitDamageEffect"];
                    ISpell spell;
                    if (this.wizard.GetMana() >= cost)
                    {
                        spell = this.projectileSpellBuilder.SetSpellInfo(this.effectSpell[spellName]).AddEffect("FrostbiteEffect").AddEffect("OnHitDamageEffect").CreateSpell(wizard);
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
                    int cost = this.effectCost["SpeedUpEffect"] + this.effectCost["HealEffect"];
                    ISpell spell;
                    if (this.wizard.GetMana() >= cost)
                    {
                        spell = this.selfCastSpellBuilder.AddEffect("SpeedUpEffect").AddEffect("HealEffect").CreateSpell(wizard);
                        this.wizard.ChangeMana(-cost);
                    }
                    else
                    {
                        spell = null;
                    }
                    return spell;
                }
            }
            return null;
        }
    }
}
