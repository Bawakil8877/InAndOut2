using System.ComponentModel.DataAnnotations;

namespace InAndOut2.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
       

        public Item()
        {
                
        }
    }
}
