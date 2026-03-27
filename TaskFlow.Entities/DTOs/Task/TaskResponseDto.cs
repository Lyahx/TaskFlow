namespace TaskFlow.Entities.DTOs.Task;

public class TaskResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public bool IsCompleted { get; set; }
    
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
}