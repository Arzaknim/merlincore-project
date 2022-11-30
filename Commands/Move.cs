using MartinMatta_MerlinCore.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace MartinMatta_MerlinCore.Commands
{
    public class Move : ICommand
    {
        private IActor actor;
        private double step;
        private int dx;
        private int dy;
        private double decimalChange;

        public Move(IMovable movable, int dx, int dy)
        {
            if (!(movable is IActor))
            {
                throw new ArgumentException("Can only move actors");
            }

            this.actor = (IActor)movable;
            this.step = movable.GetSpeed();
            Console.WriteLine("move speed");
            Console.WriteLine(this.step);
            this.dx = dx;
            this.dy = dy;
        }
        public void Execute()
        {
            this.step = ((IMovable)(this.actor)).GetSpeed();
            //Console.WriteLine(this.step);
            int oldX = this.actor.GetX();
            int oldY = this.actor.GetY();

            int newX = 0;
            int newY = 0;
            // i dont expect diagonal move commands
            if (this.dx != 0)
            {
                newY = this.actor.GetY();
                this.decimalChange = Math.Abs(dx * (this.step - (int)this.step));
                if (this.decimalChange >= 1)
                {
                    this.decimalChange--;
                    if (this.dx > 0)
                    {
                        newX = this.actor.GetX() + (int)this.step * this.dx + 1;
                    }
                    else if (this.dx < 0)
                    {
                        newX = this.actor.GetX() + (int)this.step * this.dx - 1;
                    }
                }
                else
                {
                    newX = this.actor.GetX() + (int)this.step * this.dx;
                }
            }
            else if (this.dy != 0)
            {
                newX = this.actor.GetX();
                this.decimalChange = Math.Abs(dy * (this.step - (int)this.step));
                if (this.decimalChange >= 1)
                {
                    this.decimalChange--;
                    if (this.dy > 0)
                    {
                        newY = this.actor.GetY() + (int)this.step * dy + 1;
                    }
                    else if (this.dy < 0)
                    {
                        newY = this.actor.GetY() + (int)this.step * dy - 1;
                    }
                }
                else
                {
                    newY = this.actor.GetY() + (int)this.step * dy;
                }
            }

            this.actor.SetPosition(newX, newY);

            if (this.actor.GetWorld().IntersectWithWall(this.actor))
            {
                this.actor.SetPosition(oldX, oldY);
            }
        }
    }
}
