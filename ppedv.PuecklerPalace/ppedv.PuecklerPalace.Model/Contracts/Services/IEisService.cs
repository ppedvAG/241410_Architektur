using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Model.Contracts.Services
{
    public interface IEisService
    {
        bool IsEisAvailable(Eissorte eis);
    }
}