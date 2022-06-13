using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beetee_Task.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Birth { get; set; }

        public Gender Gender { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        
        public HR_Data HR_Data { get; set; }

        public State State { get; set; }

    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }

    public enum State
    { 
        Active,
        Inactive
    }
}