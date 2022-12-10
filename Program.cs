using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Factories;
using MartinMatta_MerlinCore.Spells;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;

namespace MartinMatta_MerlinCore
{
    public class Program
    {
        static void Main(string[] args)
        {

            GameContainer container = new GameContainer("window name", 1600, 590);
            container.SetMap("resources/maps/catmap.tmx");
            container.GetWorld().SetPhysics(new Gravity());
            container.GetWorld().SetFactory(new ActorFactory());
            container.SetCameraFollowStyle(Merlin2d.Game.Enums.CameraFollowStyle.CenteredInsideMapPreferTop);

            container.GetWorld().AddInitAction(world =>
            {
                IActor player = world.GetActors().Find(x => x.GetName() == "Merlin");
                IActor enemy = world.GetActors().Find(x => x.GetName() == "Spooky Scary Skeleton");
                world.CenterOn(player);
                ((Skeleton)enemy).SetPlayerToChase(player);

                player.GetAnimation().SetAnimationLayer(AnimationLayer.Low);

                List<IActor> stations = world.GetActors().FindAll(x => x is AbstractPotionStation);
                foreach (IActor station in stations)
                {
                    station.GetAnimation().SetAnimationLayer(AnimationLayer.High);
                }

                IActor teleport1 = world.GetActors().Find(x => x.GetName() == "Teleporter 1");
                IActor teleport2 = world.GetActors().Find(x => x.GetName() == "Teleporter 2");
                (teleport1 as Teleporter).Subscribe((Teleporter)teleport2);

                world.SetEndCondition(world =>
                    {
                        IActor player = world.GetActors().Find(x => x.GetName() == "Merlin");
                        List<IActor> skeletons = world.GetActors().FindAll(x => x.GetName() == "Spooky Scary Skeleton");
                        List<IActor> spawners = world.GetActors().FindAll(x => x is SkeletonSpawner);
                        List<IActor> enemies = skeletons.Concat(spawners).ToList();
                        if(enemies == null || enemies.Count == 0)
                        {
                            return MapStatus.Finished;
                        }
                        if (player == null)
                        {
                            return MapStatus.Failed;
                        }
                        return MapStatus.Unfinished;
                    });

                Message messageBad = new Message("Game over", 100, 100, 20, Color.White, MessageDuration.Indefinite);
                Message messageGood = new Message("You won!", 100, 100, 20, Color.White, MessageDuration.Indefinite);
                container.SetEndGameMessage(messageBad, MapStatus.Failed);
                container.SetEndGameMessage(messageGood, MapStatus.Finished);
            });


            container.Run();

            /*SpellDataProvider loader = SpellDataProvider.GetInstance();
            Console.WriteLine(loader.GetSpellInfo());
            Console.WriteLine(loader.GetSpellEffects());
            Console.WriteLine();*/
        }
    }
}