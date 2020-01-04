using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesIntro.Pages
{
    public class PrivacyModel : PageModel
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly ILogger<PrivacyModel> _logger;

        /*------------------------ METHODS REGION ------------------------*/
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