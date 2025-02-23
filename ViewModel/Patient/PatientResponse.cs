using System.Text.Json.Serialization;

namespace MapProject.ViewModel.Patient
{
    public class PatientResponse
    {
        public int Index { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Latitude")]
        public double? Latitude { get; set; }
        [JsonPropertyName("Longitude")]
        public double? Longitude { get; set; }
        [JsonPropertyName("Type")]
        public string? Type { get; set; }
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Level")]
        public string? Level { get; set; }
        [JsonPropertyName("Group")]
        public int? Group { get; set; }
        [JsonPropertyName("Note")]
        public string? Note { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }
        [JsonPropertyName("Date")]
        public string? Date { get; set; }
        [JsonPropertyName("District")]
        public int? District { get; set; }
        [JsonPropertyName("Dateofbirth")]
        public string? Dateofbirth { get; set; }
        [JsonPropertyName("Phone")]
        public string? Phone { get; set; }



    }
}
