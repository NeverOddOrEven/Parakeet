using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Model
{
    [Serializable]
    public class Position
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
