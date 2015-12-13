﻿using System;

namespace Parakeet.Ui.Model
{
    [Serializable]
    public class Employee
    {
        public Employee()
        {
            Position = new Position();
        }

        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime SeparationDate { get; set; }

        public Position Position { get; set; }
    }
}