namespace decentraMed.Models
{
    public class ResponseModel
    {
        public User user { get; set; }
        public List<Diagnosis> diagnosis { get; set; }
        public List<Allergies> allergies { get; set; }
        public List<Visits> visits{ get; set; }
        public List<Presciptions> presciptions { get; set; }
    }
}
