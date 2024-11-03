namespace Pallets.Interfaces
{
    public interface IGenerator<T>
    {
        public IEnumerable<T> Generate(int count);
    }
}
