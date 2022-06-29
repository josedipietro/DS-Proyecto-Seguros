using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;
using Administrador.BussinesLogic.DTOs;

namespace Administrador.Persistence.DAOs
{
    public class PolicyDAO : IPolicyDAO
    {
        private readonly IAdministradorDbContext _context;

        public PolicyDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<Policy?> GetPolicy(Guid id)
        {
            return await _context.Policies
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Policy>> GetPolicies(Guid? vehicleId, EnumPolicyType? policyType)
        {
            return await _context.Policies
                .Where(
                    e =>
                        (e.IsActive == true)
                        && (vehicleId.HasValue ? e.VehicleId == vehicleId : true)
                        && (policyType.HasValue ? e.PolicyType == policyType : true)
                )
                .ToListAsync();
        }

        // Delete (Change IsActive to false)
        public async Task<Policy> DeletePolicy(Policy policy)
        {
            policy.IsActive = false;
            await _context.SaveChangesAsync();
            return policy;
        }

        // Create
        public async Task<Policy> CreatePolicy(PolicyDTO policyDTO)
        {
            // Verify if the vehicle exists
            var vehicle = await _context.Vehicles
                .Where(b => (b.IsActive == true) && (b.Id == policyDTO.VehicleId))
                .FirstOrDefaultAsync();
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found");
            }

            // If Exists Another Policy with the same VehicleId and expiredDate is null, modify it and set the expiredDate to the current date
            var policy = await _context.Policies
                .Where(
                    e =>
                        (e.IsActive == true)
                        && (e.VehicleId == policyDTO.VehicleId)
                        && (e.EndDate == null)
                )
                .FirstOrDefaultAsync();
            if (policy != null)
            {
                policy.EndDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            // create a new policy
            policy = new Policy
            {
                Id = Guid.NewGuid(),
                PolicyType = policyDTO.PolicyType,
                StartDate = DateTime.Now,
                VehicleId = policyDTO.VehicleId,
                EndDate = null,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return policy;
        }
    }
}
