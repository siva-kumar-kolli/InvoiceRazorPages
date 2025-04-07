using LonrixApp.Models;
using LonrixApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LonrixApp.Pages.Invoices
{
    public class DetailModel : PageModel
    {
        private readonly MyDbContext context;

        public Invoice Invoice { get; set; }
        public DetailModel(MyDbContext context)
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

            return Page();

        }
    }
}
