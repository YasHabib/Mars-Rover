using Mars_Rover.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Repository.Interfaces
{
    public interface IRoverPositionRepository: IBaseRepository<RoverPosition, Guid>
    {
    }
}
