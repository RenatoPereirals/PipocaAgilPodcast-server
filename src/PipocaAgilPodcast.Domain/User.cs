namespace PipocaAgilPodcast.Domain;

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName  { get; set; } 
        public string? ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public  DateTime RegistrationDate { get; private set; }
        public DateTime LastAccess { get; private set; }

    // Construtor sem par�metros (inicializa a entidade user com valores padr�o)
        public User()
        {
            FullName = string.Empty;
            UserName = string.Empty;
            RegistrationDate = DateTime.UtcNow;
        }

    // Construtor com par�metros (criar a entidade user com valores espec�ficos)
        public User(string fullName,
                    string userName,
                    string imageURL,
                    DateTime dateOfBirth)
        {
            FullName = fullName;
            UserName = userName;
            ImageURL = imageURL;
            DateOfBirth = dateOfBirth;
            LastAccess = DateTime.UtcNow; // Define o �ltimo acesso como a data/hora atual
        }
    }
    