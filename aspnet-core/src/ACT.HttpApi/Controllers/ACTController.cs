using ACT.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ACT.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ACTController : AbpController
    {
        protected ACTController()
        {
            LocalizationResource = typeof(ACTResource);
        }
    }
}