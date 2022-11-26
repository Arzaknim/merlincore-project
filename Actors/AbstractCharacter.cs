using MartinMatta_MerlinCore.Actors.Interfaces;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        protected ISpeedStrategy strategy;
        protected double speed;
        private int health;

        public AbstractCharacter()
        {
            this.health = 100;
        }

        public void ChangeHealth(int delta)
        {
            this.health += delta;
            if(this.health < 0)
                this.health = 0;
            else if (this.health > 100)
                this.health = 100;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public void Die()
        {
            this.RemoveFromWorld();
        }

        public void AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.strategy = strategy;
        }

        public ISpeedStrategy GetStrategy()
        {
            return this.strategy;
        }

        public double GetSpeed()
        {
            return this.strategy.GetSpeed(this.speed);
        }
    }
}
