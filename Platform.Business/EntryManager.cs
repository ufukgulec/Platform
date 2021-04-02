using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// IsValid değeri TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns></returns>
        public List<Entry> ActiveEntryGetAll()
        {
            return _entryRepository.ActiveEntryGetAll();
        }
        /// <summary>
        /// Eskiden Yeniye Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        public List<Entry> OldToNewEntryGetAll()
        {
            return _entryRepository.OldToNewEntryGetAll();
        }
        /// <summary>
        /// Belli bir tarihteki Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        public List<Entry> PastHistoryEntryGetAll(DateTime dateTime)
        {
            return _entryRepository.PastHistoryEntryGetAll(dateTime);
        }
        /// <summary>
        /// Bugünkü Entry Listesi
        /// </summary>
        /// <returns>List<Entry></returns>
        public List<Entry> TodayEntryGetAll()
        {
            return _entryRepository.TodayEntryGetAll();
        }
    }
}
