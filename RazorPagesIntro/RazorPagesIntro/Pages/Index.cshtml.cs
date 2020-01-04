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
        private readonly AppDbContext _appDbContext;
        public IList<Customer> CustomerList { get; set; }

        #endregion

        public IndexModel(AppDbContext appDbContext, ILogger<IndexModel> logger = null)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #region HttpMethods

        public async Task OnGetAsync()
        {
            CustomerList = await _appDbContext.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _appDbContext.Customers.FindAsync(id);

            if (customer != null)
            {
                _appDbContext.Customers.Remove(customer);
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        #endregion
    }
}