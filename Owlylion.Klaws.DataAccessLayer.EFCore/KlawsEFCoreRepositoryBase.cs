using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Owlylion.Klaws.Core;
using Owlylion.Klaws.DataAccessLayer.Repositories;

namespace Owlylion.Klaws.DataAccessLayer.EFCore
{
    public abstract class KlawsEfCoreRepositoryBase<TModel, TEntity, TContext> : IKlawsRepository<TModel>
        where TModel : class, IKeyedObject, new()
        where TEntity : class, IKeyedObject, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> DbSet;

        protected KlawsEfCoreRepositoryBase(TContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            DbSet = context.Set<TEntity>();
        }

        protected async Task AddEntity(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        protected async Task<TEntity> GetEntity(object key)
        {
            return await DbSet.FindAsync(key);
        }

        protected async Task<ICollection<TEntity>> ListEntities(int page, int perPage)
        {
            return await DbSet
                .Skip(page * perPage)
                .Take(perPage)
                .ToListAsync();
        }

        protected async Task UpdateEntity(TEntity entity)
        {
            DbSet.Update(entity);
            await Task.CompletedTask;
        }

        protected async Task RemoveEntity(object key)
        {
            TEntity entity = await GetEntity(key);
            if (entity == null)
                return;

            DbSet.Remove(entity);
        }

        public async Task Add(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            await AddEntity(entity);
        }

        public async Task<TModel> Get(object key)
        {
            TEntity entity = await GetEntity(key);
            return Mapper.Map<TModel>(entity);
        }

        public async Task<ICollection<TModel>> List(int page, int perPage)
        {
            ICollection<TEntity> list = await ListEntities(page, perPage);

            return Mapper
                .ProjectTo<TModel>(list.AsQueryable())
                .ToList();
        }

        public async Task Update(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            await UpdateEntity(entity);
        }

        public async Task Remove(object key)
        {
            await RemoveEntity(key);
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
