using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public abstract class AbstractActor : IActor
    {
        private string name;
        private int posX;
        private int posY;
        protected Animation animation;
        private IWorld world;
        private bool affectedByPhysics;
        private bool toBeRemoved;

        public AbstractActor()
        {
            this.name = "";
        }

        public AbstractActor(string name) 
        { 
            this.name = name;
        }

        public Animation GetAnimation()
        {
            return this.animation;
        }

        public int GetHeight()
        {
            return this.animation.GetHeight();
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetWidth()
        {
            return this.animation.GetWidth();
        }

        public IWorld GetWorld()
        {
            return this.world;
        }

        public int GetX()
        {
            return this.posX;
        }

        public int GetY()
        {
            return this.posY;
        }

        public bool IntersectsWithActor(IActor actor)
        {
            if ((posX < actor.GetX() - GetWidth()) || (posX > actor.GetX() + actor.GetWidth()))
            {
                return false;
            }

            if ((posY < actor.GetY() - GetHeight()) || (posY > actor.GetY() + actor.GetHeight()))
            {
                return false;
            }
            return true;
            /*Console.WriteLine("doesnt intersect");
            Console.WriteLine("enemy");
            Console.WriteLine($"{this.GetX()}, {this.GetY()}, {this.GetWidth()}, {this.GetHeight()}");
            Console.WriteLine("player");
            Console.WriteLine($"{other.GetX()}, {other.GetY()}, {other.GetWidth()}, {other.GetHeight()}");*/
        }

        public bool IsAffectedByPhysics()
        {
            return this.affectedByPhysics;
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public bool RemovedFromWorld()
        {
            return this.toBeRemoved;
        }

        public void RemoveFromWorld()
        {
            this.toBeRemoved = true;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            this.affectedByPhysics = isPhysicsEnabled;
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public abstract void Update();
    }
}
