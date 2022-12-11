using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
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
    public class CatSword : AbstractActor ,IItem, IUsable, IMovable
    {
        private Player player;
        private int damage;
        private bool hasDealtDamage;
        private bool inUse;
        private int thrustCounter;
        private int thrustTimer;
        private ActorOrientation orientation;
        private bool hasIntersectedWall;


        public CatSword(Player player)
        {
            this.damage = 50;
            this.inUse = false;
            this.player = player;
            this.thrustCounter = 0;
            this.animation = new Animation("resources/catsword.png", 30, 15);
            this.orientation = ActorOrientation.RIGHT;
            this.hasDealtDamage = false;
        }

        public double GetSpeed()
        {
            return 2;
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            if (this.inUse)
            {
                int centerY = this.player.GetY() + this.player.GetHeight()/2;
                if (this.thrustTimer == 10 && this.thrustCounter < 6)
                {
                    if(player.GetOrientation() == ActorOrientation.RIGHT)
                    {
                        if (this.orientation != ActorOrientation.RIGHT)
                        {
                            this.animation.FlipAnimation();
                            this.orientation = ActorOrientation.RIGHT;
                        }
                        this.SetPosition(this.player.GetX() + this.player.GetWidth() + this.thrustCounter*5 + 1, centerY);
                    }
                    else if (player.GetOrientation() == ActorOrientation.LEFT)
                    {
                        if (this.orientation != ActorOrientation.LEFT)
                        {
                            this.animation.FlipAnimation();
                            this.orientation = ActorOrientation.LEFT;
                        }
                        int possiblyOutOfBounds = this.player.GetX() - this.GetWidth() - this.thrustCounter * 5 - 1;
                        this.SetPosition(possiblyOutOfBounds < 0 ? 0: possiblyOutOfBounds, centerY);
                    }
                    this.thrustCounter++;
                    this.thrustTimer = 0;
                }
                else if (this.thrustTimer == 10 && this.thrustCounter >= 6)
                {
                    if (player.GetOrientation() == ActorOrientation.RIGHT)
                    {
                        if (this.orientation != ActorOrientation.RIGHT)
                        {
                            this.animation.FlipAnimation();
                            this.orientation = ActorOrientation.RIGHT;
                        }
                    }
                    else if (player.GetOrientation() == ActorOrientation.LEFT)
                    {
                        if (this.orientation != ActorOrientation.LEFT)
                        {
                            this.animation.FlipAnimation();
                            this.orientation = ActorOrientation.LEFT;
                        }
                    }

                        /*if (player.GetOrientation() == ActorOrientation.RIGHT)
                        {
                            this.moveLeft.Execute();
                        }
                        else if (player.GetOrientation() == ActorOrientation.LEFT)
                        {
                            this.moveRight.Execute();
                        }*/
                        this.thrustCounter++;
                    this.thrustTimer = 0;
                    if(thrustCounter == 9)
                    {
                        thrustCounter = 0;
                        this.inUse = false;
                        this.hasDealtDamage = false;
                        this.RemoveFromWorld();
                        this.SetPhysics(true);
                        return;
                    }
                }
                List<IActor> skeletons = this.GetWorld().GetActors().FindAll(x => x.GetName() == "Spooky Scary Skeleton");
                List<IActor> spawners = this.GetWorld().GetActors().FindAll(x => x is SkeletonSpawner);
                List<IActor> enemies = skeletons.Concat(spawners).ToList();
                while (this.GetWorld().IntersectWithWall(this))
                {
                    int bounds = 0;
                    if(this.orientation == ActorOrientation.LEFT)
                    {
                        bounds = this.GetX() + 1;
                    }
                    else if(this.orientation == ActorOrientation.RIGHT)
                    {
                        bounds = this.GetX() - 1;
                    }
                    this.SetPosition(bounds < 0 ? 0 : bounds, this.GetY());
                }
                if (!this.hasDealtDamage)
                {
                    foreach (IActor enemy in enemies)
                    {
                        if (this.IntersectsWithActor(enemy))
                        {
                            (enemy as ICharacter).ChangeHealth(-this.damage);
                            this.hasDealtDamage = true;
                        }
                    }
                }
                this.thrustTimer++;
            }
        }

        public bool IsInUse()
        {
            return this.inUse;
        }

        public void Use(IActor actor)
        {
            if (!this.inUse)
            {
                this.inUse = true;
                this.hasIntersectedWall = false;
                this.SetPhysics(false);
                this.animation.Start();
                this.player.GetWorld().AddActor(this);
                this.OnAddedToWorld(this.player.GetWorld());
                int casterFrontX = 0;
                int casterMiddleY = this.player.GetY() + this.player.GetAnimation().GetHeight() / 2;
                if (this.player.GetOrientation() == ActorOrientation.RIGHT)
                {
                    if (this.orientation == ActorOrientation.LEFT)
                    {
                        this.animation.FlipAnimation();
                        this.orientation = ActorOrientation.RIGHT;
                    }
                    casterFrontX = this.player.GetX() + this.player.GetAnimation().GetWidth();
                }
                else if (this.player.GetOrientation() == ActorOrientation.LEFT)
                {   
                    if(this.orientation == ActorOrientation.RIGHT)
                    {
                        this.animation.FlipAnimation();
                        this.orientation = ActorOrientation.LEFT;
                    }
                    casterFrontX = this.player.GetX() - this.GetWidth();
                }
                this.SetPosition(casterFrontX, casterMiddleY);
                this.ReturnToWorld();
            }
        }
    }
}
