using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class DoctorInfo
    {
        [Key]
        public string InfoId { get; set; }
        public string Doctor { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
    }
}
