namespace Colegio.Infraestructura.Colegio.Repositorios
{
    public interface ICrudRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> DeleteById(int id);
    }
}
