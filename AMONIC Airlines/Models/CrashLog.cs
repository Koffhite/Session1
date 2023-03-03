using System;
using System.Collections.Generic;

namespace AMONIC_Airlines.Models;

public partial class CrashLog
{
    public int Id { get; set; }

    public DateTime? Login { get; set; }

    public DateTime? Logout { get; set; }

    public string? Error { get; set; }

    public bool? CrashType { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
