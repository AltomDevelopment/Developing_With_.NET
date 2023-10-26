using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_Template.ViewModel
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        [DataType(DataType.Text)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [DataType(DataType.Text)]
        [DisplayName("LastName")]
        public string LastName{ get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("EmailAddress")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [DisplayName("PassWord")]
        public string PassWord { get; set; }

        public string SignupErrorMessage { get; set; }

    }

}
