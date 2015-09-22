using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parakeet.Data.Entities;

namespace Parakeet.Data.Repositories
{
    public interface IPeopleRepository : IRepository<Person>
    {

    }

    public class PeopleRepository : Repository<Person>, IPeopleRepository
    {
        public PeopleRepository()
        {

        }
    }
}
