using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IAssetAssignmentRepository : IRepository<AssetAssignment>
{
    Task<AssetAssignment?> GetActiveAssignmentAsync(Guid assetId, CancellationToken cancellationToken);

    Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(Guid employeeId, CancellationToken cancellationToken);

    Task<IEnumerable<AssetAssignment>> GetAllActiveAssignmentAsync(CancellationToken cancellationToken);
}