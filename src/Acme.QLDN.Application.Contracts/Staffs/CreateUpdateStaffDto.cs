using System.ComponentModel.DataAnnotations;

namespace Acme.QLDN.Staffs
{
    public class CreateUpdateStaffDto
    {
        [Required]
        public string StaffName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; } = 1;

        [Required]
        public string Address { get; set; } = string.Empty;

        public int StatusId { get; set; } = 1;

    }
}
