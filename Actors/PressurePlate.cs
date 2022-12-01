﻿using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class PressurePlate : AbstractActor, IObservable
    {

        public PressurePlate()
        {
            this.SetAnimation(new Animation("resources/pressureplate.png", 20, 5));
            this.GetAnimation().Start();
        }

        public void Subscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            IActor player = this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin");
            if(player != null)
            {
                if ((this as AbstractActor).IntersectsWithActor(player))
                {
                    Console.WriteLine("meow");
                    this.GetWorld().SetWall(13, 28, false);
                    this.GetWorld().SetWall(13, 27, false);
                    this.GetWorld().SetWall(13, 26, false);
                    this.GetWorld().SetWall(13, 25, false);
                    this.GetWorld().SetWall(13, 24, false);
                    this.GetWorld().SetWall(13, 23, false);
                    this.GetWorld().SetWall(13, 22, false);

                    this.GetWorld().SetWall(12, 28, false);
                    this.GetWorld().SetWall(12, 27, false);
                    this.GetWorld().SetWall(12, 26, false);
                    this.GetWorld().SetWall(12, 25, false);
                    this.GetWorld().SetWall(12, 24, false);
                    this.GetWorld().SetWall(12, 23, false);
                    this.GetWorld().SetWall(12, 22, false);
                }
            }
        }
    }
}