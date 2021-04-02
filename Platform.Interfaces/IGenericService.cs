using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    /// <summary>
    /// Genel sınıflar için oluşturulmuş arabirim sınıfıdır. Sınıflar ile çalışır.
    /// </summary>
    /// <typeparam name="T">Varlık Sınıfları</typeparam>
    public interface IGenericService<T> where T : class
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
        /// Id'ye göre varlık silme
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        bool Delete(int id);
        /// <summary>
        /// T varlığını siler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Bool</returns>
        bool Delete(T entity);
        /// <summary>
        /// T varlığını dönderir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T</returns>
        T Update(T entity);
    }
}
