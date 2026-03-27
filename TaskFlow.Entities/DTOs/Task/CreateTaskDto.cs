namespace TaskFlow.Entities.DTOs.Task;

public class CreateTaskDto
{
 public string Title { get; set; }
 public string Description { get; set; }
 public string Priority { get; set; }
 public DateTime? DueDate { get; set; }
}