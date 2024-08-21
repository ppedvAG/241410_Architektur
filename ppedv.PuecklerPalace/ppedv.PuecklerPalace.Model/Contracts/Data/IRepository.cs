using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Model.Contracts.Data
{

    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        T? Get(int id);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
