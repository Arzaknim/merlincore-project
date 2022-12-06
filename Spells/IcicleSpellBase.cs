using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class IcicleSpellBase : AbstractActor//, IFlyweightBase
    {
        private static IcicleSpellBase instance;

        public static IcicleSpellBase GetInstance(SpellInfo info)
        {
            if (instance == null)
            {
                instance = new IcicleSpellBase(info);
            }

            return instance;
        }

        private IcicleSpellBase(SpellInfo info)
        {
            this.animation = new Animation(info.AnimationPath, info.AnimationWidth, info.AnimationHeight);
        }


        public override void Update()
        {
        }
    }
}
