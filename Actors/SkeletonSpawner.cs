using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class SkeletonSpawner : AbstractActor
    {
        private Skeleton skelly;
        private IActor player;
        private int n;
        private int current;

        public SkeletonSpawner(int n)
        {
            this.n = n;
            this.current = 0;
            this.animation = new Animation("resources/skeletonspawner.png", 40, 40);
            this.animation.Start();
        }

        private void SetPlayer()
        {
            this.player = this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin");
        }

        public override void Update()
        {
            if (player == null)
                this.SetPlayer();

            //Console.WriteLine("sex v meste");
            if((this.skelly == null || this.skelly.RemovedFromWorld()) && this.current < this.n)
            {
                this.skelly = new Skeleton(150, 3);
                this.GetWorld().AddActor((IActor)this.skelly);
                this.skelly.SetPhysics(false);
                this.skelly.SetName("Spooky Scary Skeleton");
                this.skelly.SetPosition(400, 250);
                this.skelly.SetPlayerToChase(this.player);
                this.current++;
            }
        }
    }
}
