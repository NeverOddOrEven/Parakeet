using Parakeet.Data.Entities;
using System.Collections.Generic;
using System;
using Parakeet.Services.Models;
using Parakeet.Data.Repositories;
using Parakeet.Services.Mappers;
using System.Linq;

namespace Parakeet.Services
{
    public interface IPositionService
    {
        List<Position> Find(string searchString);
        bool Save(Position person);
    }

    public class PositionService : IPositionService
    {
        private IRoleRepository _roleRepository;

        public PositionService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Position> Find(string searchString)
        {
            var results = _roleRepository.Where(x => x.Name.Contains(searchString));

            return results.Select(PositionMapper.ToModel).ToList();
        }

        public bool Save(Position position)
        {
            var entity = PositionMapper.ToEntity(position);

            if (entity.Id != null)
            {
                _roleRepository.Update(entity);
                return true;
            }

            _roleRepository.Add(entity);
            return true;
        }
    }
}
