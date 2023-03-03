using System;
using System.Collections.Generic;

namespace AMONIC_Airlines.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Office> Offices { get; } = new List<Office>();
}
