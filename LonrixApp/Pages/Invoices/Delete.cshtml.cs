using LonrixApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LonrixApp.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly MyDbContext context;

        public DeleteModel(MyDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet(int id)
        {
            var invoice = context.Invoices.FirstOrDefault(x => x.Id == id);
            if (invoice != null)
            {
                context.Invoices.Remove(invoice);
                context.SaveChanges();
            }
            TempData["success"] = "invoice delete successfully";
            return RedirectToPage("/Invoices/Index");
        }
    }
}
