using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DeleteModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet(int id)
        {
            var customer = context.Customers.Find(id);

            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }

            return RedirectToPage("/Customers/Index");
        }
    }
}
