using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    public interface IEntryService : IGenericService<Entry>
    {
        /// <summary>
        /// IsValid değeri TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        List<Entry> ActiveEntryGetAll();
        /// <summary>
        /// Bugünkü Entry Listesi
        /// </summary>
        /// <returns>List<Entry></returns>
        List<Entry> TodayEntryGetAll();
        /// <summary>
        /// Belli bir tarihteki Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        List<Entry> PastHistoryEntryGetAll(DateTime dateTime);
        /// <summary>
        /// Eskiden Yeniye Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        List<Entry> OldToNewEntryGetAll();
    }
}
