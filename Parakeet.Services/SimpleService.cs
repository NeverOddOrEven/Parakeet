using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Services
{
    public interface ISimpleService
    {

    }

    public class SimpleService : ISimpleService
    {
        public SimpleService()
        {
            Console.WriteLine("Init...");
        }
    }
}
