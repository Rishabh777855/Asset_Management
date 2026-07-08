namespace AssetManagementSystem.Application.DTOs;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;

    public string EmployeeName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}