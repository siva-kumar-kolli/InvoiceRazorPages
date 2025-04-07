using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LonrixApp.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public string Status { get; set; } = "";
        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }

        public string Service { get; set; } = "";
        [Precision(16,2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ClientName { get; set; } = "";
        public string Email { get; set; } = "";
        public string phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
