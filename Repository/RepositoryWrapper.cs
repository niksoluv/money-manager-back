using Contracts;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _context;
        private ILogger _logger;
        private IUserRepository _user;
        private IAccountRepository _account;
        private IAccountGroupRepository _accountGroup;
        private ICurrencyRepository _currency;
        private ICategoryRepository _category;
        private IOperationTypeRepository _operationType;
        private IOperationRepository _operation;

        public IUserRepository User
        {
            get
            {
                _user ??= new UserRepository(_context, _logger);
                return _user;
            }
        }
        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_context, _logger);
                }
                return _account;
            }
        }
        public IAccountGroupRepository AccountGroup
        {
            get
            {
                if (_accountGroup == null)
                {
                    _accountGroup = new AccountGroupRepository(_context, _logger);
                }
                return _accountGroup;
            }
        }
        public ICurrencyRepository Currency
        {
            get
            {
                if(_currency == null)
                {
                    _currency = new CurrencyRepository(_context, _logger);
                }
                return _currency;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if( _category == null)
                {
                    _category = new CategoryRepository(_context, _logger);
                }
                return _category;
            }
        }
        public IOperationTypeRepository OperationType
        {
            get
            {
                if( _operationType == null)
                {
                    _operationType = new OperationTypeRepository(_context, _logger);
                }
                return _operationType;
            }
        }
        public IOperationRepository Operation
        {
            get
            {
                if( (_operation == null))
                {
                    _operation = new OperationRepository(_context, _logger);
                }
                return _operation;
            }
        }
        public RepositoryWrapper(
            ApplicationContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} RemoveFromList method error", typeof(RepositoryWrapper));
                return false;
            }
        }
    }
}
