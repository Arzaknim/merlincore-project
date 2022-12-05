using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Factories;
using MartinMatta_MerlinCore.Items;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class AbstractPotionStation : AbstractActor, IStation
    {
        private PotionFactory factory;
        protected PotionType type;

        public AbstractPotionStation()
        {
            this.factory = new PotionFactory();
        }

        public Jar FillPotion()
        {
            return this.factory.CreatePotion(this.type);
        }

        public override void Update()
        {
        }

        public void Use(IActor actor)
        {
            Backpack inventory = ((actor as Player).GetInvetory() as Backpack);
            IItem item = inventory.GetItem();
            if (item != null && item is Jar && item is not ManaPotion && item is not HealingPotion)
            {
                inventory.ReplaceItemAtIndex(0, this.FillPotion());
            }
        }
    }
}
