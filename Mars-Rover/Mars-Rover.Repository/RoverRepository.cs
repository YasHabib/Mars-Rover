using Mars_Rover.Models.Entities;
using Mars_Rover.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Repository
{
    public class RoverRepository : BaseRepository<Rover, Guid,ApplicationDBContext>, IRoverRepository
    {
        private readonly ApplicationDBContext _context;
        public RoverRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }
    }
}
