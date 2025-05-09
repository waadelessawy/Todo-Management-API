using Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UpdateToDoItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public ToDoStatus Status { get; private set; }
        public PriorityLevel Priority { get; private set; }
        public DateTime? DueDate { get; private set; }
    }
}
