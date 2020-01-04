using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesIntro.Data;
using RazorPagesIntro.Models;

namespace RazorPagesIntro.Pages
{
    public class IndexModel : PageModel
    {
        #region Properties

        private readonly ILogger<IndexModel> _logger;
        private readonly CustomerDbContext _customerDbContext;
        public IList<Customer> CustomerList { get; set; }

        #endregion

        public IndexModel(CustomerDbContext customerDbContext, ILogger<IndexModel> logger = null)
        {
            _customerDbContext = customerDbContext;
            _logger = logger;
        }

        #region HttpMethods

        public async Task OnGetAsync()
        {
            CustomerList = await _customerDbContext.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _customerDbContext.Customers.FindAsync(id);

            if (customer != null)
            {
                _customerDbContext.Customers.Remove(customer);
                await _customerDbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        #endregion
    }
}