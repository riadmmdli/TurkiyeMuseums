using System.ComponentModel.DataAnnotations;

namespace turkey_museum.Models.Domain
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string LocationName { get; set; }
    }
}
