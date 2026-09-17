namespace TELFrontendRazor.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using TELFrontendRazor.ViewModels;

    /// <summary>
    /// A ViewComponent that renders a card component.
    /// </summary>
    public class SideNavViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(
            SideNavViewModel? model = null, List<NavigationItemViewModel>? items = null)
        {
            var viewModel = model ?? new SideNavViewModel
            {
                Items = items ?? new List<NavigationItemViewModel>()
            };

            return View(viewModel);
        }
    }
}
