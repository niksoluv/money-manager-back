using System.ComponentModel.DataAnnotations;

namespace Money_Manager.Models
{
    public class Currency: BaseModel
    {
        [Required]
        public string CurrencyName { get; set; } = string.Empty;
    }
}
