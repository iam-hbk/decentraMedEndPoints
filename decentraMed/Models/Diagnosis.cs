    using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace decentraMed.Models
{
    public class Diagnosis
    {
        [JsonPropertyName("DiagnosisId")]
        public string DiagnosisId { get; set; }
        [JsonPropertyName("Date")]
        public string Date { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Findings")]
        public string Findings { get; set; }
        [JsonPropertyName("Uid")]        
        public string Uid { get; set; }
    }
}
