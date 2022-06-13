using Beetee_Task.DTO.Enums;

namespace Beetee_Task.DTO
{
    public class EmployeeDataDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Birth { get; set; }

        public GenderDTO Gender { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? SecurityNumber { get; set; }
        public long Salary { get; set; }
    }
}