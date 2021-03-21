using System;
using PastryShop.DAL.Models;

namespace PastryShop.Core.Models
{
    public class ShowcaseItemModel
    {
        public ShowcaseItem Entity { get; }

        private static readonly TimeSpan OneDay = TimeSpan.FromDays(1);
        private static readonly TimeSpan TwoDays = TimeSpan.FromDays(2);
        private static readonly TimeSpan ThreeDays = TimeSpan.FromDays(3);

        public ShowcaseItemModel(ShowcaseItem showcaseEntity)
        {
            Entity = showcaseEntity;

            SellPrice = CalcPrice();
            Discount = CalcDiscount();
            
            Dessert = new DessertModel(showcaseEntity.Dessert);
        }

        public int Id => Entity.Id;

        public decimal SellPrice { get; }

        public decimal OriginalPrice => Entity.Price;

        public decimal Discount { get; }

        public DateTime CreateDate => Entity.CreateDate;
        
        public DateTime ExpirationDate => Entity.CreateDate.Add(ThreeDays);

        public string CreateUser => Entity.CreateUser;

        public DessertModel Dessert { get; }
        
        private decimal CalcDiscount() => 100 - SellPrice / OriginalPrice * 100;

        private decimal CalcPrice()
        {
            var timeLived = DateTime.UtcNow.Subtract(Entity.CreateDate.ToUniversalTime());

            if (timeLived < OneDay) return Entity.Price;
            if (timeLived < TwoDays) return Entity.Price * 0.8m;     // 80% of original price 
            if (timeLived < ThreeDays) return Entity.Price * 0.2m;   // 20% of original price 
            
            return 0;
        }
        public bool IsExpired => DateTime.UtcNow.Subtract(Entity.CreateDate.ToUniversalTime()) >= ThreeDays;
    }
}