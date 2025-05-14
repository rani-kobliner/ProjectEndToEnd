using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class RegisteredPatient
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
