using vcart.Core.Entities;
using vcart.Models;
using vcart.Repositories.Interfaces;
using vcart.Services.Interfaces;

namespace vcart.Services.Implementations
{
    public class ItemService : Service<Item>, IItemService
    {
        IRepository<Item> _itemRepo;
        public ItemService(IRepository<Item> itemRepo): base(itemRepo) 
        {
           
        }
        public IEnumerable<ItemModel> GetItems()
        {
            var data = _repo.GetAll().Select(i => new ItemModel
            {
                Id = i.Id,
                Name = i.Name,
                CategoryId = i.CategoryId,
                Description = i.Description,
                ImageUrl = i.ImageUrl,
                ItemTypeId = i.ItemTypeId,
                UnitPrice = i.UnitPrice
            });
            return data;
        }
    }
}
