namespace minimalProject.Models.User
{
    public class UserResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Link { get; set; } = string.Empty;
    }
}
