using Platform.Dal.Abstract;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Business
{
    /// <summary>
    /// Genel olarak veritabanı iletişim sınıfıdır. Kullandığı arabirim => IGenericService
    /// </summary>
    /// <typeparam name="T">Varlık Sınıfı</typeparam>
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public T Add(T entity)
        {
            return _genericRepository.Add(entity);
        }

        public int Count()
        {
            return _genericRepository.Count();
        }

        public T Get(int id)
        {
            return _genericRepository.Get(id);
        }

        public List<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.GetAll(expression);
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select)
        {
            return _genericRepository.GetAllSelect(select);
        }

        public bool RemoveRange(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.RemoveRange(expression);
        }

        public T Update(T entity)
        {
            return _genericRepository.Update(entity);
        }
    }
}
