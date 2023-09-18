using Money_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category : BaseModel
    {
        public required string Name { get; set; } = string.Empty;
    }
}
