namespace ppedv.PuecklerPalace.Model.DomainModel
{
    public class Bestellung : Entity
    {
        public string Kunde { get; set; } = string.Empty;
        public DateTime BestellDatum { get; set; }
        public virtual ICollection<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();
    }
}
