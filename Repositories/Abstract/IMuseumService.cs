
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using turkey_museum.Models.Domain;
using turkey_museum.Models.DTO;


namespace turkey_museum.Repositories.Abstract
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
