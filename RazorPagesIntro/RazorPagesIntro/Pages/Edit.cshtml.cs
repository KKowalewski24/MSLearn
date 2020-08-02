using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIntro.Data;
using RazorPagesIntro.Exceptions.Customer;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages {

    public class EditModel : PageModel {

        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly AppDbContext _appDbContext;

        [BindProperty] public Customer Customer { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public EditModel(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        #region HttpMethods

        public async Task<IActionResult> OnGetAsync(int id) {
            Customer = await _appDbContext.Customers.FindAsync(id);

            if (Customer != null) {
                return Page();
            }

            return RedirectToPage(PATH_INDEX);
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _appDbContext.Attach(Customer).State = EntityState.Modified;

            try {
                await _appDbContext.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                throw new CustomerNotFoundException(Customer.Id.ToString());
            }

            return RedirectToPage(PATH_INDEX);
        }

        #endregion

    }

}
