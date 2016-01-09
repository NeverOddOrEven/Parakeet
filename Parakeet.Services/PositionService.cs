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
            return new List<Position>()
            {
                new Position {Title="Test1", Description="Test1Description" },
                new Position {Title="Test2", Description="Test2Description" },
            };
        }

        public bool Save(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
