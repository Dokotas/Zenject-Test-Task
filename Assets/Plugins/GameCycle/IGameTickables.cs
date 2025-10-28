namespace GameCycle
{
    public interface IGameTickable
    {
        void Tick();
    }

    public interface IGameFixedTickable
    {
        void FixedTick();
    }

    public interface IGameLateTickable
    {
        void LateTick();
    }
}
