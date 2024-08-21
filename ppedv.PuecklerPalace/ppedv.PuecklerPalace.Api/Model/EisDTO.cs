namespace ppedv.PuecklerPalace.Api.Model
{
    public class EisDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public bool Vegetarisch { get; set; } = true;
        public bool Vegan { get; set; } = false;
    }
}
