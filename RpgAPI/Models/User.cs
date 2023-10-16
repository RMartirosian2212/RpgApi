using System.ComponentModel.DataAnnotations;

namespace RpgAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<Character>? Characters { get; set; }
    }
}
