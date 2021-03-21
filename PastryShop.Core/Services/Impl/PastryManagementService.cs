using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PastryShop.Core.Models;
using PastryShop.DAL.Interfaces;
using PastryShop.DAL.Models;

namespace PastryShop.Core.Services.Impl
{
    public class PastryManagementService : IPastryManagementService
    {
        private readonly IPastryRepository _pastryRepository;

        public PastryManagementService(IPastryRepository pastryRepository)
        {
            _pastryRepository = pastryRepository;
        }

        public DessertModel AddDessert(DessertModel dessert)
        {
            _pastryRepository.AddDessert(dessert.Entity);
            return dessert;
        }

        public void DeleteDessert(DessertModel dessert) => _pastryRepository.DeleteDessert(dessert.Entity);

        public void UpdateDessert(DessertModel dessert) => _pastryRepository.UpdateDessert(dessert.Entity);

        public IEnumerable<DessertModel> GetDesserts(bool includeIngredients) =>
            _pastryRepository.GetDesserts(includeIngredients).Select(d => new DessertModel(d));

        public ShowcaseItemModel SellDessert(DessertModel dessert)
        {
            if (dessert == null) throw new ArgumentNullException(nameof(dessert));

            var sci = _pastryRepository.AddShowcaseItem(
                new ShowcaseItem
                {
                    Dessert = dessert.Entity,
                    DessertId = dessert.DessertId,
                    Price = dessert.Price,
                    CreateUser = dessert.UserCreate, //TODO: dovrebbe essere l'utente loggato
                    CreateDate = DateTime.Now
                });

            return new ShowcaseItemModel(sci);
        }

        public async Task DeleteShowCaseItem(ShowcaseItemModel showcaseItem)
        {
            _pastryRepository.DeleteShowcaseItem(showcaseItem.Entity);
            //await _pastryRepository.SaveAsync();
        }

        public IEnumerable<ShowcaseItemModel> GetShowcaseItemsOnSale(bool includeIngredients) =>
            GetAllShowcaseItems(includeIngredients).Where(showcaseItem => !showcaseItem.IsExpired);

        public IEnumerable<ShowcaseItemModel> GetAllShowcaseItems(bool includeIngredients) =>
            _pastryRepository.GetShowcaseItems(includeIngredients)
                .Select(showcaseItem => new ShowcaseItemModel(showcaseItem));

        public Task SaveAsync() => _pastryRepository.SaveAsync();
    }

    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}