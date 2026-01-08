// To be uncommented and placed in WebUI/Services/
@*

 namespace LearningHub.Nhs.WebUI.Services
{
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using LearningHub.Nhs.Caching;
    using LearningHub.Nhs.Models.Enums;
    using LearningHub.Nhs.WebUI.Configuration;
    using LearningHub.Nhs.WebUI.Interfaces;
    using Microsoft.Extensions.Options;
    using TELFrontendRazor.Interfaces;
    using TELFrontendRazor.ViewModels;

    /// <summary>
    /// Implementation of the Header Data Provider for the NHS Learning Hub.
    /// Bridges the TELFrontendRazor library with internal Learning Hub services.
    /// </summary>
    public class NhsHeaderDataProvider : IHeaderDataProvider
    {
        private readonly ICacheService cacheService;
        private readonly IInternalSystemService internalSystemService;
        private readonly Settings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="NhsHeaderDataProvider"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="internalSystemService">The internal system service.</param>
        /// <param name="settings">The application settings.</param>
        public NhsHeaderDataProvider(
            ICacheService cacheService,
            IInternalSystemService internalSystemService,
            IOptions<Settings> settings)
        {
            this.cacheService = cacheService;
            this.internalSystemService = internalSystemService;
            this.settings = settings.Value;
        }

        /// <inheritdoc />
        public string SupportFeedbackUrl => this.settings.SupportUrls.SupportFeedbackForm;

        /// <inheritdoc />
        public async Task<bool> IsLoginWizardInProcessAsync(IPrincipal user)
        {
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                return false;
            }

            string userId = null;
            if (user.Identity is ClaimsIdentity claimsIdentity)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? claimsIdentity.FindFirst("sub")?.Value;
            }

            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            var (cacheExists, _) = await this.cacheService.TryGetAsync<string>($"{userId}:LoginWizard");
            return cacheExists;
        }

        /// <inheritdoc />
        public async Task<bool> IsSystemOfflineAsync()
        {
            var internalSystem = await this.internalSystemService.GetByIdAsync((int)InternalSystemType.LearningHub);
            return internalSystem.IsOffline;
        }

        /// <inheritdoc />
        public string GetFormattedOrganisationName(Organisation org)
        {
            return $"{org.Name} {org.Split}";
        }
    }
}
 
 *@