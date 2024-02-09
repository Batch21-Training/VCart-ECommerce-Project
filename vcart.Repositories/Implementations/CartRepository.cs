using vcart.Core;
using vcart.Core.Entities;
using vcart.Models;
using vcart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace vcart.Repositories.Implementations
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        AppDbContext dbContext
        {
            get { return _db as AppDbContext; }
        }
        public CartRepository(AppDbContext db) : base(db)
        {

        }
        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = dbContext.CartItems.Where(c=>c.CartId==cartId && c.Id==itemId).FirstOrDefault();
            if(item != null)
            {
                dbContext.CartItems.Remove(item);
               return dbContext.SaveChanges();
            }
            return 0;
        }

        public Cart GetCart(Guid CartId)
        {
            return dbContext.Carts.Include(c=>c.CartItems).Where(c=>c.Id==CartId && c.IsActive==true).FirstOrDefault();
        }

        public CartModel GetCartDetails(Guid CartId)
        {
            var model = (from cart in dbContext.Carts
                         where cart.Id == CartId && cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedDate,
                             Items = (from cartItem in dbContext.CartItems
                                      join item in dbContext.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.CartId == CartId
                                      select new ItemModel
                                      {
                                          Id = cartItem.Id,
                                          Quantity = cartItem.Quantity,
                                          UnitPrice = cartItem.UnitPrice,
                                          ItemId = item.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return dbContext.SaveChanges();
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                var cartItems = cart.CartItems.ToList();
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (cartItems[i].Id == itemId)
                    {
                        flag = true;
                        cartItems[i].Quantity += (Quantity);
                        break;
                    }
                }
                if (flag)
                {
                    cart.CartItems = cartItems;
                    return dbContext.SaveChanges();
                }
            }
            return 0;
        }
    }
}
