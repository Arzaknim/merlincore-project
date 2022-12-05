using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace MartinMatta_MerlinCore.Actors
{
    public class Teleporter : AbstractActor, IUsable, IObservable, IObserver
    {
        private Teleporter other;
        private IActor toBeTeleported;

        public Teleporter()
        {
            this.animation = new Animation("resources/teleporter.png", 64, 10);
            this.animation.Start();
        }

        public IActor GetToBeTeleported()
        {
            return this.toBeTeleported;
        }

        public void SetToBeTeleported(IActor toBeTeleported)
        {
            this.toBeTeleported = toBeTeleported;
        }

        public Teleporter GetDestinationTeleporter()
        {
            return this.other;
        }

        public void Teleport(IActor actor)
        {
            this.other.Materialize(actor); 
        }
        
        public void Materialize(IActor actor)
        {
            actor.SetPosition(this.GetX() + this.GetWidth()/2 - actor.GetWidth()/2 , this.GetY() - actor.GetHeight() - 1);
        }


        public void Notify(IObservable observable)
        {
            this.other.SetToBeTeleported(this.toBeTeleported);

        }

        public void Subscribe(IObserver observer)
        {
            this.other = (observer as Teleporter);
            if(this.other.GetDestinationTeleporter() == null)
            {
                this.other.Subscribe(this);
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            this.other = null;
        }

        public override void Update()
        {
            List<IActor> actors = this.GetWorld().GetActors();
            actors.Remove(this);
            if (actors != null || actors.Count() != 0)
            {
                foreach (IActor actorItem in actors)
                {
                    if (this.IntersectsWithActor(actorItem))
                    {
                        Console.WriteLine($"Box: {this.GetX()}, {this.GetY()}");
                        Console.WriteLine("----");
                        Console.WriteLine($"Player: {actorItem.GetX()}, {actorItem.GetY()}, width = {actorItem.GetWidth()}");
                        Console.WriteLine();
                        if (this.GetY() + 3 >= actorItem.GetY() + actorItem.GetHeight())
                        {
                            actorItem.SetPosition(actorItem.GetX(), this.GetY() - actorItem.GetHeight() + 1);
                            Console.WriteLine("should stand on box");
                        }
                        else if (this.GetX() < actorItem.GetX())
                        {
                            actorItem.SetPosition(this.GetX() + this.GetWidth() + 1, actorItem.GetY());
                        }
                        else if (this.GetX() > actorItem.GetX())
                        {
                            actorItem.SetPosition(this.GetX() - actorItem.GetWidth() - 1, actorItem.GetY());
                        }
                    }
                }
            }
        }

        public void Use(IActor actor)
        {
            this.toBeTeleported = actor;
            this.Notify(this.other);
            this.Teleport(actor);
        }
    }
}
