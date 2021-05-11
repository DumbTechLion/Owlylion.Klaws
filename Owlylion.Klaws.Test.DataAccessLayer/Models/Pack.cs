using System.Collections.Generic;
using Owlylion.Klaws.Core;

namespace Owlylion.Klaws.Test.DataAccessLayer.Models
{
    public class Pack : IKeyedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<int> MemberIds { get; set; }
        public ICollection<Lion> Members { get; set; }

        public object GetKey()
        {
            return Id;
        }
    }
}
