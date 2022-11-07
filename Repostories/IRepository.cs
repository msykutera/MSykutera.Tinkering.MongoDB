namespace MSykutera.Tinkering.MongoDB.Repostories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(CancellationToken token);

        Task<string> AddAsync(T model, CancellationToken token);
    }
}
