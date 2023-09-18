using Entities.Models;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;

namespace Repository
{
    internal class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context, ILogger logger)
            :base(context, logger)
        {
            
        }
    }
}
