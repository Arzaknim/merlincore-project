using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public interface IObservable
    {
        public void Subscribe(IObserver observer);

        public void Unsubscribe(IObserver observer);
    }
}
