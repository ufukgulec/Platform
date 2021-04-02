using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    /// <summary>
    /// Kullandığı inteface => IGenericService
    /// </summary>
    public interface IPersonService : IGenericService<Person>
    {

    }
}
