using System;
using System.Collections.Generic;

namespace VotersApplication.Models;

public partial class RegisteredVoter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string VoterIdNumber { get; set; } = null!;

    public virtual ICollection<VoterLog> VoterLogs { get; set; } = new List<VoterLog>();
}
