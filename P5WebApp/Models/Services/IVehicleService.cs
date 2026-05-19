using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetAllVehicles();
        List<VehicleViewModel> GetAllVehiclesViewModel();
        Vehicle GetVehicleById(int id);
        VehicleViewModel GetVehicleByIdViewModel(int id);
        void UpdateVehicleInfos();
        void SaveVehicle(VehicleViewModel vehicle);
        void DeleteVehicle(int id);

        /// <summary>
        /// Use of a dictionnary to ease ModelState tests.
        /// </summary >
        Dictionary<string, string> CheckVehicleModelErrors(VehicleViewModel Vehicle);


        Task<Vehicle> GetVehicle(int id);
        Task<IList<Vehicle>> GetVehicle();

    }
}
