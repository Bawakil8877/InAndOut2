using System.ComponentModel.DataAnnotations;

namespace InAndOut2.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
