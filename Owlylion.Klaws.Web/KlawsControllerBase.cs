using Microsoft.AspNetCore.Mvc;
using Owlylion.Klaws.Services;
using Owlylion.Klaws.Web.Interfaces;
using Owlylion.Klaws.Web.Models;

namespace Owlylion.Klaws.Web
{
    public abstract class KlawsControllerBase<TModel, TCreateDto> : ControllerBase, IKlawsController<TModel>
        where TModel : class, new()
        where TCreateDto : CreateDto<TModel>, new()
    {
        protected readonly IKlawsService<TModel> Service;

        protected KlawsControllerBase(IKlawsService<TModel> service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("{key}")]
        public IActionResult Get([FromRoute] object key)
        {
            return null;
        }

        [HttpGet]
        public IActionResult Create([FromBody] TCreateDto model)
        {
            Service.
        }
    }

    public class Lol
    {

    }

    public class con : KlawsControllerBase<Lol>
    {
        public con(IKlawsService<Lol> service) : base(service)
        {
        }
    }

}
