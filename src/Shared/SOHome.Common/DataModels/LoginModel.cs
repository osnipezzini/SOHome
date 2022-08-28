using MediatR;

using SOHome.Common.Models;

using System.ComponentModel.DataAnnotations;

namespace SOHome.Common.DataModels
{
    public class LoginModel : ObservableObject, IRequest<UserDto>
    {
        #region Váriaveis privadas
        private string username;
        private string password;
        private string totp;
        private bool rememberMe = false;
        #endregion
        #region Propriedades
        [Required]
        [Display(Name = "Nome de usuário")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
        public string Username { get => username; set => SetProperty(ref username, value); }
        [Required]
        [Display(Name = "Senha")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get => password; set => SetProperty(ref password, value); }
        [Required]
        [Display(Name = "Senha OTP")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
        [DataType(DataType.Password)]
        public string TOTP { get => totp; set => SetProperty(ref totp, value); }
        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get => rememberMe; set => SetProperty(ref rememberMe, value); }
        #endregion
    }
}
