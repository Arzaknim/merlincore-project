using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors.Interfaces
{
    public interface ISpeedStrategy
    {
        double GetSpeed(double speed);
    }
}