using Money_Manager.Models;

namespace Entities.Models
{
    public class Operation : BaseModel
    {
        public required Guid OperationTypeId { get; set; }  
        public OperationType? OperationType { get; set; }
        public required DateTime Date { get; set; }
        public required Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public required Guid AccountId { get; set; }
        public Account? Account { get; set; }
        public required decimal Amount { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
    }
}
