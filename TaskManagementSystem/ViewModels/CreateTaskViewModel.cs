using System.ComponentModel.DataAnnotations;
using TaskStatus = TaskManagementSystem.Models.Enums.TaskStatus;
using TaskPriority = TaskManagementSystem.Models.Enums.TaskPriority;
namespace TaskManagementSystem.ViewModels
{
    public class CreateTaskViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Title { get; set; } = null!;

        [MaxLength(100)]
        public string? Description { get; set; }

        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }

        public DateOnly? DueDate { get; set; }
        public DateTime? ReminderDateTime { get; set; }
    }
}
