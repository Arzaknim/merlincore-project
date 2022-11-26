using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public interface ISwitchable
    {
        public void Toggle();
        public void TurnOn();
        public void TurnOff();
        public bool IsOn();
    }
}
