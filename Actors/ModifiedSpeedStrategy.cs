using MartinMatta_MerlinCore.Actors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        public double GetSpeed(double speed) => speed * 0.5;
    }
}
