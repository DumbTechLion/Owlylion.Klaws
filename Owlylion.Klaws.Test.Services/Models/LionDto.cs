using System;
using Owlylion.Klaws.Core;

namespace Owlylion.Klaws.Test.Services.Models
{
    public class LionDto : IKeyedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int PackId { get; set; }

        public object GetKey()
        {
            return Id;
        }
    }
}
