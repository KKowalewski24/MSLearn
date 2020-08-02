using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesIntro.Data;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages.Movies {

    public class DetailsModel : PageModel {

        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly AppDbContext _appDbContext;

        [BindProperty] public Movie Movie { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public DetailsModel(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        #region HttpMethods

        public async Task<IActionResult> OnGetAsync(int id) {
            Movie = await _appDbContext.Movies.FindAsync(id);

            if (Movie != null) {
                return Page();
            }

            return RedirectToPage(PATH_MOVIES);
        }

        #endregion

    }

}
