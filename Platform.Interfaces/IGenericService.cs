using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    /// <summary>
    /// Genel varlıklar için oluşturulmuş arabirim sınıfıdır. Sınıflar ile çalışır.
    /// </summary>
    /// <typeparam name="T">Varlık Sınıfları</typeparam>
    public interface IGenericService<T> where T : class
    {
        /// <summary>
        /// Gelen varlığı ekler.
        /// </summary>
        /// <param name="entity">Entry,Tag,Person,Like</param>
        /// <returns>Entry,Tag,Person,Like</returns>
        T Add(T entity);
        /// <summary>
        /// Id'ye göre varlık dönderir.
        /// </summary>
        /// <param name="id">EntryID,TagID,PersonID</param>
        /// <returns>T</returns>
        T Get(int id);
        /// <summary>
        /// Varlık sayısı
        /// </summary>
        /// <returns>Veri adeti</returns>
        int Count();
        /// <summary>
        /// Varlık listesi döner.
        /// </summary>
        /// <returns>Entries,Tags,People</returns>
        List<T> GetAll();
        /// <summary>
        /// Filtreli varlık listesi döner.
        /// </summary>
        /// <param name="expression">x=>x.EntryID==n</param>
        /// <returns>Filter Entries,Tags,People</returns>
        List<T> GetAll(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Gelen varlığı günceller.
        /// </summary>
        /// <param name="entity">Entry,Tag,Person</param>
        /// <returns>Entry,Tag,Person</returns>
        T Update(T entity);
        /// <summary>
        /// RemoveRange ile siler. Örnek(RemoveRange(x=>x.ıd>=0))
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>True False</returns>
        bool RemoveRange(Expression<Func<T,bool>> expression);
        /// <summary>
        /// Birincil anahtarı başka tabloda kullanılmayan tablolarda silme işlemi yapar.
        /// </summary>
        /// <param name="id">ReplyID,LikeID</param>
        /// <returns>True/False</returns>
        bool Remove(int id);
        /// <summary>
        /// Birincil anahtarı başka tabloda kullanılmayan tablolarda silme işlemi yapar.
        /// </summary>
        /// <param name="entity">Reply,Like</param>
        /// <returns>True/False</returns>
        bool Remove(T entity);
        /// <summary>
        /// Gelen varlıkta belirtilen sütunları çeker ve listeler.
        /// </summary>
        /// <typeparam name="TResult">Sütunlar x.EntryID</typeparam>
        /// <param name="select">x</param>
        /// <returns>Entries,Tags,People</returns>
        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select);
    }
}
