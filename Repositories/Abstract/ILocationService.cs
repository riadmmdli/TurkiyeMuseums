
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using TurkiyeMuseums.Models.Domain;
using TurkiyeMuseums.Models.DTO;


namespace TurkiyeMuseums.Repositories.Abstract
{
    public interface ILocationService
    {

        bool Add(Location model);

        bool Update(Location model);

        Location GetById(int id);    
        bool Delete(int id);

        IQueryable<Location> List();
        
    }
}
