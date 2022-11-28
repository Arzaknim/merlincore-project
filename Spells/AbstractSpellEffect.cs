using MartinMatta_MerlinCore.Actors;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public abstract class AbstractSpellEffect : ICommand
    {
        private string name;
        protected SpellType type;
        protected AbstractCharacter target;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public void SetTarget(AbstractCharacter target)
        {
            this.target = target;
        }

        public abstract void Execute();
    }
}
