namespace Market
{
    public interface ITriggerable<T>
    {
        public T Component { get;}
        public CustomTrigger CustomTrigger { get; set; }
    }
}
