using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotersApplication.Models;
using VotersApplication.Repository;

namespace VotersApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredVoterController : ControllerBase
    {

        private readonly IRepository<RegisteredVoter> _registeredVoterRepository;
        private readonly IRepository<VoterLog> _voterLogRepository;

        public RegisteredVoterController(
            IRepository<RegisteredVoter> registeredVoterRepository,
            IRepository<VoterLog> voterLogRepository)
        {
            _registeredVoterRepository = registeredVoterRepository;
            _voterLogRepository = voterLogRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegisteredVoter(int id)
        {
            try
            {
                var voter = await _registeredVoterRepository.GetByIdAsync(id);
                if (voter == null)
                {
                    return NotFound();
                }

                return Ok(voter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurrd while retrievig the registred voter: {ex.Message}");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterVoter([FromBody] RegisteredVoter voter)
        {
            try
            {
                if (voter == null)
                {
                    return BadRequest("Invalid votr data.");
                }

                var existingVoter = await _registeredVoterRepository.GetByIdAsync(voter.Id);
                if (existingVoter != null)
                {
                    return BadRequest("Voter is already registered.");
                }

                await _registeredVoterRepository.AddAsync(voter);

                var voterLog = new VoterLog
                {
                    VoterId = voter.Id,
                    VoteDate = DateTime.Now
                };
                await _voterLogRepository.AddAsync(voterLog);

                return Ok("Voter registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A error occurred while registerig the voter: {ex.Message}");
            }
        }
    }
  }


