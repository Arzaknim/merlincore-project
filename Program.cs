using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Factories;
using MartinMatta_MerlinCore.Spells;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

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

                IActor teleport1 = world.GetActors().Find(x => x.GetName() == "Teleporter 1");
                IActor teleport2 = world.GetActors().Find(x => x.GetName() == "Teleporter 2");
                (teleport1 as Teleporter).Subscribe((Teleporter)teleport2);
            });

            container.Run();

            /*SpellDataProvider loader = SpellDataProvider.GetInstance();
            Console.WriteLine(loader.GetSpellInfo());
            Console.WriteLine(loader.GetSpellEffects());
            Console.WriteLine();*/
        }
    }
}