using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Model.Contracts.Services
{
    public interface IOrderService
    {
        decimal CalcOrderSum(Bestellung bestellung);
        Eissorte? GetMostOrderdEissorte();
        ProcessOrderResult ProcessOrder(Bestellung bestellung);
    }
}