using ppedv.PuecklerPalace.Model.Contracts;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Logic
{
    public class OrderService
    {
        private IRepository _repo;

        public OrderService(IRepository repo)
        {
            _repo = repo;
        }

        public decimal CalcOrderSumm(Bestellung bestellung)
        {
            ArgumentNullException.ThrowIfNull(bestellung);

            return bestellung.Positionen.Sum(x => x.Amount * x.Element.Preis);
        }

        public Eissorte? GetMostOrderdEissorte()
        {
            return _repo.GetAll<Eissorte>().OrderBy(x => x.Positionen.Count()).FirstOrDefault();
        }

    }
}
