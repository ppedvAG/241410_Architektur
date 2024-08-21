using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Model.Contracts.Data
{
    public interface IUnitOfWork
    {
        public IEisRepository EisRepo { get; }
        public IRepository<Topping> ToppingRepo { get; }
        public IRepository<Bestellung> BestellRepo { get; }
        public IRepository<Zutat> ZutatenRepo { get; }

        int Save();
    }
}
