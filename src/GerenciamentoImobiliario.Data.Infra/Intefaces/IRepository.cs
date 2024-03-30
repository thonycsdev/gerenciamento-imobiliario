namespace GerenciamentoImobiliario.Data.Infra.Interfaces
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GellAll();
        Task Delete(Guid id);
        Task<T> Update(T entity);
    }
}
