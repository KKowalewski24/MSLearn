using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesIntro.Data;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _appDbContext;

        [BindProperty]
        public Movie Movie { get; set; }

        public CreateModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _appDbContext.Movies.Add(Movie);
            await _appDbContext.SaveChangesAsync();

            return RedirectToPage(PATH_MOVIES);
        }
    }
}