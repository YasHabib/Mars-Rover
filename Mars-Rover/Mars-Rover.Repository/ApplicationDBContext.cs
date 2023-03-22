using Mars_Rover.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Repository
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            :base(options)
        {
            
        }

        public DbSet<Rover> Rovers => Set<Rover>();
        public DbSet<RoverPosition> RoverPositions => Set<RoverPosition>();
    }
}
