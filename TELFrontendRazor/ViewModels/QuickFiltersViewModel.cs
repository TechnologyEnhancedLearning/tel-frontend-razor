namespace TELFrontendRazor.ViewModels
{
    using NHSUKFrontendRazor.ViewModels;

    public class QuickFiltersViewModel
    {
        public string? FilterTitle { get; set; }

        public string? Heading { get; set; }

        public bool ShowDefaultTag { get; set; }

        public LinkViewModel? DefaultTag { get; set; }

        public List<LinkViewModel> Tags { get; set; }

        public List<string> ActiveTags { get; set; }
    }
}
