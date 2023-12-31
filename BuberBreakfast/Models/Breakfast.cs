using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BuberBreakfast.Models
{
    public class Breakfast
    {
        public Guid Id { get; }

        public string Name { get; }
        public string Description { get; }

        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime LastModificationDate { get; }
        public List<string> Savory { get; }
        public List<string> Sweet { get; }

        public Breakfast(
            Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModificationDate, List<string> savory, List<string> sweet
        )
        {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModificationDate = lastModificationDate;
            Savory = savory;
            Sweet = sweet;

        }
    }
}