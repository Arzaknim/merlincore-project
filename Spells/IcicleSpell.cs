using MartinMatta_MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class IcicleSpell : ProjectileSpell
    {
        public IcicleSpell(AbstractCharacter caster, int speed) : base(caster, speed)
        {
        }
    }
}
