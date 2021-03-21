using System.Collections.Generic;
using System.Threading.Tasks;
using PastryShop.Core.Models;

namespace PastryShop.Core.Services
{
    public interface IPastryManagementService
    {
        DessertModel AddDessert(DessertModel dessert);
        
        void DeleteDessert(DessertModel dessert);

        void UpdateDessert(DessertModel dessert);
        
        IEnumerable<DessertModel> GetDesserts(bool includeIngredients);

        ShowcaseItemModel SellDessert(DessertModel dessert);

        IEnumerable<ShowcaseItemModel> GetShowcaseItemsOnSale(bool includeIngredients);

        IEnumerable<ShowcaseItemModel> GetAllShowcaseItems(bool includeIngredients);

        Task DeleteShowCaseItem(ShowcaseItemModel showcaseItem);

        Task SaveAsync();
    }
}