using MartinMatta_MerlinCore.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Factories
{
    public class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor;

            if(actorType == "player")
            {
                actor = new Player(x, y, 5);
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "skeleton")
            {
                actor = new Skeleton(10, 3);
                actor.SetPhysics(false);
                actor.SetName(actorName);
                actor.SetPosition(x, y);
                
            }
            else if (actorType == "pressureplate")
            {
                actor = new PressurePlate();
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "skeletonspawner")
            {
                actor = new SkeletonSpawner(0);
                actor.SetPhysics(false);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "yellowbox")
            {
                actor = new Box();
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else
            {
                throw new ArgumentException("meow");
            }

            return actor;
        }
    }
}
