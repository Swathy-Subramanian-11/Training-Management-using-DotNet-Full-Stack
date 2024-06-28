using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Technology
{
    public int TechnologyId { get; set; }

    public string TechnologyName { get; set; } = null!;

    public string TechnologyType { get; set; } = null!;

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
