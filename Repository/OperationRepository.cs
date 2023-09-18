using Entities.Models;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;

namespace Repository
{
    internal class OperationRepository : RepositoryBase<Operation>, IOperationRepository
    {
        public OperationRepository(ApplicationContext context, ILogger logger)
            : base(context, logger)
        {

        }
        public override async Task<bool> Create(Operation operation)
        {
            var operationType = _context.OperationTypes.Where(ot=>ot.Id==operation.OperationTypeId).FirstOrDefault();
            try
            {
                switch (operationType.OperationName)
                {
                    case nameof(DefaultOperationTypes.Income):
                        {
                            await _context.Operations.AddAsync(operation);
                            Account account = _context.Accounts.Where(a => a.Id == operation.AccountId).FirstOrDefault();
                            account.TotalAmount += operation.Amount;
                            _context.Accounts.Update(account);
                            break;
                        }
                    case nameof(DefaultOperationTypes.Expence):
                        {
                            await _context.Operations.AddAsync(operation);
                            Account account = _context.Accounts.Where(a => a.Id == operation.AccountId).FirstOrDefault();
                            account.TotalAmount -= operation.Amount;
                            _context.Accounts.Update(account);
                            break;
                        }
                    case nameof(DefaultOperationTypes.Transfer):
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{OperationRepository} Create method error", typeof(OperationRepository));
                return false;
            }
        }
        public override bool Update(Operation operation)
        {

            try
            {
                switch (operation.OperationType.OperationName)
                {
                    case nameof(DefaultOperationTypes.Income):
                        {
                            _context.Operations.Remove(operation);
                            Account account = _context.Accounts.Where(a => a.Id == operation.AccountId).FirstOrDefault();
                            account.TotalAmount -= operation.Amount;
                            _context.Accounts.Update(account);
                            break;
                        }
                    case nameof(DefaultOperationTypes.Expence):
                        {
                            _context.Operations.Remove(operation);
                            Account account = _context.Accounts.Where(a => a.Id == operation.AccountId).FirstOrDefault();
                            account.TotalAmount += operation.Amount;
                            _context.Accounts.Update(account);
                            break;
                        }
                    case nameof(DefaultOperationTypes.Transfer):
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{OperationRepository} Create method error", typeof(OperationRepository));
                return false;
            }
        }
        public override bool Delete(Operation operation)
        {
            try
            {
                //switch(operation.OperationType.)
                switch (operation.OperationType.OperationName)
                {
                    case nameof(DefaultOperationTypes.Income):
                        {
                            _context.Operations.Remove(operation);
                            Account account = _context.Accounts.Where(a => a.Id == operation.AccountId).FirstOrDefault();
                            account.TotalAmount -= operation.Amount;
                            _context.Accounts.Update(account);
                            break;
                        }
                    case nameof(DefaultOperationTypes.Expence):
                        {
                            _context.Operations.Remove(operation);
                            Account account = _context.Accounts.Where(a => a.Id == operation.AccountId).FirstOrDefault();
                            account.TotalAmount += operation.Amount;
                            _context.Accounts.Update(account);
                            break;
                        }
                    case nameof(DefaultOperationTypes.Transfer):
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{OperationRepository} Create method error", typeof(OperationRepository));
                return false;
            }
        }
    }
}
