using System;
using System.Collections.Generic;

namespace TrainingUserLibrary.Models;

public partial class TrainingUser
{
    public string UserId { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserRole { get; set; } = null!;
}
