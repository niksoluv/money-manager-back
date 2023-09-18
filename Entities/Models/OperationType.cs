using Microsoft.EntityFrameworkCore;
using Money_Manager.Models;

namespace Entities.Models
{
    [PrimaryKey(nameof(OperationName))]
    public class OperationType: BaseModel
    {
        public required string OperationName { get; set; } = string.Empty;
    }
}
