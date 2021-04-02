using Platform.Dal.Abstract;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    public class EfEntryRepository : EfGenericRepository<Entry>, IEntryRepository
    {
        public EfEntryRepository() : base()
        {

        }

        public List<Entry> ActiveEntryGetAll()
        {
            return _context.Entries.Where(x => x.IsValid == true).ToList();
        }

        public List<Entry> OldToNewEntryGetAll()
        {
            return _context.Entries.OrderBy(x => x.EntryDate).ToList();
        }

        public List<Entry> PastHistoryEntryGetAll(DateTime dateTime)
        {
            return _context.Entries.Where(x => x.EntryDate == dateTime).ToList();
        }

        public List<Entry> TodayEntryGetAll()
        {
            return _context.Entries.Where(x => x.EntryDate == DateTime.Now).ToList();
        }
    }
}
