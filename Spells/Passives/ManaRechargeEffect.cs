using MartinMatta_MerlinCore.Spells.Interfaces;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells.Passives
{
    public class ManaRechargeEffect : ICommand
    {
        private IWizard wizard;

        public ManaRechargeEffect(IWizard wizard)
        {
            this.wizard = wizard;
        }

        public void Execute()
        {
            wizard.ChangeMana(5);
        }
    }
}
