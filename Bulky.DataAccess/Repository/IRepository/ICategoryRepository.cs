
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
	//interfaces for your specific repositories

	public interface ICategoryRepository : IRepository<Category> {
        // use all method of repository.cs Interface we use 2 more
        void Update(Category obj); 
    }
}
