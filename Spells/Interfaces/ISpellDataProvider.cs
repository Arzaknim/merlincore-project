using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public interface ISpellDataProvider
    {
        public Dictionary<string, SpellInfo> GetSpellInfo();
        public Dictionary<string, int> GetSpellEffects();
    }
}
