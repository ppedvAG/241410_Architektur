using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.Contracts.Services;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Logic
{
    public  class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEisService _eisService;

        public OrderService(IUnitOfWork unitOfWork, IEisService eisService)
        {
            this.unitOfWork = unitOfWork;
            _eisService = eisService;
        }

        public ProcessOrderResult ProcessOrder(Bestellung bestellung)
        {
            var result = new ProcessOrderResult()
            {
                Sum = CalcOrderSum(bestellung),
                Ok = bestellung.Positionen.Select(x => x.Element).OfType<Eissorte>().All(x => _eisService.IsEisAvailable(x))
            };
            return result;
        }

        public decimal CalcOrderSum(Bestellung bestellung)
        {
            ArgumentNullException.ThrowIfNull(bestellung);

            return bestellung.Positionen.Sum(x => x.Amount * x.Element.Preis);
        }

        public Eissorte? GetMostOrderdEissorte()
        {
            return unitOfWork.EisRepo.GetAll()
                        .OrderByDescending(x => x.Positionen.Count())
                        .FirstOrDefault();
        }
    }
}
