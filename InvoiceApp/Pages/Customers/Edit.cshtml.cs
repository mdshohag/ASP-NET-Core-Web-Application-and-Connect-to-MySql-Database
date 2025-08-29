using InvoiceApp.Model;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]


        public Customer Customer { get; set; } = new Customer();


        public EditModel(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult OnGet(int id)
        {

            var customer = context.Customers.Find(id);
            if (customer == null)
            {
                return RedirectToPage("/Customers/Index");
            }


            Customer = customer;

            Customer.Name = customer.Name;
            Customer.Email = customer.Email;
            Customer.Email = customer.Email;
            Customer.Phone = customer.Phone;
            Customer.Address = customer.Address;

            return Page();


        }

        public string successMessage = "";


        public IActionResult OnPost(int id)
        {
            var customer = context.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToPage("/Customers/Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the entity with values from the bound Customer
            customer.Name = Customer.Name;
            customer.Email = Customer.Email;
            customer.Phone = Customer.Phone;
            customer.Address = Customer.Address;

            context.SaveChanges();

            successMessage = "Customer updated successfully!";

            return Page();
        }
    }
}
