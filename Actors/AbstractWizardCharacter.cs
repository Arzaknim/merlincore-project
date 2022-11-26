using MartinMatta_MerlinCore.Spells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public abstract class AbstractWizardCharacter : AbstractCharacter, IWizard
    {
        private int mana;

        public AbstractWizardCharacter()
        {
            mana = 100;
        }

        public void Cast(ISpell spell)
        {
            throw new NotImplementedException();
        }

        public void ChangeMana(int delta)
        {
            this.mana += delta;
            if (this.mana < 0)
                this.mana = 0;
            else if (this.mana > 100)
                this.mana = 100;
        }

        public int GetMana()
        {
            return this.mana;
        }
    }
}
