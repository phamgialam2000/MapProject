using System;
using System.Collections.Generic;

namespace MapProject.Models;

public partial class Patient
{
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
}
