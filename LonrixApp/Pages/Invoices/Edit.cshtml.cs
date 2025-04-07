using LonrixApp.Models;
using LonrixApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LonrixApp.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly MyDbContext context;
        [BindProperty]
        public InvoiceDt InvoiceDt { get; set; } = new InvoiceDt();
        public Invoice Invoice { get; set; } = new();
        public EditModel(MyDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet(int id)
        {
            var invoice = context.Invoices.FirstOrDefault(x => x.Id == id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }
            Invoice = invoice;
            InvoiceDt.Number = invoice.Number;
            InvoiceDt.Status = invoice.Status;
            InvoiceDt.IssueDate = invoice.IssueDate;
            InvoiceDt.DueDate = invoice.DueDate;
            InvoiceDt.Service = invoice.Service;
            InvoiceDt.Quantity = invoice.Quantity;
            InvoiceDt.UnitPrice = invoice.UnitPrice;   
            InvoiceDt.ClientName = invoice.ClientName;
            InvoiceDt.Email = invoice.Email;
            InvoiceDt.phone=invoice.phone;
            InvoiceDt.Address = invoice.Address;
            
            return Page();

        }
        
        public IActionResult OnPost(int id)
        {
            var invoice = context.Invoices.FirstOrDefault(x => x.Id == id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }
            Invoice = invoice;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            invoice.Number= InvoiceDt.Number;
            invoice.Status= InvoiceDt.Status;
            invoice.IssueDate= InvoiceDt.IssueDate;
            invoice.DueDate= InvoiceDt.DueDate;
            invoice.Service= InvoiceDt.Service;
            invoice.Quantity= InvoiceDt.Quantity;
            invoice.UnitPrice= InvoiceDt.UnitPrice;
            invoice.ClientName= InvoiceDt.ClientName;
            invoice.Email= InvoiceDt.Email;
            invoice.phone= InvoiceDt.phone;
            invoice.Address= InvoiceDt.Address;
            
            context.SaveChanges();
            TempData["success"] = "invoice has been updated successfully";
            return RedirectToPage("/Invoices/Index");
        }
    }
}
