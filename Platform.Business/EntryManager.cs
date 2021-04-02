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
    public class EntryManager : GenericManager<Entry>, IEntryService
    {
        IEntryRepository _entryRepository;

        public EntryManager(IEntryRepository entryRepository) : base(entryRepository)
        {
            _entryRepository = entryRepository;
        }
    }
}
