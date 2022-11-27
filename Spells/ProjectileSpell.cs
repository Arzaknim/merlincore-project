using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
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
        private NormalSpeedStrategy normalSpeedStrategy;
        private SpellInfo info;

        private int spellRange;
        private int distanceTravelled;

        public ProjectileSpell(AbstractCharacter caster, int speed, int range)
        {
            this.caster = caster;
            int casterFrontX = this.caster.GetX() + this.caster.GetAnimation().GetWidth();
            int casterMiddleY = this.caster.GetY() + this.caster.GetAnimation().GetHeight() / 2;
            this.SetPosition(casterFrontX, casterMiddleY);
            this.speed = speed;
            this.normalSpeedStrategy = new NormalSpeedStrategy();
            if(this.caster.GetOrientation() == ActorOrientation.RIGHT)
                this.forward = new Move(this, 1, 0);
            else
                this.forward = new Move(this, -1, 0);
            this.spellRange = range;
            this.distanceTravelled = 0;

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
            return this.normalSpeedStrategy.GetSpeed(this.speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
        }

        public override void Update()
        {
            if(this.distanceTravelled < this.spellRange)
            {
                this.distanceTravelled += 2;
                this.SetPosition(this.GetX(), this.GetY() + this.distanceTravelled);
            }
            else
            {
                this.RemoveFromWorld();
            }
            List<IActor> enemies = this.GetWorld().GetActors().FindAll(x => x.GetName() == "Spooky Scary Skeleton");
            foreach (IActor enemyItem in enemies)
            {
                if (this.IntersectsWithActor(enemyItem))
                {
                    ((AbstractCharacter)enemyItem).ChangeHealth(-25);

                }
            }
        }
    }
}
