using Microsoft.AspNetCore.Mvc;
using VotersApplication.Contracts;
using VotersApplication.Repository;

namespace VotersApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoterLogController : ControllerBase
    {
        private readonly IRepository<VoterLog> _voterLogRepository;

        public VoterLogController(IRepository<VoterLog> voterLogRepository)
        {
            _voterLogRepository = voterLogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVoterLogs()
        {
            var voterLogs = await _voterLogRepository.GetAllAsync();
            return Ok(voterLogs);
        }

        [HttpGet("{id}")] ///
        public async Task<IActionResult> GetVoterLog(int id)
        {
            try
            {
                //error 6
                var voterLogs = await _voterLogRepository.GetAllAsync();
                return Ok(voterLogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while retrieving the voterlogs: {ex.Message}");
            }
        }
    }
}
