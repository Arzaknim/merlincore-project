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
        public ISpell AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            throw new NotImplementedException();
        }

        public void ApplyEffects(ICharacter target)
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }
    }
}
