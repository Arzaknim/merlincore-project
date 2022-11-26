﻿using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace MartinMatta_MerlinCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            GameContainer container = new GameContainer("window name", 500, 500);
            container.SetMap("resources/maps/map01.tmx");
            container.GetWorld().SetPhysics(new Gravity());
            container.GetWorld().SetFactory(new ActorFactory());
            container.SetCameraFollowStyle(Merlin2d.Game.Enums.CameraFollowStyle.CenteredInsideMapPreferTop);

            container.GetWorld().AddInitAction(world =>
            {
                IActor player = world.GetActors().Find(x => x.GetName() == "Merlin");
                IActor enemy = world.GetActors().Find(x => x.GetName() == "Spooky Scary Skeleton");
                world.CenterOn(player);
                ((Skeleton)enemy).SetPlayerToChase(player);
            });

            container.Run();
        }
    }
}