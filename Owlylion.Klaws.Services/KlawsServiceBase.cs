using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Owlylion.Klaws.Core;
using Owlylion.Klaws.DataAccessLayer.Repositories;

namespace Owlylion.Klaws.Services
{
    public class KlawsServiceBase<TDto, TModel> : IKlawsService<TDto>
        where TDto : class, new()
        where TModel : class, new()
    {
        protected readonly IKlawsRepository<TModel> Repository;
        protected readonly IMapper Mapper;

        public KlawsServiceBase(IKlawsRepository<TModel> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task Add(TDto dto)
        {
            var model = Mapper.Map<TModel>(dto);
            await Repository.Add(model);
        }

        public async Task<TDto> Get(object key)
        {
            TModel model = await Repository.Get(key);
            return Mapper.Map<TDto>(model);
        }

        public Task Update(object key, Patch<TDto> patch)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(object key)
        {
            await Repository.Remove(key);
        }
    }
}
