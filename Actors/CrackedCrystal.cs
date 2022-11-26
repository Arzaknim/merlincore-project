namespace MartinMatta_MerlinCore.Actors
{
    public class CrackedCrystal : Crystal
    {
        private int maxUses;
        private int uses;

        public CrackedCrystal(PowerSource source, int x, int y, int maxUses) : base(source, x, y)
        {
            this.maxUses = maxUses;
            this.uses = 0;
        }

        public override void TurnOn()
        {
            if (uses < maxUses)
            {
                uses++;
                base.TurnOn();
            }
        }
    }
}
