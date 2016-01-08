using Parakeet.Data.Entities;
using System.Collections.Generic;
using System;

namespace Parakeet.Services
{
    public interface IRoleService
    {
        List<Role> Find(string searchString);
        bool Save(Role person);
    }

    public class RoleService : IRoleService
    {
        public List<Role> Find(string searchString)
        {
            throw new NotImplementedException();
        }

        public bool Save(Role person)
        {
            throw new NotImplementedException();
        }
    }
}
