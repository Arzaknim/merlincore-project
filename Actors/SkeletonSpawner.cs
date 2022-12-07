using MartinMatta_MerlinCore.Actors.Interfaces;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class SkeletonSpawner : Box, ICharacter
    {
        private Skeleton skelly;
        private IActor player;
        private Random rng;
        private int n;
        private int current;
        private int health;

        public SkeletonSpawner(int n) : base()
        {
            this.n = n;
            this.rng = new Random();
            this.health = 150;
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
            if(this.health > 0)
            {
                base.Update();
                if (player == null)
                    this.SetPlayer();

                //Console.WriteLine("sex v meste");
                if((this.skelly == null || this.skelly.RemovedFromWorld()) && this.current < this.n)
                {
                    this.skelly = new Skeleton(300, 3);
                    this.GetWorld().AddActor((IActor)this.skelly);
                    this.skelly.SetPhysics(false);
                    this.skelly.SetName("Spooky Scary Skeleton");
                    do
                    {
                        this.skelly.SetPosition(this.rng.Next(30, 1570), this.rng.Next(30, 560));
                    }
                    while (this.GetWorld().IntersectWithWall(this.skelly) || this.IntersectsWithActor(this.player) || this.IsInSafeZone(this.skelly)) ;
                    this.skelly.SetPlayerToChase(this.player);
                    this.current++;
                }
            }
            else
            {
                this.Die();
            }
        }

        public void ChangeHealth(int delta)
        {
            this.health += delta;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public void Die()
        {
            this.RemoveFromWorld();
        }

        private bool IsInSafeZone(IActor skeleton)
        {
            List<IActor> safehouses = this.GetWorld().GetActors().FindAll(x => x is SafeHouse);
            foreach (IActor safehouse in safehouses)
            {
                if (skeleton.IntersectsWithActor(safehouse))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddEffect(ICommand effect)
        {
        }

        public void RemoveEffect(ICommand effect)
        {
        }
    }
}
