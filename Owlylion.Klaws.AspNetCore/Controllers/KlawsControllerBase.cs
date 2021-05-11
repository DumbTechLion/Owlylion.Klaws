using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Owlylion.Klaws.Core;
using Owlylion.Klaws.Services.Interfaces;
using Owlylion.Klaws.Services.Models;
using Owlylion.Klaws.Web.Filters;
using Owlylion.Klaws.Web.Interfaces;

namespace Owlylion.Klaws.Web.Controllers
{
    [KlawsApiExceptionFilter]
    public abstract class KlawsControllerBase<TDataTransferObject> : Controller, IKlawsController<TDataTransferObject>
        where TDataTransferObject : class, IKeyedObject, new()
    {
        protected readonly IKlawsService<TDataTransferObject> Service;

        protected KlawsControllerBase(IKlawsService<TDataTransferObject> service)
        {
            Service = service;
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<TDataTransferObject>> Get([FromRoute] object key)
        {
            TDataTransferObject getDto = await Service.Get(key);
            return Ok(getDto);
        }

        [HttpGet("page/{page:int}/with/{perPage:int}")]
        public async Task<ActionResult<PaginatedResult<TDataTransferObject>>> List([FromRoute] int page, [FromRoute] int perPage)
        {
            PaginatedResult<TDataTransferObject> paginatedResult = await Service.List(page, perPage);
            return Ok(paginatedResult);
        }

        [HttpPost]
        public async Task<ActionResult<TDataTransferObject>> Create([FromBody] TDataTransferObject dto)
        {
            TDataTransferObject createdDto = await Service.Create(dto);
            return Ok(createdDto);
        }

        [HttpPut]
        public async Task<ActionResult<TDataTransferObject>> Put([FromBody] TDataTransferObject dto)
        {
            TDataTransferObject putDto = await Service.Put(dto);
            return Ok(putDto);
        }

        [HttpPatch("{key}")]
        public async Task<ActionResult<TDataTransferObject>> Patch([FromRoute] object key, [FromBody] JsonPatchDocument<TDataTransferObject> dtoPatch)
        {
            TDataTransferObject dto = await Service.Patch(key, dtoPatch);
            return Ok(dto);
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete([FromRoute] object key)
        {
            await Service.Delete(key);
            return Ok();
        }
    }
}
