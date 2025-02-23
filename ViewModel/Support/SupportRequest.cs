using System.ComponentModel.DataAnnotations;

namespace MapProject.ViewModel.Support
{
    public class SupportRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin hỗ trợ.")]
        public string Question { get; set; }

        public int Sid { get; set; }

        public string? Sname { get; set; }

        public string? Sphone { get; set; }

        public string? Semail { get; set; }

        public string? Scontent { get; set; }

        public bool? IsScomplete { get; set; }
    }
}
