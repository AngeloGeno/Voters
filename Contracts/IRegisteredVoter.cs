
using Microsoft.AspNetCore.Mvc;
using VotersApplication.Models;

namespace VotersApplication.Contracts
{
    public interface IRegisteredVoter
    {
        Task<IActionResult> PostRegisteredVoter(RegisteredVoter registeredVoter);
        IActionResult Report();
    }
}
