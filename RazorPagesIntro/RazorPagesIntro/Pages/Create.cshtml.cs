using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesIntro.Data;
using RazorPagesIntro.Models;
using static RazorPagesIntro.Constants.Constants;

namespace RazorPagesIntro.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CustomerDbContext _customerDbContext;

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
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

            _customerDbContext.Customers.Add(Customer);
            await _customerDbContext.SaveChangesAsync();

            return RedirectToPage(PATH_INDEX);
        }
    }
}