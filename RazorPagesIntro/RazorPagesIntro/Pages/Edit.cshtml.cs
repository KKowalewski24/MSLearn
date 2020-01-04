using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIntro.Data;
using RazorPagesIntro.Exceptions;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages
{
    public class EditModel : PageModel
    {
        #region Properties

        private readonly CustomerDbContext _customerDbContext;

        [BindProperty]
        public Customer Customer { get; set; }

        #endregion

        public EditModel(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        #region HttpMethods

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _customerDbContext.Customers.FindAsync(id);
            
            if (Customer != null)
            {
                return Page();
            }

            return RedirectToPage(PATH_INDEX);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _customerDbContext.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _customerDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new CustomerNotFoundException(Customer.Id.ToString());
            }

            return RedirectToPage(PATH_INDEX);
        }

        #endregion
    }
}