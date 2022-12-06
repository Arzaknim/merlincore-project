using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class SkeletonBase
    {
        private static SkeletonBase instance;
        private Animation animation;
        public static SkeletonBase GetInstance()
        {
            if (instance == null)
            {
                instance = new SkeletonBase();
            }

            return instance;
        }

        private SkeletonBase()
        {
            this.animation = new Animation("resources/sprites/skeleton.png", 33, 47);
        }

        public Animation GetAnimation()
        {
            return this.animation;
        }
    }
}
