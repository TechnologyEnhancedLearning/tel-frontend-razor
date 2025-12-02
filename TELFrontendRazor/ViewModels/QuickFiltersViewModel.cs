namespace TELFrontendRazor.ViewModels
{
    public class QuickFiltersViewModel
    {
        public QuickFiltersViewModel(
            List<string> tagNames,
            string myLearningsType,
            string resourcesType,
            string cataloguesType,
            string dashboardTrayLearningResourceType)
        {
            TagNames = tagNames;
            MyLearningsType = myLearningsType;
            ResourcesType = resourcesType;
            CataloguesType = cataloguesType;
            DashboardTrayLearningResourceType = dashboardTrayLearningResourceType;
        }

        public List<string> TagNames { get; set; }

        /// <summary>
        /// Gets or sets a type of my learning items to be displayed in the dashboard.
        /// </summary>
        public string MyLearningsType { get; set; }

        /// <summary>
        /// Gets or sets a type of resources to be displayed in the dashboard.
        /// </summary>
        public string ResourcesType { get; set; }

        /// <summary>
        /// Gets or sets a type of catalogues to be displayed in the dashboard.
        /// </summary
        public string CataloguesType { get; set; }

        /// <summary>
        /// Gets or sets the dashboard tray Learning resource type.
        /// </summary>
        public string DashboardTrayLearningResourceType { get; set; }
    }
}