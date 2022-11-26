using MartinMatta_MerlinCore.Actors.Interfaces;

namespace MartinMatta_MerlinCore.Actors
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);

        double GetSpeed();
    }
}
