using System.ComponentModel.DataAnnotations;

namespace decentraMed.Models
{
    public class Visits
    {
        [Key]
        public string VisitId { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Problem { get; set; }
        public string Uid { get; set; }


    }
}
