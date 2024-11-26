
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        //The property Category { get; } is written to provide access to the CategoryRepository instance
        //this way—it's just a standard pattern to expose repositories via properties.
        ICategoryRepository Category { get; } // acts as a way to access the CategoryRepository
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUser ApplicationUser { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        void save();
    }
}

