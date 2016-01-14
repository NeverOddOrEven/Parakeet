using System;

namespace Parakeet.Services.Models
{
    [Serializable]
    public class Skill
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
