
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; } //ICategoryRepository This is the type of the property. Category property  returns an instance of ICategoryRepository.
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUser ApplicationUser { get; private set; }
        
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            //The property Category will hold a reference to an object that implements the ICategoryRepository
            //interface (likely, a concrete class like CategoryRepository).
            _db = db;
            Category = new CategoryRepository(_db); 
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db); //initiallization
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetails = new OrderDetailRepository(_db);
            ProductImage = new ProductImageRepository(_db);
        }
        public void save()
        {
            _db.SaveChanges();
        }
    }
}

///{ get; private set; }:

/// get: This part means that the value of this property can be read (i.e., other classes can access it and get the reference to the ICategoryRepository object).
/// private set: This part means that the value of this property can only be set (i.e., assigned) within the UnitOfWork class. Outside of UnitOfWork, 
/// the property is read-only. Other classes cannot change or assign a new instance to the Category property; they can only read it.

