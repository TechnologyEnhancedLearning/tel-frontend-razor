using NHSUKFrontendRazor.ViewModels;
using System.Collections.Generic;

namespace TELFrontendRazor.ViewModels
{
    public class HeaderViewModel
    {
        public HeaderViewModel(
            Organisation organisationDetails,
            bool? isService,
            AccountLinks? accountLinks,
            Dictionary<string, string>? theme,
            string? mobileNavFolder,
            string? mobileNavView,
            string? notificationFolder,
            string? notificationNavView,
            string? searchFolder,
            string? searchNavView,
            string? searchControllerName,
            string? topNavFolder,
            string? topNavView,
            string? navigationFolder,
            string? navigationView,
            LinkViewModel? searchLink)
        {
            OrganisationDetails = organisationDetails;
            IsService = isService;
            AccountLinks = accountLinks;
            Theme = theme;
            MobileNavFolder = mobileNavFolder;
            MobileNavView = mobileNavView;
            NotificationFolder = notificationFolder;
            NotificationNavView = notificationNavView;
            SearchFolder = searchFolder;
            SearchNavView = searchNavView;
            SearchControllerName = searchControllerName;
            TopNavFolder = topNavFolder;
            TopNavView = topNavView;
            NavigationFolder = navigationFolder;
            NavigationView = navigationView;
            SearchLink = searchLink;
        }

        public Organisation OrganisationDetails { get; set; }

        public bool? IsService { get; set; }

        public AccountLinks? AccountLinks { get; set; }

        public Dictionary<string, string> Theme { get; set; }

        public string? MobileNavFolder { get; set; }

        public string? MobileNavView { get; set; }

        public string? NotificationFolder { get; set; }

        public string? NotificationNavView { get; set; }

        public string? SearchFolder { get; set; }

        public string? SearchNavView { get; set; }

        public string? SearchControllerName { get; set; }

        public string? TopNavFolder { get; set; }

        public string? TopNavView { get; set; }

        public string? NavigationFolder { get; set; }

        public string? NavigationView { get; set; }

        public LinkViewModel? SearchLink { get; set; }

        public bool LoginWizardInProcess { get; set; }

        public bool SystemOffline { get; set; }

        public string SupportFeedbackUrl { get; set; } = "#";

        public string CurrentController { get; set; } = "";

        public bool IsUserAuthenticated { get; set; }

        public bool IsReadOnlyOrBasicUser { get; set; }

        // --- VIEW HELPERS
        public string PreLoginClass => !IsUserAuthenticated ? "nhsuk-header__pre-login" : "";
        public string BasicUserPaddingClass => IsReadOnlyOrBasicUser ? "nhsuk-u-padding-right-4" : "";
        public bool HideSearchBar => !IsUserAuthenticated || CurrentController == "mylearning";
    }

    public static class HeaderTheme
    {
        public static Dictionary<string, string> BLUE = new Dictionary<string, string> { { "header", "nhsuk-header" }, { "navigation", "nhsuk-header__navigation" } };
        public static Dictionary<string, string> WHITE = new Dictionary<string, string> { { "header", "nhsuk-header nhsuk-header--white" }, { "navigation", "nhsuk-header__navigation nhsuk-header__navigation--white" } };
        public static Dictionary<string, string> MIXED = new Dictionary<string, string> { { "header", "nhsuk-header nhsuk-header--white" }, { "navigation", "nhsuk-header__navigation" } };
    }

    public class Organisation
    {
        public Organisation(string name, string split, string descriptor)
        {
            Name = name;
            Split = split;
            Descriptor = descriptor;
        }
        public string? Name { get; set; }
        public string? Split { get; set; }
        public string? Descriptor { get; set; }
    }

    public class AccountLinks
    {
        public AccountLinks(LinkViewModel account, LinkViewModel logout, List<LinkViewModel>? additionalLinks)
        {
            Account = account;
            Logout = logout;
            AdditionalLinks = additionalLinks;
        }
        public LinkViewModel Account { get; set; }
        public LinkViewModel Logout { get; set; }
        public List<LinkViewModel>? AdditionalLinks { get; set; }
    }
}
