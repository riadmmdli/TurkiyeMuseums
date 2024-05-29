using System.ComponentModel.DataAnnotations;

namespace TurkiyeMuseums.Models.Domain
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string LocationName { get; set; }
    }
}
