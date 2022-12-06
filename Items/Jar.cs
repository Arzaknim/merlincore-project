using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Items
{
    public class Jar : AbstractActor, IItem
    {
        private JarBase instance;

        public Jar()
        {
            this.instance = JarBase.GetInstance();
            this.SetAnimation(this.instance.GetAnimation());
            this.SetPhysics(true);
            this.animation.Start();
        }

        public Jar SetWorld(IWorld world)
        {
            this.OnAddedToWorld(world);
            return this;
        }

        public override void Update()
        {
        }
    }
}
