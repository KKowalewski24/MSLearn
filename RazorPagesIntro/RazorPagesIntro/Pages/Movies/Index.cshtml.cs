using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIntro.Data;
using RazorPagesIntro.Models;

namespace RazorPagesIntro.Pages.Movies
{
    public class IndexModel : PageModel
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly AppDbContext _appDbContext;

        [BindProperty] public IList<Movie> Movies { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public IndexModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region HttpMethods

        public async Task OnGetAsync()
        {
            Movies = await _appDbContext.Movies.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var movie = await _appDbContext.Movies.FindAsync(id);

            if (movie != null) {
                _appDbContext.Movies.Remove(movie);
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        #endregion
    }
}