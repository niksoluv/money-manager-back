using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;

namespace Repository
{
    internal class CurrencyRepository: RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationContext context, ILogger logger)
            :base(context, logger)
        {
            
        }
    }
}
