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
        /// <summary>
        /// Generic ekleme yapar.
        /// </summary>
        /// <param name="entity">Reply,Like,Tag</param>
        /// <returns>Reply,Like,Tag</returns>
        public T Add(T entity)
        {
            return _genericRepository.Add(entity);
        }
        /// <summary>
        /// Generic listede veri sayısını döner.
        /// </summary>
        /// <returns>Veri Adeti</returns>
        public int Count()
        {
            return _genericRepository.Count();
        }
        /// <summary>
        /// Generic veri çeker.
        /// </summary>
        /// <param name="id">EntryID,TagID,LikeID</param>
        /// <returns>Entry,Tag,Like</returns>
        public T Get(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Generic veri listesi döner.
        /// </summary>
        /// <returns>Entries,Tags,Likes</returns>
        public IQueryable<T> GetAll()
        {
            return _genericRepository.GetAll();
        }
        /// <summary>
        /// Generic koşullu veri listesi döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID</param>
        /// <returns>Entries,Tags,Likes</returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.GetAll(expression);
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select)
        {
            return _genericRepository.GetAllSelect(select);
        }
        /// <summary>
        /// Generic olarak birincil anahtarları başka tablolarda yabancıl anahtar olmayanlarda veri siler.(Reply,Like)
        /// </summary>
        /// <param name="id">ReplyID,LikeID</param>
        /// <returns>True/False</returns>
        public bool Remove(int id)
        {
            return _genericRepository.Remove(id);
        }
        /// <summary>
        /// Generic olarak birincil anahtarları başka tablolarda yabancıl anahtar olmayanlarda veri siler.(Reply,Like)
        /// </summary>
        /// <param name="entity">Reply,Like</param>
        /// <returns></returns>
        public bool Remove(T entity)
        {
            return _genericRepository.Remove(entity);
        }

        public bool RemoveRange(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.RemoveRange(expression);
        }
        /// <summary>
        /// Generic olarak veri günceller.
        /// </summary>
        /// <param name="entity">Entry,Tag,Person</param>
        /// <returns>Entry,Tag,Person</returns>
        public T Update(T entity)
        {
            return _genericRepository.Update(entity);
        }
    }
}
