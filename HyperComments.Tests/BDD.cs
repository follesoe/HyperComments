namespace HyperComments.Tests
{
    public abstract class BDD<T> where T : BDD<T>
    {
        public T Given { get { return (T)this; } }
        public T When { get { return (T)this; } }
        public T Then { get { return (T)this; } }
    }
}
