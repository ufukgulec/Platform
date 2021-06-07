using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Business
{
    /// <summary>
    /// Entrylerin veritabanı iletişim sınıfıdır. Kalıtım aldığı sınıf => GenericManager Kullandığı arabirim => IEntryService
    /// </summary>
    public class EntryManager : GenericManager<Entry>, IEntryService
    {
        IEntryRepository _entryRepository;

        public EntryManager(IEntryRepository entryRepository) : base(entryRepository)
        {
            _entryRepository = entryRepository;
        }

        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> List()
        {
            var list = _entryRepository.List();
            return list;
        }
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan ve koşula göre Entry listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entries</returns>
        public List<Entry> List(Expression<Func<Entry, bool>> expression)
        {
            var list = _entryRepository.List(expression);
            return list;
        }
        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like) siler.
        /// </summary>
        /// <param name="id">EntryID</param>
        /// <returns>True/False</returns>
        public bool Delete(int id)
        {
            return _entryRepository.Delete(id);
        }
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="entity">Entry</param>
        /// <returns>True/False</returns>
        public bool Delete(Entry entry)
        {
            return _entryRepository.Delete(entry);
        }
        /// <summary>
        /// Entry post Tarih ve isValid özelliği metotta tanımlıdır.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public Entry Post(Entry entry)
        {
            entry.IsValid = true;
            entry.EntryDate = DateTime.Now.Date;
            return _entryRepository.Add(entry);
        }
        /// <summary>
        /// Datetime.Now.Date e eşit olan (Bugun) Entry listesi
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> TodayEntries()
        {
            return _entryRepository.List()
                .Where(x => x.EntryDate == DateTime.Now.Date)
                .ToList();
        }

        public List<Entry> PopularEntries(int a)
        {
            var list = _entryRepository.List()
                .OrderByDescending(x => x.Likes.Count)
                .Take(a).ToList();
            return list;
        }
    }
}