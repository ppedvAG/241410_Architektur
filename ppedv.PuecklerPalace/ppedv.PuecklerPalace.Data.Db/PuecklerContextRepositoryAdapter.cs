using ppedv.PuecklerPalace.Model.Contracts;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Data.Db
{
    public class PuecklerContextRepositoryAdapter : IRepository
    {
        private PuecklerContext _context;

        public PuecklerContextRepositoryAdapter(string conString)
        {
            _context = new PuecklerContext(conString);
        }

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Eissorte))
                //_context.Eissorten.Add(entity as Eissorte);
                    
            _context.Add(entity);
        }


        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public T? Get<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}
