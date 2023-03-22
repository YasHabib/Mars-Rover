using Mars_Rover.Models.Entities;
using Mars_Rover.Models.ViewModels;
using System.Data;

namespace Mars_Rover.Models.FrontendViewModels
{
    public class IndexViewModel
    {

        public IndexViewModel()
        {
            
        }
        //public List<RoverInputsVIewModel>? RoverInputsViewModel { get; set; }
        public IList<RoverViewModel> RoverVM { get; set; }
        //public DataTable dataTable { get; set; }
    }
}
