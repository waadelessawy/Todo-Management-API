using Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public ToDoStatus Status { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public ToDoItem(string title, string? description, PriorityLevel priority, DateTime? dueDate)
        {
            Id = Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title));
            if (title.Length > 100) throw new ArgumentException("Title too long");
            Description = description;
            Status = ToDoStatus.Pending;
            Priority = priority;
            DueDate = dueDate;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = CreatedDate;
        }

        public void Update(string title, string? description, ToDoStatus status, PriorityLevel priority, DateTime? dueDate)
        {
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            DueDate = dueDate;
            LastModifiedDate = DateTime.UtcNow;
        }
        

    }
}
