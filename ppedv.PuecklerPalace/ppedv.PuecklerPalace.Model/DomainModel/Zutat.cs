namespace ppedv.PuecklerPalace.Model.DomainModel
{
    public class Zutat : Entity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<EisElement> Elemente { get; set; } = new HashSet<EisElement>();
    }
}
