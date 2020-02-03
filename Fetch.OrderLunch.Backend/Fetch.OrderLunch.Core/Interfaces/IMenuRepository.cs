using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<Menu> GetAsync(int supplierId);
        Task<Menu> FindAsync(int id);
        void UpdateMenu(Menu menu);
    }
}
