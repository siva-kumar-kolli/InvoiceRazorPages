using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LonrixApp.Models
{
    public class InvoiceDt
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";
        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }
        [Required]
        public string Service { get; set; } = "";
        [Range(1,99999, ErrorMessage="Unit Price is not valid")]
        public decimal UnitPrice { get; set; }
        [Range(1,99)]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Client Name is required")]
        public string ClientName { get; set; } = "";
        [Required,EmailAddress]
        public string Email { get; set; } = "";
        [Phone]
        public string phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
