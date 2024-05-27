using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turkey_museum.Models.Domain
{
    public class Museum
    {
        public int Id { get; set; }
        [Required]
        public string? MuseumName { get; set; }
        
        public string? OpenedYear { get; set; }
       
        

        public string? MuseumImage { get; set; }
       
        [Required]
        public int VisitorNumber { get; set; }
        [Required]
        [NotMapped]
       
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int>? Locations { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ? LocationList { get; set; }
        
        [NotMapped]
        public string ? LocationNames {  get; set; }

        public string ? Details { get; set; }

          

        

    }
}
