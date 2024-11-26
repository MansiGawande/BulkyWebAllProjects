
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    // crud for all model, 16 crud(category,Product,Order,payment) use only 4 action & T is Model

    //To implement a Unit of Work pattern that combines both generic and specific repository
    //interfaces without having to register each service individually in Program.cs.

    //implementing the Unit of Work pattern with both generic and specific repository interfaces
    //generic repository pattern
    public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;
		private string? includeProperties;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>(); 
			// Set any Model as currect using T Model; dbSet = this.dbSet;  //_db.Categories == dbSet
			_db.Products.Include(u => u.Category);  
			//Category will atmtcly polulated when it fatch all products 
		}

		public void Add(T entity) {
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false) {
			IQueryable<T> query;

			if (tracked) { // true
				query = dbSet;
			}
			else {
				query = dbSet.AsNoTracking();
			}
			query = query.Where(filter); // query para <T> . where (name, Id any prop)
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties
					.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.FirstOrDefault();
		}


		//Category, CoverType
		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);

			}
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties
					.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
