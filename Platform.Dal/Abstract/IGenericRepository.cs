using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Abstract
{
    /// <summary>
    /// Genel sınıflar için oluşturulmuş arabirim sınıf
    /// </summary>
    /// <typeparam name="T">Varlık Sınıfı</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// T varlığını ekleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T</returns>
        T Add(T entity);
        /// <summary>
        /// Id'ye göre varlık getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        T Get(int id);
        /// <summary>
        /// List Count
        /// </summary>
        /// <returns>Veri sayısı</returns>
        int Count();
        /// <summary>
        /// Tüm T listesi
        /// </summary>
        /// <returns>T List</returns>
        List<T> GetAll();
        /// <summary>
        /// Filter List T
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>T List</returns>
        List<T> GetAll(Expression<Func<T, bool>> expression);
        
        /// <summary>
        /// T varlığını dönderir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T</returns>
        T Update(T entity);
        /// <summary>
        /// RemoveRange ile siler. Örnek(RemoveRange(x=>x.ıd>=0))
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>True False</returns>
        bool RemoveRange(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Select ıd, name from A
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="select"></param>
        /// <returns></returns>
        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select);
    }
}
