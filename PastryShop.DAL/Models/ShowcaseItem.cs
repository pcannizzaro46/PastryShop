using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PastryShop.DAL.Models
{
    public class ShowcaseItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int DessertId { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string CreateUser { get; set; }
        
        [Required]
        public bool Enable { get; set; }

        virtual public Dessert Dessert { get; set; }
    }
}
