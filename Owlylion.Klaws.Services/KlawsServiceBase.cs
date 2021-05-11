using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Owlylion.Klaws.Core;
using Owlylion.Klaws.DataAccessLayer.Exceptions;
using Owlylion.Klaws.DataAccessLayer.Repositories;
using Owlylion.Klaws.Services.Interfaces;
using Owlylion.Klaws.Services.Models;

namespace Owlylion.Klaws.Services
{
    public class KlawsServiceBase<TDataTransferObject, TModel> : IKlawsService<TDataTransferObject>
        where TDataTransferObject : class, IKeyedObject, new()
        where TModel : class, IKeyedObject, new()
    {
        protected readonly IKlawsRepository<TModel> Repository;
        protected readonly IMapper Mapper;

        public KlawsServiceBase(IKlawsRepository<TModel> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<TDataTransferObject> Get(object key)
        {
            TModel model = await Repository.Get(key);
            return Mapper.Map<TDataTransferObject>(model);
        }

        public async Task<PaginatedResult<TDataTransferObject>> List(int page, int perPage)
        {
            ICollection<TModel> modelList = await Repository.List(page, perPage);
            ICollection<TDataTransferObject> dtoList = modelList
                .Select(m => Mapper.Map<TDataTransferObject>(m))
                .ToArray();
            
            return new PaginatedResult<TDataTransferObject>()
            {
                Page = page,
                PerPage = perPage,
                List = dtoList
            };
        }

        public async Task<TDataTransferObject> Create(TDataTransferObject dto)
        {
            var model = Mapper.Map<TModel>(dto);
            await Repository.Add(model);
            return Mapper.Map<TDataTransferObject>(model);
        }

        public async Task<TDataTransferObject> Put(TDataTransferObject dto)
        {
            var model = Mapper.Map<TModel>(dto);
            await Repository.Update(model);
            return Mapper.Map<TDataTransferObject>(model);
        }

        public async Task<TDataTransferObject> Patch(object key, JsonPatchDocument<TDataTransferObject> dtoPatch)
        {
            TModel model = await Repository.Get(key);
            if (model == null)
                throw new EntityNotFoundException($"Entity with Key {key} not found");

            var dto = Mapper.Map<TDataTransferObject>(model);

            dtoPatch.ApplyTo(dto);
            var updatedModel = Mapper.Map<TModel>(dto);

            await Repository.Update(updatedModel);
            return dto;
        }

        public async Task Delete(object key)
        {
            TModel model = await Repository.Get(key);
            if (model == null)
                throw new EntityNotFoundException($"Entity with Key {key} not found");

            await Repository.Remove(key);
            await Repository.Save();
        }
    }
}
