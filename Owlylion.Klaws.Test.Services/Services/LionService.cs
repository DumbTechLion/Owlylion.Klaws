using AutoMapper;
using Owlylion.Klaws.DataAccessLayer.Repositories;
using Owlylion.Klaws.Services;
using Owlylion.Klaws.Test.DataAccessLayer.Models;
using Owlylion.Klaws.Test.Services.Interfaces;
using Owlylion.Klaws.Test.Services.Models;

namespace Owlylion.Klaws.Test.Services.Services
{
    public class LionService : KlawsServiceBase<LionDto, Lion>, ILionService
    {
        public LionService(IKlawsRepository<Lion> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
