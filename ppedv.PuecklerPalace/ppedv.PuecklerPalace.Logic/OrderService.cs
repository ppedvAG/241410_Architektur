using ppedv.PuecklerPalace.Data.Db;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Logic
{
    public class OrderService
    {

        public decimal CalcOrderSumm(Bestellung bestellung)
        {
            ArgumentNullException.ThrowIfNull(bestellung);

            return bestellung.Positionen.Sum(x => x.Amount * x.Element.Preis);
        }

        public Eissorte GetMostOrderdEissorte()
        {
            //bäh
            //var con = new PuecklerContext("AAA");
            //return  con.Eissorten.OrderBy(x => x.Positionen.Count()).FirstOrDefault();

            throw new NotImplementedException();
        }

    }
}
