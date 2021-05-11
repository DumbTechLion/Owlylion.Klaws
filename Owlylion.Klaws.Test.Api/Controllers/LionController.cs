using Owlylion.Klaws.Test.Services.Interfaces;
using Owlylion.Klaws.Test.Services.Models;
using Owlylion.Klaws.Web.Controllers;

namespace Owlylion.Klaws.Test.Api.Controllers
{
    public class LionController : KlawsControllerBase<LionDto>
    {
        public LionController(ILionService service)
            : base(service)
        {
        }
    }
}
