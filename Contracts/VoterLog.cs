using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VotersApplication.Contracts
{
    public interface VoterLog
    {
        DateTime VisitDateTime { get; set; }

        ActionResult GetVoterLogs();
    }
}
