namespace ppedv.PuecklerPalace.Model
{
    public abstract class EisElement : Entity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Preis { get; set; }
        public bool Vegetarisch { get; set; } = true;
        public bool Vegan { get; set; } = false;
        public virtual ICollection<Zutat> Zutaten { get; set; } = new HashSet<Zutat>();

    }
}
