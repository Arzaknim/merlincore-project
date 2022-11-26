using MartinMatta_MerlinCore.Actors.Interfaces;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Interfaces
{
    public interface ISpell
    {
        ISpell AddEffect(ICommand effect);
        void AddEffects(IEnumerable<ICommand> effects);
        int GetCost();
        void ApplyEffects(ICharacter target);
    }
}
