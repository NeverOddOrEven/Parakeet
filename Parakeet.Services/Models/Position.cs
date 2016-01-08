using System;

namespace Parakeet.Services.Models
{
    [Serializable]
    public class Position
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
