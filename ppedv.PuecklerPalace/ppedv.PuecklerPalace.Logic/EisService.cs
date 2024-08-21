using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.Contracts.Services;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Logic
{
    public class EisService : IEisService
    {
        private readonly IRepository repo;

        public EisService(IRepository repo)
        {
            this.repo = repo;
        }

        public bool IsEisAvailable(Eissorte eis)
        {
            return repo.GetAll<Eissorte>().Any(x => x.Name == eis.Name);
        }
    }
}
