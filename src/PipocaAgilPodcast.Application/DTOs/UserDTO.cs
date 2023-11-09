using System.ComponentModel.DataAnnotations;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Infrastructure.ValidationAttributes;

namespace PipocaAgilPodcast.Application.DTOs
{
    public class UserDTO
    {
        public UserDTO(int id, string fullName, string userName, string imageURL, DateTime dateOfBirth) 
        {
            this.Id = id;
            this.FullName = fullName;
            this.UserName = userName;
            this.ImageURL = imageURL;
            this.DateOfBirth = dateOfBirth;
   
        }

        public UserDTO()
        {
            UsersActivitiesLogs = new List<UserActivityLog>();
            Interests = new List<Interest>();
        }

        public int Id { get; set; }
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 4,
            ErrorMessage ="O campo {0} deve conter entre 4 e 50 caractere.")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Nome de Usuário")]
        [StringLength(50, MinimumLength = 4,
            ErrorMessage ="O campo {0} deve conter entre 4 e 50 caractere.")]
        public string UserName { get; set; } = string.Empty;

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png|webp)$",
            ErrorMessage = "Não é uma imagem válida. A extensão da sua imagem deve ser: (webp, gif, jpg, jpeg, bmp ou png)")]
        public string ImageURL { get; set; } = string.Empty;

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinimumAge(18, ErrorMessage = "Você deve ter pelo menos 18 anos.")]
        public DateTime DateOfBirth { get; set; }
        public virtual IEnumerable<Interest>? Interests { get; set; }
        public virtual ActivityStatistics? Statistics { get; set; }
        public IEnumerable<UserActivityLog>? UsersActivitiesLogs { get; set; }

    }
}