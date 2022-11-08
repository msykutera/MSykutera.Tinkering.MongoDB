namespace MSykutera.Tinkering.MongoDB.Repostories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAsync(CancellationToken token);

    Task<string> AddAsync(T model, CancellationToken token);

    Task DeleteAsync(string id, CancellationToken token);

    Task UpdateAsync(T model, CancellationToken token);
}