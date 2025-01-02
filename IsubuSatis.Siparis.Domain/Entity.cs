namespace IsubuSatis.Siparis.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }

    public interface IFullEntity<T>
    {

    }
}
