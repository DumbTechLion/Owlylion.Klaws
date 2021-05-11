using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Owlylion.Klaws.Services.Models;

namespace Owlylion.Klaws.Services.Interfaces
{
    public interface IKlawsService<TDataTransferObject>
        where TDataTransferObject : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TDataTransferObject> Get(object key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        public Task<PaginatedResult<TDataTransferObject>> List(int page, int perPage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<TDataTransferObject> Create(TDataTransferObject dto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<TDataTransferObject> Put(TDataTransferObject dto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtoPatch"></param>
        /// <returns></returns>
        public Task<TDataTransferObject> Patch(object key, JsonPatchDocument<TDataTransferObject> dtoPatch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task Delete(object key);
    }
}
