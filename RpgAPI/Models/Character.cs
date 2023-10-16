using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RpgAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public RpgClass RpgClass { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Weapon? Weapon { get; set; }

    }
}
