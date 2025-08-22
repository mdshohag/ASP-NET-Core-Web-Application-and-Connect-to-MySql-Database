using InvoiceApp.Model;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<Customer> customerList = new();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            customerList = context.Customers.OrderByDescending(i => i.Id).ToList();
        }
    }
}
