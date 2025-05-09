using Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CreateToDoItem
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
