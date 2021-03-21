using System;
using System.ComponentModel.DataAnnotations;
using PastryShop.DAL.Models;

namespace PastryShop.Core.Models
{
    public class IngredientModel
    {
        public IngredientModel(Ingredient ingredient)
        {
            Entity = ingredient;
        }

        public Ingredient Entity { get; }

        public int Id => Entity.IngredientId;

        [Required]
        public string Name
        {
            get => Entity.Name;
            set => Entity.Name = value;
        }

        [Required]
        public string UM
        {
            get => Entity.UM;
            set => Entity.UM = value;
        }

        [Required]
        [Range(0.01, 1000)]
        public decimal Quantity
        {
            get => Entity.Quantity;
            set => Entity.Quantity = value;
        }

        public string UserCreate
        {
            get => Entity.UserCreate;
            set => Entity.UserCreate = value;
        }

        public DateTime CreateDate => Entity.CreateDate;
    }
}