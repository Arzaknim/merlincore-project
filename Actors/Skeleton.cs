using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class Skeleton : AbstractCharacter
    {
        private SkeletonBase instance;

        private int n;
        private IActor player;
        private NormalSpeedStrategy normalSpeedStrategy;

        private int modifiedCounter;

        private Random rng;
        private Move moveUp;
        private Move moveDown;
        private Move moveLeft;
        private Move moveRight;
        private Move lastMove;

        public Skeleton(int n, double speed)
        {
            this.instance = SkeletonBase.GetInstance();
            this.speed = speed;
            this.animation = this.instance.GetAnimation();
            this.normalSpeedStrategy = new NormalSpeedStrategy();
            this.strategy = this.normalSpeedStrategy;
            this.rng = new Random();
            this.n = n;
            Console.WriteLine("speed");
            Console.WriteLine(this.speed);
            this.player = null;
            this.moveUp = new Move(this, 0, -1);
            this.moveDown = new Move(this, 0, 1);
            this.moveLeft = new Move(this, -1, 0);
            this.moveRight = new Move(this, 1, 0);
            this.lastMove = this.moveRight;

            this.SetAnimation(this.animation);
            this.GetAnimation().Start();

            this.modifiedCounter = 0;
        }

        public override void Update()
        {
            //Console.WriteLine(this.GetHealth());
            IActor player = this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin");
            //Console.WriteLine(this.strategy);
            if (this.GetHealth() > 0)
            {
                if (player != null)
                {
                    if (this.strategy is ModifiedSpeedStrategy)
                    {
                        if (this.modifiedCounter == 180)
                        {
                            this.modifiedCounter = 0;
                            this.strategy = this.normalSpeedStrategy;
                        }
                        this.modifiedCounter++;
                    }
                    if (this.IsPlayerClose())
                    {
                        int dx = this.player.GetX() - this.GetX();
                        int dy = this.player.GetY() - this.GetY();
                        if (dy <= 0 && Math.Abs(dx) <= Math.Abs(dy))
                        {
                            this.animation.Start();
                            this.moveUp.Execute();
                        }
                        else if (dy >= 0 && Math.Abs(dx) <= Math.Abs(dy))
                        {
                            this.animation.Start();
                            this.moveDown.Execute();
                        }
                        else if (dx <= 0 && Math.Abs(dx) >= Math.Abs(dy))
                        {
                            if (this.lastMove == this.moveRight)
                            {
                                this.animation.FlipAnimation();
                                this.lastMove = this.moveLeft;
                            }
                            this.animation.Start();
                            this.moveLeft.Execute();
                        }
                        else if (dx >= 0 && Math.Abs(dx) >= Math.Abs(dy))
                        {
                            if (this.lastMove == this.moveLeft)
                            {
                                this.animation.FlipAnimation();
                                this.lastMove = this.moveRight;
                            }
                            this.animation.Start();
                            this.moveRight.Execute();
                        }
                    }
                    else
                    {
                        int num = this.rng.Next(0, 100);

                        if (num < 25)
                        {
                            this.animation.Start();
                            this.moveUp.Execute();
                        }
                        else if (num < 50)
                        {
                            this.animation.Start();
                            this.moveDown.Execute();
                        }
                        else if (num < 75)
                        {
                            if (this.lastMove == this.moveRight)
                            {
                                this.animation.FlipAnimation();
                                this.lastMove = this.moveLeft;
                            }
                            this.animation.Start();
                            this.moveLeft.Execute();
                        }
                        else if (num < 100)
                        {
                            if (this.lastMove == this.moveLeft)
                            {
                                this.animation.FlipAnimation();
                                this.lastMove = this.moveRight;
                            }
                            this.animation.Start();
                            this.moveRight.Execute();
                        }
                    }
                }
                else
                {
                    this.animation.Stop();
                }
            }
            else
            {
                this.Die();
            }
        }

        private bool IsPlayerClose()
        {
            int dx = this.player.GetX() - this.GetX();
            int dy = this.player.GetY() - this.GetY();
            if ((int)(Math.Sqrt(dx * dx + dy * dy)) <= this.n)
            {
                /*this.IntersectsWithActor(this.player);*/
                return true;
            }
            return false;
        }

        public void SetPlayerToChase(IActor player)
        {
            this.player = player;
        }
    }
}
