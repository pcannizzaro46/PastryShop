using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PastryShop.DAL.Models
{
    public class Dessert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DessertId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        [DefaultValue("Images/Desserts/NoImage.png")]
        public string ImageFullPath { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string UserCreate { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }

        virtual public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        virtual public ICollection<ShowcaseItem> ShowcaseItems { get; set; } = new List<ShowcaseItem>();
    }
}
