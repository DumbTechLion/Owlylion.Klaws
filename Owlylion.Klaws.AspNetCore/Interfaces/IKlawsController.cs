using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Owlylion.Klaws.Core;
using Owlylion.Klaws.Services.Models;

namespace Owlylion.Klaws.Web.Interfaces
{
    public interface IKlawsController<TDataTransferObject>
        where TDataTransferObject : class, IKeyedObject, new()
    {
        Task<ActionResult<TDataTransferObject>> Get(object key);

        Task<ActionResult<PaginatedResult<TDataTransferObject>>> List(int page, int perPage);

        Task<ActionResult<TDataTransferObject>> Create(TDataTransferObject dto);

        Task<ActionResult<TDataTransferObject>> Put(TDataTransferObject dto);

        Task<ActionResult<TDataTransferObject>> Patch(object key, JsonPatchDocument<TDataTransferObject> dtoPatch);

        Task<IActionResult> Delete(object key);
    }
}
