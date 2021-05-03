using AutoMapper;

namespace Owlylion.Klaws.Services.Models
{
    public abstract class CreateDto<TModel>
    {
        public TModel MapToModel(IMapper mapper)
        {
            return mapper.Map<TModel>(this);
        }
    }
}
