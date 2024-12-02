using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;


namespace Bulky.DataAccess.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ApplicationDbContext _db;
        public ProductImageRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(ProductImage obj) {
            throw new NotImplementedException();
        }
    }
}