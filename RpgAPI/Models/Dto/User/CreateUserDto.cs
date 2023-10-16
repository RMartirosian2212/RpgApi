namespace RpgAPI.Models.Dto.User
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public List<int>? CharactersIds { get; set; }

    }
}
