using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Commands;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Commands
{
    public class Jump<T> : IAction<T> where T : IActor
    {
        private IActor actor;

        private Move moveUp;
        private int step;

        public Jump(IMovable movable, int step)
        {
            if (!(movable is IActor))
            {
                throw new ArgumentException("Argument object movable is not implemented by IActor.");
            }
            this.actor = (IActor)movable;
            this.step = step;
            this.moveUp = new Move(movable, 0, -1);
            int meow = (int)movable.GetSpeed();
        }

        public void Execute(T value)
        {
            for (int i = 0; i < Math.Ceiling(step/(((IMovable)value).GetSpeed())); i++)
            {
                this.moveUp.Execute();
            }
        }
    }
}
