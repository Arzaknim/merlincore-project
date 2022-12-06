using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class PressurePlate : AbstractActor, IObservable
    {

        public PressurePlate()
        {
            this.SetAnimation(new Animation("resources/pressureplate.png", 20, 5));
            this.GetAnimation().Start();
        }

        public void Subscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            IActor player = this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin");
            List<IActor> applicable = this.GetWorld().GetActors().FindAll(x => x is Box);
            applicable.Add(player);
            bool onTop = false;
            foreach(IActor actorItem in applicable)
            {
                if ((this as AbstractActor).IntersectsWithActor(actorItem))
                {
                    onTop = true;
                    break;
                }
            }

            if (onTop)
            {
                Console.WriteLine("meow");
                this.GetWorld().SetWall(13, 28, false);
                this.GetWorld().SetWall(13, 27, false);
                this.GetWorld().SetWall(13, 26, false);
                this.GetWorld().SetWall(13, 25, false);
                this.GetWorld().SetWall(13, 24, false);
                this.GetWorld().SetWall(13, 23, false);
                this.GetWorld().SetWall(13, 22, false);

                this.GetWorld().SetWall(12, 28, false);
                this.GetWorld().SetWall(12, 27, false);
                this.GetWorld().SetWall(12, 26, false);
                this.GetWorld().SetWall(12, 25, false);
                this.GetWorld().SetWall(12, 24, false);
                this.GetWorld().SetWall(12, 23, false);
                this.GetWorld().SetWall(12, 22, false);
            }
            else
            {
                this.GetWorld().SetWall(13, 28, true);
                this.GetWorld().SetWall(13, 27, true);
                this.GetWorld().SetWall(13, 26, true);
                this.GetWorld().SetWall(13, 25, true);
                this.GetWorld().SetWall(13, 24, true);
                this.GetWorld().SetWall(13, 23, true);
                this.GetWorld().SetWall(13, 22, true);

                this.GetWorld().SetWall(12, 28, true);
                this.GetWorld().SetWall(12, 27, true);
                this.GetWorld().SetWall(12, 26, true);
                this.GetWorld().SetWall(12, 25, true);
                this.GetWorld().SetWall(12, 24, true);
                this.GetWorld().SetWall(12, 23, true);
                this.GetWorld().SetWall(12, 22, true);
            }
        }
    }
}
