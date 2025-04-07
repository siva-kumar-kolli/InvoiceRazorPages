using LonrixApp.Models;
using LonrixApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace LonrixApp.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly MyDbContext context;
        [BindProperty]
        public InvoiceDt InvoiceDt { get; set; } = new();
        public CreateModel(MyDbContext context)
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

            var invoice = new Invoice
            {
                Number = InvoiceDt.Number,
                Status = InvoiceDt.Status,
                IssueDate = InvoiceDt.IssueDate,
                DueDate = InvoiceDt.DueDate,
                Service = InvoiceDt.Service,
                UnitPrice = InvoiceDt.UnitPrice,
                Quantity = InvoiceDt.Quantity,
                ClientName = InvoiceDt.ClientName,
                Email = InvoiceDt.Email,
                phone = InvoiceDt.phone,
                Address = InvoiceDt.Address
            };
            context.Invoices.Add(invoice);
            context.SaveChanges();
            TempData["success"] = "invoice created successfully";
            return RedirectToPage("/Invoices/Index");
        }
    }
}
