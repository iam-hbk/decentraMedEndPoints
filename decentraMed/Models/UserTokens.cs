using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class UserTokens
    {
        [Key]
        public int id{ get; set; }
        public string Type { get; set; }
        public int Token { get; set; }
        public string uid { get; set; }
    }
}
