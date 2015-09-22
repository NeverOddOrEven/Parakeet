using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Data.Repositories
{
    public class RepositoryCache
    {
        private IPeopleRepository _peopleRepository { get; set; }
        public IPeopleRepository PeopleRepository { get { return _peopleRepository; } } 

        public RepositoryCache()
        {
            _peopleRepository = new PeopleRepository();
        }
    }
}
