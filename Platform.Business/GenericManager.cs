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

        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

        public bool Delete(T entity)
        {
            return _genericRepository.Delete(entity);
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

        public T Update(T entity)
        {
            return _genericRepository.Update(entity);
        }
    }
}
