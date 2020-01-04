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
        private readonly AppDbContext _appDbContext;

        [BindProperty]
        public IList<Movie> Movies { get; set; }

        public IndexModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task OnGetAsync()
        {
            Movies = await _appDbContext.Movies.ToListAsync();
        }
    }
}