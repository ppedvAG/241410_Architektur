using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Api.Model
{
    public static class EisMapper
    {
        // Mappt ein Eissorte-Objekt auf ein EisDTO-Objekt
        public static EisDTO ToEisDTO(Eissorte eissorte)
        {
            return new EisDTO
            {
                Id = eissorte.Id,          // Falls Id in Entity definiert ist
                Name = eissorte.Name,
                Preis = eissorte.Preis,
                Vegetarisch = eissorte.Vegetarisch,
                Vegan = eissorte.Vegan
            };
        }

        // Mappt eine Liste von Eissorte-Objekten auf eine Liste von EisDTO-Objekten
        public static IEnumerable<EisDTO> ToEisDTOList(IEnumerable<Eissorte> eissorten)
        {
            return eissorten.Select(eissorte => ToEisDTO(eissorte)).ToList();
        }

        // Mappt ein EisDTO-Objekt auf ein Eissorte-Objekt
        public static Eissorte ToEissorte(EisDTO eisDTO)
        {
            return new Eissorte
            {
                Id = eisDTO.Id,            // Falls Id in Entity definiert ist
                Name = eisDTO.Name,
                Preis = eisDTO.Preis,
                Vegetarisch = eisDTO.Vegetarisch,
                Vegan = eisDTO.Vegan,
                // Hier können Sie die Standardwerte für andere Eigenschaften setzen, falls erforderlich
            };
        }

        // Mappt eine Liste von EisDTO-Objekten auf eine Liste von Eissorte-Objekten
        public static IEnumerable<Eissorte> ToEissorteList(IEnumerable<EisDTO> eisDTOs)
        {
            return eisDTOs.Select(eisDTO => ToEissorte(eisDTO)).ToList();
        }
    }

}
