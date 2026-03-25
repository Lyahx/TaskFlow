namespace TaskFlow.Entities.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<AppTask> Tasks { get; set; }
    public ICollection<Category> Categories { get; set; }
    
}