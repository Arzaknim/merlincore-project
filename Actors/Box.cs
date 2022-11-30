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
        private IMovement moveLeft;
        private IMovement moveRight;
        private int speed;
        private bool inALeftCorner;
        private bool inARightCorner;


        public Box()
        {
            this.strategy = new NormalSpeedStrategy();
            this.animation = new Animation("resources/yellowbox.png", 40, 40);
            this.animation.Start();
            this.moveLeft = new Move(this, -1, 0);
            this.moveRight = new Move(this, 1, 0);
            this.speed = 1;
            this.inALeftCorner = false;
            this.inARightCorner = false;
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
                        if (this.inALeftCorner)
                        {
                            Console.WriteLine("in a corner");
                            actorItem.SetPosition(this.GetX() + this.GetWidth() + 1, actorItem.GetY());
                        }
                        else if (this.inARightCorner)
                        {
                            actorItem.SetPosition(this.GetX() - actorItem.GetWidth() - 1, actorItem.GetY());
                        }
                        else
                        {
                            /*Console.WriteLine(this.GetY());
                            Console.WriteLine("----");
                            Console.WriteLine(actorItem.GetY() + actorItem.GetHeight());
                            Console.WriteLine();*/
                            /*if ((this.GetY() + this.GetHeight()) >= (actorItem.GetY() + actorItem.GetHeight()))
                            {
                                actorItem.SetPosition(actorItem.GetX(), this.GetY() - actorItem.GetHeight() - 1);
                                Console.WriteLine("should stand on box");
                            }*/
                            if (this.GetX() < actorItem.GetX())
                            {
                                Console.WriteLine("right of box");
                                // && this.GetWorld().IsWall(this.GetX() - 1, this.GetY())
                                while (this.IntersectsWithActor(actorItem) && (!this.inALeftCorner && !this.inARightCorner))
                                {
                                    if (!this.moveLeft.Execute())
                                    {
                                        this.inALeftCorner = true;
                                    }
                                }
                            }
                            else if (this.GetX() > actorItem.GetX())
                            {
                                Console.WriteLine("left of box");
                                while (this.IntersectsWithActor(actorItem) && (!this.inALeftCorner && !this.inARightCorner))
                                {
                                    if (!this.moveRight.Execute())
                                    {
                                        this.inARightCorner = true;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("dunno");
                            }
                        }
                    } 
                }
            }
        }
    }
}
