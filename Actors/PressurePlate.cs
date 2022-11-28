using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class PressurePlate : AbstractActor
    {

        public PressurePlate(int x, int y)
        {
            this.SetAnimation(new Animation("resources/pressureplate.png", 20, 5));
            this.SetPosition(x, y);
            this.GetAnimation().Start();
        }
        public override void Update()
        {
        }
    }
}
