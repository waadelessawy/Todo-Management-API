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
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public ToDoStatus Status { get; private set; }
        public PriorityLevel Priority { get; private set; }
        public DateTime? DueDate { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

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
