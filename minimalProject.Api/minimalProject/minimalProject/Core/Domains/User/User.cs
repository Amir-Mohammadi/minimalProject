using System.ComponentModel.DataAnnotations;

namespace minimalProject.Core.Domains.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string Location { get; set; }
        public DateTime BirthDate { get; set; }
        public string Link { get; set; }

    }
}
