using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IAssetAssignmentRepository : IRepository<AssetAssignment>
{
    Task<AssetAssignment?> GetActiveAssignmentAsync(Guid assetId);  //get each assest by id

    Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(Guid employeeId);  // get assets by employee id
}