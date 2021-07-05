using System;
using System.Collections.Generic;
using System.Text;
using ACT.Localization;
using Volo.Abp.Application.Services;

namespace ACT
{
    /* Inherit your application services from this class.
     */
    public abstract class ACTAppService : ApplicationService
    {
        protected ACTAppService()
        {
            LocalizationResource = typeof(ACTResource);
        }
    }
}
