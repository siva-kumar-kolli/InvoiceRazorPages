using LonrixApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LonrixApp.Pages.Invoices
{
    public class ChartModel : PageModel
    {
        private readonly MyDbContext context;

        public ChartModel(MyDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
        }

        public JsonResult OnGetData()
        {
            var data = context.Invoices
                .Select(x => new {
                    name = x.ClientName,
                    total = x.Quantity * x.UnitPrice
                })
                .ToList();

            return new JsonResult(data);
        }
    }
}
