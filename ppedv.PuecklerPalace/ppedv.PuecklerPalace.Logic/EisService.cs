using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.Contracts.Services;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Logic
{
    public class EisService : IEisService
    {
        private readonly IUnitOfWork unitOfWork;

        public EisService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool IsEisAvailable(Eissorte eis)
        {
            return unitOfWork.EisRepo.GetAll().Any(x => x.Name == eis.Name);
        }
    }
}
