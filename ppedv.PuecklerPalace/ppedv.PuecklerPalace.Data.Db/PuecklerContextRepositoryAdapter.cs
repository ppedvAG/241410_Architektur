using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Data.Db
{
    public class PuecklerContextRepositoryAdapter<T> : IRepository<T> where T : Entity
    {
        protected PuecklerContext _context;

        public PuecklerContextRepositoryAdapter(PuecklerContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
