using LonrixApp.Models;
using LonrixApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LonrixApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly MyDbContext context;
        public List<Invoice> invoiceList = new();
        public IndexModel(MyDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            invoiceList=context.Invoices.OrderByDescending(x => x.Id).ToList();
        }
    }
}
