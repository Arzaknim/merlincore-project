using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class ProjectileSpell : AbstractActor, IMovable, ISpell
    {

        private int speed;
        private Move forward;
        private AbstractCharacter caster;

        public ProjectileSpell(AbstractCharacter caster, int speed)
        {
            this.caster = caster;
            this.speed = speed;
        }

        public ISpell AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            throw new NotImplementedException();
        }

        public void ApplyEffects(ICharacter target)
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }

        public double GetSpeed()
        {
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
