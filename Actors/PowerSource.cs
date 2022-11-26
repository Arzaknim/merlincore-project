using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class PowerSource : AbstractSwitchable, ISwitchable, IObservable
    {
        private List<IObserver> observers;

        public PowerSource(int x, int y) : base(x, y)
        {
            this.onAnimation = new Animation("resources/source_on.png", 56, 60);
            this.offAnimation = new Animation("resources/source_off.png", 56, 60);

            this.UpdateAnimation(offAnimation);

            this.observers = new List<IObserver>();
        }

        protected override void UpdateAnimation(Animation animation)
        {
            this.animation = animation;
            this.SetAnimation(this.animation); //set animation for cauldron
            this.animation.Start();
        }

        public override void Update()
        {
            if (Input.GetInstance().IsKeyPressed(Input.Key.E))
                this.Toggle();
        }

        public override void Toggle()
        {
            base.Toggle();

            foreach (IObserver observer in observers)
            {
                observer.Notify(this);
            }
        }

        public void Subscribe(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            if (this.observers.Contains(observer))
                this.observers.Remove(observer);
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
            this.UpdateAnimation(this.animation);
        }
    }
}
