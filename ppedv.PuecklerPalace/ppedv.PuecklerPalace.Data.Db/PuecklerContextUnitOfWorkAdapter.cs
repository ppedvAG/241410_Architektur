using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Data.Db
{
    public class PuecklerContextUnitOfWorkAdapter : IUnitOfWork
    {
        private PuecklerContext _context;
        public PuecklerContextUnitOfWorkAdapter(string conString)
        {
            _context = new PuecklerContext(conString);
        }

        public IEisRepository EisRepo => new PuecklerContextEisRepositoryAdapter(_context);

        public IRepository<Topping> ToppingRepo => new PuecklerContextRepositoryAdapter<Topping>(_context);

        public IRepository<Bestellung> BestellRepo => new PuecklerContextRepositoryAdapter<Bestellung>(_context);

        public IRepository<Zutat> ZutatenRepo => new PuecklerContextRepositoryAdapter<Zutat>(_context);

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
