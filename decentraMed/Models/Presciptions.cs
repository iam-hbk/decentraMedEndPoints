using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class Presciptions
    {
        [Key]
        public string PrescriptionId { get; set; }
        public string PrescriptionName { get; set; }
        public string PrescriptionDate { get; set; }
        public string Doctor { get; set; }
        public string Uid { get; set; }
    }
}
