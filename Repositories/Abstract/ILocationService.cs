
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using turkey_museum.Models.Domain;
using turkey_museum.Models.DTO;


namespace turkey_museum.Repositories.Abstract
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
