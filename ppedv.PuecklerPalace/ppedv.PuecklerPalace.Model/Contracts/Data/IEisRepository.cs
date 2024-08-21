using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Model.Contracts.Data
{
    public interface IEisRepository : IRepository<Eissorte>
    {
        void EatAllEis();
    }
}
