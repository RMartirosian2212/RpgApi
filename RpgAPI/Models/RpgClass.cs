using System.ComponentModel.DataAnnotations.Schema;

namespace RpgAPI.Models
{
    public class RpgClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
