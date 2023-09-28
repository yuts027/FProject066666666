
using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Respositories
{
	public class BaseRepository<TEntity> where TEntity : class
	{
		private AppDbContext _db = new AppDbContext();

		public void Create(TEntity entity)
		{
			if (entity != null)
			{
				_db.Set<TEntity>().Add(entity);
			}
		}

		public void Update(TEntity entity)
		{
			if (entity != null)
			{
				_db.Entry(entity).State = EntityState.Modified;
			}
		}

		public void Delete(TEntity entity)
		{
			if (entity != null)
			{
				_db.Set<TEntity>().Remove(entity);
			}
		}

		public TEntity GetById(int id)
		{
			return _db.Set<TEntity>().Find(id);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}