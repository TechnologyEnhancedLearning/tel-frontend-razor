using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;

namespace TELFrontendRazor.Helpers
{
    public class NHSUKFrontendRazorComponentFilter : IApplicationFeatureProvider<ViewComponentFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ViewComponentFeature feature)
        {

            // ViewComponents to KEEP
            var allowedComponents = new HashSet<string> { "Link" };

            // Find all ViewComponents aside from the allowed one
            var componentsToRemove = feature.ViewComponents
            .Where(vc => vc.Namespace != null && vc.Namespace.StartsWith("NHSUKFrontendRazor"))
            .Where(vc => !allowedComponents.Contains(vc.Name))
            .ToList();


            // Remove them
            foreach (var component in componentsToRemove)
            {
                feature.ViewComponents.Remove(component);
            }
        }
    }
}
