using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IVehicleDAO
    {
        Task<Vehicle?> GetVehicle(Guid id);
        Task<Vehicle?> GetVehicle(string plate);
        Task<List<Vehicle>> GetVehicles(
            EnumBodyworkType? bodyworkType,
            string? brandCode,
            Guid? InsuredId
        );
        Task<Vehicle> DeleteVehicle(Vehicle vehicle);
        Task<Vehicle> CreateVehicle(VehicleDTO vehicleDTO);

        Task<Vehicle> UpdateVehicle(Vehicle vehicle, VehicleDTO vehicleDTO);
    }
}
