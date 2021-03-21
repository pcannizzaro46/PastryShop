using System.Collections.Generic;
using System.Threading.Tasks;
using PastryShop.DAL.Models;

namespace PastryShop.DAL.Interfaces
{
    public interface IPastryRepository
    {
        Dessert AddDessert(Dessert dessert);

        Dessert UpdateDessert(Dessert dessertEntity);
        
        void DeleteDessert(Dessert dessert);

        IEnumerable<Dessert> GetDesserts(bool includeIngredients);

        ShowcaseItem AddShowcaseItem(ShowcaseItem showcaseItem);

        void DeleteShowcaseItem(ShowcaseItem showcaseItem);

        IEnumerable<ShowcaseItem> GetShowcaseItems(bool includeIngredients);

        Task SaveAsync();
    }
}