using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InAndOut2.Models
{
    public class expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        public string ExpenseName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than 0!")]
        public int Amount { get; set; }
        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
