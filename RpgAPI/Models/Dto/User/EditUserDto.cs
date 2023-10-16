namespace RpgAPI.Models.Dto.User
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<int>? CharactersIds { get; set; }
    }
}
