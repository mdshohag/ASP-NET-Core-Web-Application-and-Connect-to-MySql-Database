using InvoiceApp.Model;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Customer Customer { get; set; } = new();

        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;

        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = new Customer
            {
                Name = Customer.Name,
                Email = Customer.Email,
                Phone = Customer.Phone,
                Address = Customer.Address,

            };


            context.Customers.Add(customer);
            context.SaveChanges();

            return RedirectToPage("/Customers/Index");

        }
    }
}
