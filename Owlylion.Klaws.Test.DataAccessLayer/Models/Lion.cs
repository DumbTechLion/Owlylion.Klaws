using System;
using Owlylion.Klaws.Core;

namespace Owlylion.Klaws.Test.DataAccessLayer.Models
{
    public class Lion : IKeyedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        /* References */
        public int PackId { get; set; }

        public object GetKey()
        {
            return Id;
        }
    }
}
