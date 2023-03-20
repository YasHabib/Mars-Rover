using Mars_Rover.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        private IRoverRepository _roverRepository;

        public IRoverRepository Rovers
        {
            get
            {
                if (_roverRepository == null)
                    _roverRepository = new RoverRepository(_dbContext);
                return _roverRepository;
            }
        }

        public UnitOfWork(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
