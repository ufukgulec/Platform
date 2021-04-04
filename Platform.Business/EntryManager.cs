using Platform.Dal.Abstract;
using Platform.Entities.Models;
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
        public List<Entry> ActiveEntryGetAll()
        {
            return _entryRepository.ActiveEntryGetAll();
        }
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan ve koşula göre Entry listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entries</returns>
        public List<Entry> ActiveEntryGetAll(Expression<Func<Entry, bool>> expression)
        {
            return _entryRepository.ActiveEntryGetAll(expression);
        }

        /// <summary>
        /// Eskiden yeniye Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> OldToNewEntryGetAll()
        {
            return _entryRepository.OldToNewEntryGetAll();
        }
        /// <summary>
        /// Belli bir tarihteki Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> PastHistoryEntryGetAll(DateTime dateTime)
        {
            return _entryRepository.PastHistoryEntryGetAll(dateTime);
        }
        /// <summary>
        /// Bugünkü Entry Listesi
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> TodayEntryGetAll()
        {
            return _entryRepository.TodayEntryGetAll();
        }
        /// <summary>
        /// isValid Değeri TRUE olan entry listesindeki veri adeti
        /// </summary>
        /// <returns>0,1,2,3,4...</returns>
        public int ActiveEntryCount()
        {
            return ActiveEntryCount();
        }
        /// <summary>
        /// Active Entry Take List
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<Entry> ActiveEntryMost()
        {
            return _entryRepository.ActiveEntryGetAll();
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
    }
}
