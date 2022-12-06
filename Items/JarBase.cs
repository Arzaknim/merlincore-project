using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Items
{
    public class JarBase
    {
        private static JarBase instance;
        private Animation animation;
        public static JarBase GetInstance()
        {
            if (instance == null)
            {
                instance = new JarBase();
            }

            return instance;
        }

        private JarBase()
        {
            this.animation = new Animation("resources/sprites/jar_empty.png", 16, 16);
        }

        public Animation GetAnimation()
        {
            return this.animation;
        }
    }
}
