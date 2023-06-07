using VotersApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace VotersApplication.Repository
{
    public class RegisteredVoterRepository : IRepository<RegisteredVoter>
    {
        private readonly VoterContext _context;

        public RegisteredVoterRepository(VoterContext context)
        {
            _context = context;
        }

        public async Task<RegisteredVoter> GetByIdAsync(int id)
        {
            return await _context.RegisteredVoters.FindAsync(id);
        }

        public async Task<IEnumerable<RegisteredVoter>> GetAllAsync()
        {
            return await _context.RegisteredVoters.ToListAsync();
        }

        public async Task AddAsync(RegisteredVoter entity)
        {
            await _context.RegisteredVoters.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RegisteredVoter entity)
        {
            _context.RegisteredVoters.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RegisteredVoter entity)
        {
            _context.RegisteredVoters.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
