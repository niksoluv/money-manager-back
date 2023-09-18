using Entities.Models;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;

namespace Repository
{
    internal class OperationTypeRepository : RepositoryBase<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(ApplicationContext context, ILogger logger)
            :base(context, logger)
        {
            
        }
    }
}
