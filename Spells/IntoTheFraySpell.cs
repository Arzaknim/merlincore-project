using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Interfaces
{
    public class IntoTheFraySpell : SelfCastSpell
    {
        public IntoTheFraySpell(IEnumerable<ICommand> effects) : base(effects)
        {

        }

    }
}
