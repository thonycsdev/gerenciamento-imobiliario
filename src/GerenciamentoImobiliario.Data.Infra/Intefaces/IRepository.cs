namespace GerenciamentoImobiliario.Data.Infra.Interfaces
{
    public interface IRepository<T>
    {
       Task Create(T entity); 
    }
}
