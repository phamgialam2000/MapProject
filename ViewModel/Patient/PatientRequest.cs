namespace MapProject.ViewModel.Patient
{
    public class PatientRequest : PagedResult
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Id { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string? Type { get; set; }

        public string? Name { get; set; }

        public string? Level { get; set; }

        public int? Group { get; set; }

        public string? Note { get; set; }

        public string? Address { get; set; }

        public string? Date { get; set; }

        public int? District { get; set; }
        public string? Dateofbirth { get; set; }

        public string? Phone { get; set; }

        public bool? Isdelete { get; set; }
    }
}
