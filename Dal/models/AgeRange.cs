using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class AgeRange
{
    public int Id { get; set; }

    public string Age { get; set; } = null!;

    public virtual ICollection<Optometrist> Optometrists { get; set; } =
        new List<Optometrist>();

    public AgeRange(int id,string age)
    {
        Id = id;
        Age = age;
    }
}
