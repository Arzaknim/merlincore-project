using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
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
    public class Box : AbstractActor, IMovable
    {
        private ISpeedStrategy strategy;
        private ICommand moveLeft;
        private ICommand moveRight;
        private int speed;

        public Box()
        {
            this.strategy = new NormalSpeedStrategy();
            this.animation = new Animation("resources/yellowbox.png", 40, 40);
            this.animation.Start();
            this.moveLeft = new Move(this, -1, 0);
            this.moveRight = new Move(this, 1, 0);
            this.speed = 1;
        }

        public double GetSpeed()
        {
            return this.strategy.GetSpeed(this.speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.strategy = strategy;
        }

        public override void Update()
        {
            List<IActor> actors = this.GetWorld().GetActors();
            actors.Remove(this);
            if (actors != null || actors.Count() != 0)
            {
                foreach(IActor actorItem in actors)
                {
                    if(this.IntersectsWithActor(actorItem))
                    {
                        if(this.GetY() >= actorItem.GetY() + actorItem.GetHeight())
                        {
                            actorItem.SetPosition(actorItem.GetX(), actorItem.GetY()-1);
                        }
                        if(this.GetX() < actorItem.GetX())
                        {
                            // && this.GetWorld().IsWall(this.GetX() - 1, this.GetY())
                            while (this.IntersectsWithActor(actorItem))
                            {
                                this.moveLeft.Execute();
                            }
                        }
                        else if (this.GetX() > actorItem.GetX())
                        {
                            while (this.IntersectsWithActor(actorItem))
                            {
                                this.moveRight.Execute();
                            }
                        }
                    } 
                }
            }
        }
    }
}
