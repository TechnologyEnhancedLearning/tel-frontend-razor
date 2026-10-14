using Microsoft.AspNetCore.Html;

namespace TELFrontendRazor.ViewModels
{
    public class SideNavViewModel
    {
        public List<NavigationItemViewModel> Items { get; set; } = new();
    }

    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(string title, string? url = null, IEnumerable<NavStatus>? statuses = null,
            bool isLocked = false, bool isActive = false, bool isExpanded = false, List<NavigationItemViewModel>? children = null)
        {
            Title = title;
            Url = url;
            Statuses = statuses?.Where(status => status != NavStatus.None).Take(2).ToList() ?? new List<NavStatus>();
            IsLocked = isLocked;
            IsActive = isActive;
            IsExpanded = isExpanded;
            Children = children;
        }

        public string? Id { get; set; }
        public string Title { get; set; }
        public string? Url { get; set; }
        public List<NavStatus> Statuses { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpanded { get; set; }
        public List<NavigationItemViewModel>? Children { get; set; }
    }

    public enum NavStatus
    {
        None,
        Unstarted,
        Complete,
        Locked
    }
}