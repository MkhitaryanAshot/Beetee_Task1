using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beetee_Task.Domain.Entities;

namespace Beetee_Task.Domain.Entities
{
    public class HR_Data
    {
        public Guid Id { get; set; }
        public string? SecurityNumber { get; set; }
        public long Salary { get; set; }

        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }

    }
}