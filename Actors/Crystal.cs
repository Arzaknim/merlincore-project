using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace MartinMatta_MerlinCore.Actors
{
    public class Crystal : AbstractSwitchable, ISwitchable, IObserver
    {
        private PowerSource source;

        public Crystal(PowerSource source, int x, int y) : base(x, y)
        {
            this.onAnimation = new Animation("resources/crystal_on.png", 56, 56);
            this.offAnimation = new Animation("resources/crystal_off.png", 56, 56);

            this.UpdateAnimation(this.offAnimation);

            this.AddSource(source);
        }

        protected override void UpdateAnimation(Animation animation)
        {
            this.animation = animation;
            this.SetAnimation(this.animation); //set animation for cauldron
            this.animation.Start();
        }

        public void AddSource(PowerSource source)
        {
            if (source != null)
            {
                this.source = source;
                this.source.Subscribe(this);
                this.isOn = source.IsOn();
                if (this.isOn)
                {
                    this.UpdateAnimation(onAnimation);
                }
                else
                {
                    this.UpdateAnimation(offAnimation);
                }
            }
        }

        public override void Update()
        {
            
        }

        public virtual void Notify(IObservable observable)
        {
            if (((PowerSource)observable).IsOn())
                this.TurnOn();
            else
                this.TurnOff();
        }
    }
}
