using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesIntro.Pages
{
    public class PrivacyModel : PageModel
    {
        #region Properties

        private readonly ILogger<PrivacyModel> _logger;

        #endregion

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        #region HttpMethods

        public void OnGet()
        {
        }

        #endregion
    }
}