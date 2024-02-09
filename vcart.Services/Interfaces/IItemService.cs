using vcart.Core.Entities;
using vcart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vcart.Services.Interfaces
{
    public interface IItemService: IService<Item>
    {
        public IEnumerable<ItemModel> GetItems();
    }
}
