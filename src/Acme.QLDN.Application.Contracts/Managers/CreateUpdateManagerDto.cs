using System.ComponentModel.DataAnnotations;

namespace Acme.QLDN.Managers
{
    public class CreateUpdateManagerDto
    {
        [Required]
        public string ManagerName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; } = 1;

        [Required]
        public string Address { get; set; } = string.Empty;

        public int StatusId { get; set; } = 1;
    }
}
