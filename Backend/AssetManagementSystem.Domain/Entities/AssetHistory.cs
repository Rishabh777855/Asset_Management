using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Domain.Entities;

public class AssetHistory
{
    public Guid Id { get; set; }

    public Guid AssetId { get; set; }

    public AssetHistoryType HistoryType { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateOnly ActionDate { get; set; }

    public string? Remarks { get; set; }

    public Asset Asset { get; set; } = null!;

    public Employee? Employee { get; set; }
}