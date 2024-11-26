using Bulky.DataAccess.Data;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ApplicationDbContext _db;
        public ShoppingCartRepository (ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public void Update(ShoppingCart cart)
        {
           _db.ShoppingCarts.Update(cart);
        }
    }
}
