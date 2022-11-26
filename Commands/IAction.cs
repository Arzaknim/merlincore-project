namespace MartinMatta_MerlinCore.Commands
{
    public interface IAction<T>
    {
        public void Execute(T value);
    }
}
