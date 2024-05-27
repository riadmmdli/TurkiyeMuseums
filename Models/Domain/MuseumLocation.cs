using System.ComponentModel.DataAnnotations;

namespace turkey_museum.Models.Domain
{
    public class MuseumLocation
    {
        public int Id { get; set; }

        public int MuseumId { get; set; }

        public int LocationId { get; set; }

    }
}
