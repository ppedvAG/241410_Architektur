using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Data.Db
{
    public class PuecklerContextEisRepositoryAdapter : PuecklerContextRepositoryAdapter<Eissorte>, IEisRepository
    {
        public PuecklerContextEisRepositoryAdapter(PuecklerContext context) : base(context)
        { }

        public void EatAllEis()
        {
            foreach (var item in _context.Eissorten)
            {
                //todo eat
            }
        }
    }
}
