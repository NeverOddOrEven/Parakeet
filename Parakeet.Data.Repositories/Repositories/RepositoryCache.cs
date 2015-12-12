using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Data.Repositories
{
    //
    // Until I figure out the IoC container
    //
    public class RepositoryCache
    {
        private static IPeopleRepository _peopleRepository;
        public IPeopleRepository PeopleRepository { get { return _peopleRepository ?? (_peopleRepository = new PeopleRepository()); } } 
    }
}
