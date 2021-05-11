using System.Collections.Generic;

namespace Owlylion.Klaws.Services.Models
{
    public class PaginatedResult<TObject>
        where TObject : class, new()
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public ICollection<TObject> List { get; set; }
    }
}
