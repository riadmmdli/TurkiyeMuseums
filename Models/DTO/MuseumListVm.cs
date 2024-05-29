using TurkiyeMuseums.Models.Domain;

namespace TurkiyeMuseums.Models.DTO
{
    public class MuseumListVm
    {
        public IQueryable<Museum> MuseumList { get; set; }
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string? Term { get; set; }
    }
}
