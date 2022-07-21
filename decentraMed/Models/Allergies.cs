using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class Allergies
    {
        [Key]
        public string AllergyId { get; set; }
        public string AllergyName { get; set; }
        public string Description { get; set; }
        public string Uid { get; set; }
    }
}
