using System.Collections.Generic;
using System.Threading.Tasks;
using Owlylion.Klaws.Core;

namespace Owlylion.Klaws.DataAccessLayer.Repositories
{
    public interface IKlawsRepository<TModel> 
        where TModel : class, IKeyedObject, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Add(TModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TModel> Get(object key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        Task<ICollection<TModel>> List(int page, int perPage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Update(TModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task Remove(object key);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task Save();
    }
}
