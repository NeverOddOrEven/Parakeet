using Parakeet.Data.Entities;
using Parakeet.Data.Repositories;

namespace Parakeet.Ui.Design
{
    class PeopleRepository : Repository<Person>, IPeopleRepository
    {
        public PeopleRepository()
        {

        }
    }
}
