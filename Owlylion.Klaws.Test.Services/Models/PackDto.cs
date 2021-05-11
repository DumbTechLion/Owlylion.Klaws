using System;
using System.Collections.Generic;
using Owlylion.Klaws.Core;

namespace Owlylion.Klaws.Test.Services.Models
{
    public class PackDto : IKeyedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<int> MemberIds { get; set; }

        public object GetKey()
        {
            return Id;
        }
    }
}
