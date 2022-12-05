using MartinMatta_MerlinCore.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Factories
{
    public class PotionFactory
    {
        public Jar CreatePotion(PotionType type)
        {
            if(type == PotionType.HEALTH)
            {
                return new HealingPotion(30);
            }
            else if (type == PotionType.MANA)
            {
                return new ManaPotion(30);
            }
            return null;
        }
    }
}
