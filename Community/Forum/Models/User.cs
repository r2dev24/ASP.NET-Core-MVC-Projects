using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required(ErrorMessage = "닉네임을 입력하세요.")]
        [RegularExpression(@"^[가-힣a-zA-Z0-9]{4,}$", ErrorMessage = "닉네임은 한글, 영문, 숫자만 포함하며 최소 4자리 이상이어야 합니다.")]
        public string User_NickName { get; set; }

        // 외래 키 설정
        [ForeignKey("Account")]
        public int Account_ID { get; set; }

        // 네비게이션 속성
        public virtual Account Account { get; set; }
    }
}
