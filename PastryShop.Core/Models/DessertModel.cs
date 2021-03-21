using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PastryShop.DAL.Models;

namespace PastryShop.Core.Models
{
    public class DessertModel
    {
        private readonly List<IngredientModel> _ingredients;

        public DessertModel(Dessert dessert)
        {
            Entity = dessert;
            _ingredients = dessert.Ingredients.Select(i => new IngredientModel(i)).ToList();
        }

        public int DessertId => Entity.DessertId;
        
        public Dessert Entity { get; }

        [Required]
        public string Name
        {
            get => Entity.Name;
            set => Entity.Name = value;
        }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price
        {
            get => Entity.Price;
            set => Entity.Price = value;
        }

        [Required]
        public string ImageFullPath
        {
            get => Entity.ImageFullPath;
            set => Entity.ImageFullPath = value;
        }

        public string UserCreate => Entity.UserCreate;

        public DateTime CreateDate => Entity.CreateDate;

        public IEnumerable<IngredientModel> Ingredients => _ingredients;

        public void AddIngredient(IngredientModel ingredient)
        {
            _ingredients.Add(ingredient);
            Entity.Ingredients.Add(ingredient.Entity);
        }

        public void DeleteIngredient(IngredientModel ingredient)
        {
            _ingredients.Remove(ingredient);
            Entity.Ingredients.Remove(ingredient.Entity);
        }
    }
}