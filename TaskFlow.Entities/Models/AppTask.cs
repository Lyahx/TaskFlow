namespace TaskFlow.Entities.Models;

public class AppTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public string Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}