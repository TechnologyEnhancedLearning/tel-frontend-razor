namespace TELFrontendRazor.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using NHSUKFrontendRazor.ViewModels;
    using TELFrontendRazor.ViewModels;

    /// <summary>
    /// A ViewComponent that renders a tag based on the provided name and styling.
    /// </summary>
    public class QuickFiltersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(
            string? filterTitle = null,
            string? heading = null,
            LinkViewModel? defaultTag = null,
            List<LinkViewModel>? tags = null,
            List<string>? activeTags = null,
            bool showDefaultTag = true)
        {
            defaultTag ??= new LinkViewModel("All", "#");

            var model = new QuickFiltersViewModel
            {
                FilterTitle = filterTitle,
                Heading = heading,
                ShowDefaultTag = showDefaultTag,
                DefaultTag = defaultTag,
                Tags = tags,
                ActiveTags = activeTags
            };

            return View(model);
        }
    }
}
