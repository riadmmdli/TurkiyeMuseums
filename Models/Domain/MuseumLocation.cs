using System.ComponentModel.DataAnnotations;

namespace TurkiyeMuseums.Models.Domain
{
    public class MuseumLocation
    {
        public int Id { get; set; }

        public int MuseumId { get; set; }

        public int LocationId { get; set; }

    }
}
