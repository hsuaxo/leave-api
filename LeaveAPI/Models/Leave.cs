using System;

namespace LeaveAPI.Models
{
    public class Leave
    {
        public int? Id { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public int TypeId { get; set; }

        public LeaveType Type { get; set; }

        public DateTime Date { get; set; }
    }
}
