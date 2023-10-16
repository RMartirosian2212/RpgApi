namespace RpgAPI.Models.Dto.Character
{
    public class EditCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RpgClassId { get; set; }
        public int WeaponId { get; set; }
        public int UserId { get; set; }
    }
}
