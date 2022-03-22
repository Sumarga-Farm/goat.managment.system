using GoatFarm.Management.Domain.MediaManagement;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string? GetGoatPictureUrl(this IUrlHelper urlHelper, PictureId pictureId) {
            return urlHelper.ActionLink(controller: "Pictures",
                                                  action: "Get",
                                                  values: new { pictureId = pictureId.Value },
                                                  protocol: urlHelper.ActionContext.HttpContext.Request.Scheme);
        }
    }
}
