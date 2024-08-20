namespace ppedv.PuecklerPalace.Model.DomainModel
{
    public abstract class EisElement : Entity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Preis { get; set; }
        public bool Vegetarisch { get; set; } = true;
        public bool Vegan { get; set; } = false;
        public virtual ICollection<Zutat> Zutaten { get; set; } = new HashSet<Zutat>();
        public virtual ICollection<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();

    }
}
