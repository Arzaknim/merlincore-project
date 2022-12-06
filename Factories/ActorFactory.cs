using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Items;
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
                actor = new Skeleton(150, 3);
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
                actor.SetPhysics(true);
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
            else if (actorType == "healingpotion")
            {
                actor = new HealingPotion(30);
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "manapotion")
            {
                actor = new ManaPotion(30);
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "manapotionstation")
            {
                actor = new ManaPotionStation();
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "healthpotionstation")
            {
                actor = new HealthPotionStation();
                actor.SetPhysics(true);
                actor.SetName(actorName);
                actor.SetPosition(x, y);

            }
            else if (actorType == "teleporter")
            {
                actor = new Teleporter();
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
