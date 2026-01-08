using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TELFrontendRazor.Interfaces;
using TELFrontendRazor.ViewModels;
using NHSUKFrontendRazor.ViewModels;

namespace TELFrontendRazor.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHeaderDataProvider _dataProvider;

        public HeaderViewComponent(IHeaderDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            Organisation organisationDetails,
            bool? isService = true,
            AccountLinks? accountLinks = null,
            Dictionary<string, string>? theme = null,
            string? mobileNavFolder = null,
            string? mobileNavView = null,
            string? notificationFolder = null,
            string? notificationNavView = null,
            string? searchFolder = null,
            string? searchNavView = null,
            string? searchControllerName = null,
            string? topNavFolder = null,
            string? topNavView = null,
            string? navigationFolder = null,
            string? navigationView = null,
            LinkViewModel? searchLink = null)
        {
            // Get Context
            var currentController = ViewContext.RouteData.Values["controller"]?.ToString()?.ToLower() ?? "";
            bool isAuth = User.Identity != null && User.Identity.IsAuthenticated;

            // Fetch Data via Interface
            bool loginWizardInProcess = false;
            bool systemOffline = false;

            if (isAuth)
            {
                loginWizardInProcess = await _dataProvider.IsLoginWizardInProcessAsync(User);
                if (currentController != "offline")
                {
                    systemOffline = await _dataProvider.IsSystemOfflineAsync();
                }
            }

            theme ??= HeaderTheme.BLUE;
            accountLinks ??= new AccountLinks(
                new LinkViewModel("myaccount", null, "My account", null),
                new LinkViewModel("Home", "Logout", "Log out", null),
                null);

            var model = new HeaderViewModel(
                organisationDetails, isService, accountLinks, theme,
                mobileNavFolder, mobileNavView, notificationFolder, notificationNavView,
                searchFolder, searchNavView, searchControllerName,
                topNavFolder, topNavView, navigationFolder, navigationView, searchLink)
            {
                LoginWizardInProcess = loginWizardInProcess,
                SystemOffline = systemOffline,
                SupportFeedbackUrl = _dataProvider.SupportFeedbackUrl,
                CurrentController = currentController,
                IsUserAuthenticated = isAuth,
                IsReadOnlyOrBasicUser = User.IsInRole("ReadOnly") || User.IsInRole("BasicUser")
            };

            return View(model);
        }
    }
}
