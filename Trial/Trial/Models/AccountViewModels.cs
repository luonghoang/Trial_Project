using System.ComponentModel.DataAnnotations;

namespace Trial.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="ユーザーID")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }
    }

    public class LoginUserViewModel
    {
        public string User_Id { get; set; }

        public string User_Token { get; set; }

        public string User_Name { get; set; }
    }

}
