using Microsoft.EntityFrameworkCore;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;
using Base.Exceptions;
using Administrador.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrador.Persistence.DAOs
{
    public class VehicleDAO : IVehicleDAO
    {
        private readonly IAdministradorDbContext _context;

        public VehicleDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetVehicle(Guid id)
        {
            return await _context.Vehicles
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<Vehicle?> GetVehicle(string plate)
        {
            return await _context.Vehicles
                .Where(b => (b.IsActive == true) && (b.Plate == plate))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Vehicle>> GetVehicles(
            EnumBodyworkType? bodyworkType,
            String? brandCode,
            Guid? InsuredId
        )
        {
            return await _context.Vehicles
                .Where(
                    e =>
                        (e.IsActive == true)
                        && (bodyworkType.HasValue ? e.BodyworkType == bodyworkType : true)
                        && (brandCode != null ? e.BrandCode == brandCode : true)
                        && (InsuredId.HasValue ? e.InsuredId == InsuredId : true)
                )
                .ToListAsync();
        }

        // Delete (Change IsActive to false)
        public async Task<Vehicle> DeleteVehicle(Vehicle vehicle)
        {
            vehicle.IsActive = false;
            await _context.SaveChangesAsync();
            return vehicle;
        }

        // Create
        public async Task<Vehicle> CreateVehicle(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Plate = vehicleDTO.Plate,
                Year = vehicleDTO.Year,
                SerialMotorNumber = vehicleDTO.SerialMotorNumber,
                SerialChasisNumber = vehicleDTO.SerialChasisNumber,
                Color = vehicleDTO.Color,
                BodyworkType = vehicleDTO.BodyworkType,
                InsuredId = vehicleDTO.InsuredId,
                BrandCode = vehicleDTO.BrandCode,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            };
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        // Update
        public async Task<Vehicle> UpdateVehicle(Vehicle vehicle, VehicleDTO vehicleDTO)
        {
            vehicle.Plate = vehicleDTO.Plate;
            vehicle.Year = vehicleDTO.Year;
            vehicle.SerialMotorNumber = vehicleDTO.SerialMotorNumber;
            vehicle.SerialChasisNumber = vehicleDTO.SerialChasisNumber;
            vehicle.Color = vehicleDTO.Color;
            vehicle.BodyworkType = vehicleDTO.BodyworkType;
            vehicle.InsuredId = vehicleDTO.InsuredId;
            vehicle.BrandCode = vehicleDTO.BrandCode;
            await _context.SaveChangesAsync();
            return vehicle;
        }
    }
}
