using System.ComponentModel.DataAnnotations;
using PipocaAgilPodcast.Infrastructure.ValidationAttributes;

namespace PipocaAgilPodcast.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="O campo {0} deve conter entre 4 e 50 caractere.")]
        public string FullName { get; set; }

        [Display(Name = "Nome de Usuário")]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="O campo {0} deve conter entre 4 e 50 caractere.")]
        public string UserName { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png|webp)$",
            ErrorMessage = "Não é uma imagem válida. A extensão da sua imagem deve ser: (webp, gif, jpg, jpeg, bmp ou png)")]
        public string? ImageURL { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinimumAge(18, ErrorMessage = "Você deve ter pelo menos 18 anos.")]
        public DateTime DateOfBirth { get; set; }

        public UserDTO()
        {
            FullName = string.Empty;
            UserName = string.Empty;
        }
    }
}