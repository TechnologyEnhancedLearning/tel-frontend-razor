using System.Security.Principal;
using System.Threading.Tasks;
using TELFrontendRazor.ViewModels;

namespace TELFrontendRazor.Interfaces
{
    public interface IHeaderDataProvider
    {
        Task<bool> IsLoginWizardInProcessAsync(IPrincipal user);
        Task<bool> IsSystemOfflineAsync();
        string SupportFeedbackUrl { get; }
        string GetFormattedOrganisationName(Organisation org);
    }
}
