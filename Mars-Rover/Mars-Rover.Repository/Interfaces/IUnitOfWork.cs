using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRoverRepository Rovers { get; }

        Task SaveAsync();
    }
}
