using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "이메일을 입력해주세요.")]
        [EmailAddress(ErrorMessage = "유효한 이메일 주소가 아닙니다.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "비밀번호는 6자리 이상이여야 합니다.")]
        [RegularExpression(@"^(?=.*[!@#$%^&*(),.?""{}\|<>]).+$", ErrorMessage = "비밀번호에는 최소 하나의 특수문자가 포함되어야 합니다.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "닉네임을 입력하세요.")]
        [RegularExpression(@"^[가-힣a-zA-Z0-9]{4,}$", ErrorMessage = "닉네임은 한글, 영문, 숫자만 포함하며 최소 4자리 이상이어야 합니다.")]
        public string NickName { get; set; }

        public Personal? Personal { get; set; }
        public Admin? Admin { get; set; }
    }
}
