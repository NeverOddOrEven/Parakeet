using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Services
{
    public interface ISimpleServiceTwo {

    }

    public class SimpleServiceTwo : ISimpleServiceTwo
    {
        private ISimpleService SimpleService; 

        public SimpleServiceTwo(ISimpleService simpleService) {
            this.SimpleService = simpleService;
        }
    }
}
