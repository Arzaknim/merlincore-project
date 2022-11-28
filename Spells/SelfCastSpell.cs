using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class SelfCastSpell : ISpell
    {
        private IEnumerable<ICommand> effects;

        public SelfCastSpell(IEnumerable<ICommand> effects)
        {
            this.effects = new List<ICommand>();
            this.AddEffects(effects);
        }

        public ISpell AddEffect(ICommand effect)
        {
            ((List<ICommand>)this.effects).Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            foreach (ICommand effectItem in effects)
            {
                ((List<ICommand>)this.effects).Add(effectItem);
            }
        }

        public void ApplyEffects(ICharacter target)
        {
            foreach (ICommand effectItem in this.effects)
            {
                ((AbstractSpellEffect)effectItem).SetTarget((AbstractCharacter)target);
                effectItem.Execute();
            }
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }
    }
}
