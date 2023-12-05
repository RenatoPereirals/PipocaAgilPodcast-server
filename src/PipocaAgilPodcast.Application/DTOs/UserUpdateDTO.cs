namespace PipocaAgilPodcast.Application.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName  { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public  DateTime RegistrationDate { get; set; }
        public DateTime LastAccess { get; set; }

        public UserUpdateDTO()
        {
            FullName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
        }
    }
}