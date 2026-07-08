namespace AssetManagementSystem.Application.DTOs.Common;

public class ErrorResponseDto
{
    public int StatusCode {get; set;}

    public string Message {get; set;}

    public DateTime TimeStamp {get; set;} = DateTime.UtcNow;
}