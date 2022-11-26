using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace MartinMatta_MerlinCore.Actors
{
    public abstract class AbstractSwitchable : AbstractActor, ISwitchable
    {
        protected bool isOn = false;
        protected Animation animation;
        protected Animation onAnimation;
        protected Animation offAnimation;

        protected AbstractSwitchable(int x, int y)
        {
            this.SetPosition(x, y);
        }

        protected abstract void UpdateAnimation(Animation animation);

        public bool IsOn()
        {
            return this.isOn;
        }

        public virtual void Toggle()
        {
            this.isOn = !this.isOn;

            if (this.isOn)
            {
                this.animation = this.onAnimation;
                this.SetAnimation(this.animation);
                this.animation.Start();
            }
            else
            {
                this.animation = this.offAnimation;
                this.SetAnimation(this.animation);
                this.animation.Start();
            }
        }

        public void TurnOff()
        {
            if (this.isOn)
                this.Toggle();
        }

        public virtual void TurnOn()
        {
            if (!this.isOn)
                this.Toggle();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
