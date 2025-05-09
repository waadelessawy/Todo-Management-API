using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class ResponseObject
    {
        public Object Data { get; set; }

        public bool Success { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
