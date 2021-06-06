using Platform.Dal.Abstract;
using Platform.Dal.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    /// <summary>
    /// Genel Repositoryler için oluşturulmuş arabirim. Kulladığı arabim sınıfı => IGenericRepository
    /// </summary>
    /// <typeparam name="T">Varlık Sınıfı</typeparam>
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        public PlatformContext _context;
        public EfGenericRepository()
        {
            _context = new PlatformContext();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public int Count()
        {
            return GetAll().Count();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            var list = _context.Set<T>().AsNoTracking();
            return list;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AsNoTracking().Where(expression);
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select)
        {
            return _context.Set<T>().Select(select);
        }

        public bool Remove(int id)
        {
            return Remove(Get(id));
        }

        public bool Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveRange(Expression<Func<T, bool>> expression)
        {
            _context.Set<T>().RemoveRange(GetAll(expression));
            return _context.SaveChanges() > 0;

        }

        public T Update(T entity)
        {
            _context.Set<T>().AddOrUpdate(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
