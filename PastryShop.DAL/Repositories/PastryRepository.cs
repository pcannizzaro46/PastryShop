using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PastryShop.DAL.Interfaces;
using PastryShop.DAL.Models;

namespace PastryShop.DAL.Repositories
{
    public class PastryRepository : IPastryRepository
    {
        private readonly PastryDbContext _pastryDbContext;

        public PastryRepository(PastryDbContext dbContext)
        {
            _pastryDbContext = dbContext;
        }

        public Dessert AddDessert(Dessert dessert)
        {
            _pastryDbContext.Desserts.Add(dessert);
            return dessert;
        }

        public Dessert UpdateDessert(Dessert dessert)
        {
            _pastryDbContext.Desserts.Attach(dessert);
            return dessert;
        }

        public void DeleteDessert(Dessert dessert) => _pastryDbContext.Desserts.Remove(dessert);

        public IEnumerable<Dessert> GetDesserts(bool includeIngredients = false)
        {
            IQueryable<Dessert> query = _pastryDbContext.Desserts;

            if (includeIngredients)
                query = query.Include(x => x.Ingredients);

            return query.ToList();
        }
        
        public ShowcaseItem AddShowcaseItem(ShowcaseItem showcaseItem)
        {
            _pastryDbContext.ShowcaseItems.Add(showcaseItem);
            return showcaseItem;
        }
        
        public IEnumerable<ShowcaseItem> GetShowcaseItems(bool includeDessertIngredients)
        {
            IQueryable<ShowcaseItem> query = _pastryDbContext.ShowcaseItems.Include(x => x.Dessert);

            if (includeDessertIngredients)
                query = query.Include(x => x.Dessert.Ingredients);

            return query.ToList();
        }
        
        public void DeleteShowcaseItem(ShowcaseItem showcaseItem) => _pastryDbContext.ShowcaseItems.Remove(showcaseItem);

        public Task SaveAsync() => _pastryDbContext.SaveChangesAsync();
    }
}