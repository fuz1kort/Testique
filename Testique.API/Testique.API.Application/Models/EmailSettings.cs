namespace Testique.API.Application.Models;

public class EmailSettings
{
    public string FromEmail { get; set; } = default!;
    public string FromName { get; set; } = default!;
    public string Host { get; set; } = default!;
    public int Port { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}