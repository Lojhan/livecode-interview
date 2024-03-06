namespace Livecode.Domain.Entities;

public class Client(
    int Id,
    string Name,
    string Email,
    int UserId
)
{
    public int Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public string Email { get; set; } = Email;
    public int UserId { get; set; } = UserId;
}