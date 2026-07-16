namespace AssetManagementSystem.Application.DTOs;

public class AssetHistoryResponseDto
{
    public Guid Id { get; set; }

    public string AssetCode { get; set; } = string.Empty;

    public string AssetName { get; set; } = string.Empty;

    public string HistoryType { get; set; } = string.Empty;

    public string? EmployeeName { get; set; }

    public DateOnly ActionDate { get; set; }

    public string? Remarks { get; set; }
}