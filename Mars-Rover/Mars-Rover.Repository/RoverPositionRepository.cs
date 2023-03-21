using Mars_Rover.Models.Entities;
using Mars_Rover.Models.Objects;
using Mars_Rover.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Repository
{
    public class RoverPositionRepository: BaseRepository<RoverPosition, Guid, ApplicationDBContext>, IRoverPositionRepository
    {
        private readonly ApplicationDBContext _context;
        public RoverPositionRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
