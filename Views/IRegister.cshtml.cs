using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using VotersApplication.Models;
using VotersApplication.Repository;

public class RegisterModel : PageModel
{
    private readonly IRepository<RegisteredVoter> _registeredVoterRepository;
    private readonly IRepository<VoterLog> _voterLogRepository;

    [BindProperty]
    public int IdNumber { get; set; }

    [TempData]
    public string Message { get; set; }

    public RegisterModel(
        IRepository<RegisteredVoter> registeredVoterRepository,
        IRepository<VoterLog> voterLogRepository)
    {
        _registeredVoterRepository = registeredVoterRepository;
        _voterLogRepository = voterLogRepository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var existingVoter = await _registeredVoterRepository.GetByIdAsync(IdNumber);
            if (existingVoter != null)
            {
                Message = "Voter is already registered.";
            }
            else
            {
                var voter = new RegisteredVoter { Id = IdNumber };
                await _registeredVoterRepository.AddAsync(voter);

                var voterLog = new VoterLog
                {
                    VoterId = IdNumber,
                    VoteDate = DateTime.Now
                };
                await _voterLogRepository.AddAsync(voterLog);

                Message = "Voter registered successfully.";
            }
        }
        catch (Exception ex)
        {
            Message = $"An error occurred while registering the voter: {ex.Message}";
        }

        return RedirectToPage("Register");
    }
}