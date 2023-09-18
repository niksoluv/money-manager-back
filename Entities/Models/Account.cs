using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Money_Manager.Models
{
    public class Account : BaseModel
    {
        public required string AccountName { get; set; } = string.Empty;
        public required Guid AccountGroupId { get; set; }
        public AccountGroup? AccountGroup { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public required Guid? CurrencyId { get; set; }
        public Currency? Currency { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
