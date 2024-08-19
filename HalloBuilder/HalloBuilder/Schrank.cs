namespace HalloBuilder
{
    internal class Schrank
    {
        private Schrank()
        { }


        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public string Farbe { get; private set; }
        public Oberfläche Oberfläche { get; private set; }

        internal class Builder
        {
            public Builder(string farbe)
            {
                
            }
            Schrank schrank = new Schrank();
            public Schrank Create()
            {
                return schrank;
            }

            public Builder SetAnzTüren(int anzahl)
            {
                if (anzahl < 2 || anzahl > 7)
                    throw new ArgumentException("Zuviele oder zu wenig Türen, nur 2-7 erlaubt");

                schrank.AnzahlTüren = anzahl;

                return this;
            }

            public Builder SetAnzBöden(int anzahl)
            {
                if (anzahl < 0 || anzahl > 20)
                    throw new ArgumentException("Zuviele oder zu wenig Böden, nur 2-7 erlaubt");

                schrank.AnzahlBöden = anzahl;

                return this;
            }



        }
    }
    public enum Oberfläche
    {
        Natur,
        Lackiert
    }
}