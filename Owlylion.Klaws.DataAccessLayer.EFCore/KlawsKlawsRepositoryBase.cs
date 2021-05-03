using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Owlylion.Klaws.Core;
using Owlylion.Klaws.DataAccessLayer.Repositories;

namespace Owlylion.Klaws.DataAccessLayer.EFCore
{
    public abstract class KlawsKlawsRepositoryBase<TEntity, TContext> : IKlawsRepository<TEntity> 
        where TEntity : class, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected KlawsKlawsRepositoryBase(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity model)
        {
            await DbSet.AddAsync(model);
        }

        public async Task<TEntity> Get(object key)
        {
            return await DbSet.FindAsync(key);
        }

        public async Task Update(object key, Patch<TEntity> patch)
        {
            TEntity entity = await Get(key);
            patch.ApplyTo(entity);
        }

        public async Task Remove(object key)
        {
            TEntity model = await Get(key);
            if (model == null)
                return;

            DbSet.Remove(model);
        }
    }
}
