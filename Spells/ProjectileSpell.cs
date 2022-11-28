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
        private ActorOrientation initialOrientation;
        private IEnumerable<ICommand> effects;

        private int spellRange;
        private int distanceTravelled;
        private bool hitATarget;
        private int lastX;

        public ProjectileSpell(AbstractCharacter caster, int speed, int range, IEnumerable<ICommand> effects)
        {
            this.caster = caster;
            int casterFrontX = this.caster.GetX() + this.caster.GetAnimation().GetWidth();
            int casterMiddleY = this.caster.GetY() + this.caster.GetAnimation().GetHeight() / 2;
            this.SetPosition(casterFrontX, casterMiddleY);
            this.speed = speed;
            this.normalSpeedStrategy = new NormalSpeedStrategy();
            this.initialOrientation = this.caster.GetOrientation();
            if (this.initialOrientation == ActorOrientation.RIGHT)
                this.forward = new Move(this, 1, 0);
            else
                this.forward = new Move(this, -1, 0);
            this.spellRange = range;
            this.distanceTravelled = 0;
            this.hitATarget = false;
            this.lastX = 0;
            this.effects = new List<ICommand>();
            this.AddEffects(effects);
        }

        public ISpell AddEffect(ICommand effect)
        {
            ((List<ICommand>)this.effects).Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            foreach (ICommand effectItem in effects)
            {
                ((List<ICommand>)this.effects).Add(effectItem);
            }
        }

        public void ApplyEffects(ICharacter target)
        {
            foreach(ICommand effectItem in this.effects)
            {
                ((SpellEffect)effectItem).SetTarget((AbstractCharacter)target);
                effectItem.Execute();
            }
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
            if (!this.hitATarget && this.lastX != this.GetX() )
            {
                this.lastX = this.GetX();
                if (this.distanceTravelled < this.spellRange)
                {
                    this.distanceTravelled += (int)this.GetSpeed();
                    this.forward.Execute();
                }
                List<IActor> enemies = this.GetWorld().GetActors().FindAll(x => x.GetName() == "Spooky Scary Skeleton");
                foreach (IActor enemyItem in enemies)
                {
                    if (this.IntersectsWithActor(enemyItem))
                    {
                        this.hitATarget = true;
                        //((AbstractCharacter)enemyItem).ChangeHealth(-25);
                        this.ApplyEffects((AbstractCharacter)enemyItem);
                    }
                }
            }
            else
            {
                this.RemoveFromWorld();
            }
        }
    }
}
