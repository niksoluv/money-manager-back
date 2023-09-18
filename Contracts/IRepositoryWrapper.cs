using Money_Manager.Repository;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAccountRepository Account { get; }
        IAccountGroupRepository AccountGroup { get; }
        ICurrencyRepository Currency { get; }
        ICategoryRepository Category { get; }
        IOperationTypeRepository OperationType { get; }
        IOperationRepository Operation { get; }
        Task<bool> SaveAsync();
    }
}
