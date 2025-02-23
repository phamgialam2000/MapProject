using System.ComponentModel.DataAnnotations;

namespace MapProject.ViewModel.Support
{
    public class SupportResponse
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
    }
}
