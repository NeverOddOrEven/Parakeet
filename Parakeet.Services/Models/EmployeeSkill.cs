using System;

namespace Parakeet.Services.Models
{
    [Serializable]
    public class EmployeeSkill
    {
        public long? Id { get; set; }
        public Skill Skill { get; set; }
        public Employee Employee { get; set; }
        public DateTime Acquired { get; set; }
        public DateTime Expires { get; set; }
        public string Notes { get; set; }
    }
}
