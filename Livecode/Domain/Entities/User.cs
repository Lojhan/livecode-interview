namespace Livecode.Domain.Entities;

public class User(
    int Id,
    string Name,
    DateTime CreatedAt
)
{   
    public int Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public DateTime CreatedAt { get; set; } = CreatedAt;
}