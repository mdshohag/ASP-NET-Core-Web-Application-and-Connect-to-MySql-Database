using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Model
{
    public class InvoiceDto
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = ""; // Paid or Pending
        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }

        // Service details
        [Required]
        public string Service { get; set; } = "";

        [Range(1, 999999, ErrorMessage = "Unit Price must be between 1 and 999,999")]
        public decimal UnitPrice { get; set; }

        [Range(1, 99, ErrorMessage = "Quantity must be between 1 and 99")]
        public int Quantity { get; set; }

        //client details
        [Required(ErrorMessage =  "Client Name is required")]
        public string ClientName { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Phone]
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
