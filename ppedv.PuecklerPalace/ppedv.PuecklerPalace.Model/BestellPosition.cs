using System.Runtime;

namespace ppedv.PuecklerPalace.Model
{
    public class BestellPosition : Entity
    {
        public virtual required Bestellung Bestellung { get; set; }

        public int Amount { get; set; }
        public virtual required EisElement Element { get; set; }
    }
}
