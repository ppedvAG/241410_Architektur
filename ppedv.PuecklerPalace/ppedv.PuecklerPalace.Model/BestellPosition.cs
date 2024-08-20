namespace ppedv.PuecklerPalace.Model
{
    public class BestellPosition : Entity
    {
        public virtual required Bestellung Bestellung { get; set; }
        public virtual ICollection<Topping> Toppings { get; set; } = new List<Topping>();
        public virtual ICollection<Eissorte> Eissorten { get; set; } = new List<Eissorte>();
    }
}
