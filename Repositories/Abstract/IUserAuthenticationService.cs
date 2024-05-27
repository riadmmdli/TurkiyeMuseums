using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using turkey_museum.Models.DTO;

namespace turkey_museum.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {

        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
        
    }
}
