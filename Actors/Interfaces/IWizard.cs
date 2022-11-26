using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Interfaces
{
    public interface IWizard : IActor
    {
        void ChangeMana(int delta);
        int GetMana();
        void Cast(ISpell spell);
    }

}
