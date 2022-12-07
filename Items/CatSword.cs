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
        private Move moveRight;
        private Move moveLeft;
        private ActorOrientation orientation;


        public CatSword(Player player)
        {
            this.damage = 50;
            this.inUse = false;
            this.player = player;
            this.thrustCounter = 0;
            this.moveRight = new Move(this, 1, 0);
            this.moveLeft = new Move(this, -1, 0);
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
                if (this.thrustTimer == 10 && this.thrustCounter < 6)
                {
                    if(player.GetOrientation() == ActorOrientation.RIGHT)
                    {
                        this.moveRight.Execute();
                    }
                    else if (player.GetOrientation() == ActorOrientation.LEFT)
                    {
                        this.moveLeft.Execute();
                    }
                    this.thrustCounter++;
                    this.thrustTimer = 0;
                }
                else if (this.thrustTimer == 10 && this.thrustCounter >= 6)
                {
                    if (player.GetOrientation() == ActorOrientation.RIGHT)
                    {
                        this.moveLeft.Execute();
                    }
                    else if (player.GetOrientation() == ActorOrientation.LEFT)
                    {
                        this.moveRight.Execute();
                    }
                    this.thrustCounter++;
                    this.thrustTimer = 0;
                    if(thrustCounter == 11)
                    {
                        thrustCounter = 0;
                        this.inUse = false;
                        this.hasDealtDamage = false;
                        this.RemoveFromWorld();
                        this.SetPhysics(true);
                    }
                }
                List<IActor> skeletons = this.GetWorld().GetActors().FindAll(x => x.GetName() == "Spooky Scary Skeleton");
                List<IActor> spawners = this.GetWorld().GetActors().FindAll(x => x is SkeletonSpawner);
                List<IActor> enemies = skeletons.Concat(spawners).ToList();
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

        public void Use(IActor actor)
        {
            this.inUse = true;
            this.SetPhysics(false);
            this.animation.Start();
            this.player.GetWorld().AddActor(this);
            this.OnAddedToWorld(this.player.GetWorld());
            int casterFrontX = 0;
            int casterMiddleY = casterMiddleY = this.player.GetY() + this.player.GetAnimation().GetHeight() / 2;
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
