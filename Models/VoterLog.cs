using System;
using System.Collections.Generic;

namespace VotersApplication.Models;

public partial class VoterLog
{
    public int LogId { get; set; }

    public int VoterId { get; set; }

    public DateTime VoteDate { get; set; }

    public virtual RegisteredVoter Voter { get; set; } = null!;
}
