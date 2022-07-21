using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class User
    {
        [Key]
        public string uid { get; set; }
        public string idNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string DoB { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        
        
    }
}
