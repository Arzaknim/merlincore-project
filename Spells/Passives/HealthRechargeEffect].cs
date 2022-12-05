using MartinMatta_MerlinCore.Actors;
using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Passives
{
    public class HealthRechargeEffect : ICommand
    {
        private AbstractCharacter character;

        public HealthRechargeEffect(AbstractCharacter character)
        {
            this.character = character;
        }

        public void Execute()
        {
            character.ChangeHealth(1);
        }
    }
}
