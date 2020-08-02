using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesIntro.Data;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages {

    public class CreateModel : PageModel {

        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly AppDbContext _appDbContext;

        [BindProperty] public Customer Customer { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public CreateModel(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        #region HttpMethods

        public IActionResult OnGet() {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _appDbContext.Customers.Add(Customer);
            await _appDbContext.SaveChangesAsync();

            return RedirectToPage(PATH_INDEX);
        }

        #endregion

    }

}
