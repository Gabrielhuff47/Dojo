namespace Dojo.DAO.BaseRepository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetEntityAsync(int id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task AddAsync(TEntity entity);

    Task UdateAsync(TEntity entity);

    Task DeleteAsync(int id);
}
