using System.ComponentModel.DataAnnotations;
using TaskStatus = TaskManagementSystem.Models.Enums.TaskStatus;
using TaskPriority = TaskManagementSystem.Models.Enums.TaskPriority;

namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Provide the Title of the task")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title should be greater than 3 Characters and less than 50 Characters")]
        public string Title { get; set; } = null!;

        [StringLength(100, MinimumLength = 4, ErrorMessage = "Description should be greater than 4 Characters and less than 100 Characters")]
        public string? Description { get; set; }

        public TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? DueDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReminderDateTime { get; set; }

        public bool IsCompleted { get; set; } = false;

        [Required(ErrorMessage = "Provide the Task created date and time")]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UserId { get; set; } = null!;
    }
}
