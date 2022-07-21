using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class Vaccination
    {
        [Key]
        public string VaccinationId { get; set; }
        public string VaccinationName { get; set; }
        public string VaccinationDate { get; set; }
        public string AttendingPhysician { get; set; }
        public string Uid { get; set; }
    }
}
