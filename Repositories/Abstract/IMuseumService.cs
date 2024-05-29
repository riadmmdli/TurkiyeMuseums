
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using TurkiyeMuseums.Models.Domain;
using TurkiyeMuseums.Models.DTO;


namespace TurkiyeMuseums.Repositories.Abstract
{
    public interface IMuseumService
    {

        bool Add(Museum model);

        bool Update(Museum model);

        Museum GetById(int id);    
        bool Delete(int id);

        MuseumListVm List(string term="" , bool paging = false, int currentPage = 0);

        List<int> GetLocationByMuseumId(int museumId);

        


    }
}
