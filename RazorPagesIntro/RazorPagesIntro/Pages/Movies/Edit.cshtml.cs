using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIntro.Data;
using RazorPagesIntro.Exceptions.Movie;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages.Movies {

    public class EditModel : PageModel {

        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly AppDbContext _appDbContext;

        [BindProperty] public Movie Movie { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public EditModel(AppDbContext appDbContext) {
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

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _appDbContext.Attach(Movie).State = EntityState.Modified;

            try {
                await _appDbContext.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                throw new MovieNotFoundException(Movie.Id.ToString());
            }

            return RedirectToPage(PATH_MOVIES);
        }

        #endregion

    }

}
