using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
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
        protected int cost;
        protected ICharacter target;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public AbstractSpellEffect(int cost)
        {
            this.cost = cost;
        }

        public int GetCost()
        {
            return this.cost;
        }

        public void SetTarget(ICharacter target)
        {
            this.target = target;
        }



        public abstract void Execute();
    }
}
