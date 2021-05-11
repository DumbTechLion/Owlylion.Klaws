using System.Collections.Generic;
using Owlylion.Klaws.Core;

namespace Owlylion.Klaws.Test.DataAccessLayer.EfCore.Models
{
    public class PackEntity : IKeyedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<int> MemberIds { get; set; }
        public ICollection<LionEntity> Members { get; set; }

        public object GetKey()
        {
            return Id;
        }
    }
}
