using Parakeet.Data.Entities;
using System.Collections.Generic;
using System;
using Parakeet.Services.Models;

namespace Parakeet.Services
{
    public interface IPositionService
    {
        List<Position> Find(string searchString);
        bool Save(Position person);
    }

    public class PositionService : IPositionService
    {
        public List<Position> Find(string searchString)
        {
            throw new NotImplementedException();
        }

        public bool Save(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
