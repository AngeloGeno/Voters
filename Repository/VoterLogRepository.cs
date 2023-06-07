using VotersApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace VotersApplication.Repository
{
    public class VoterLogRepository : IRepository<VoterLog>
    {
        private readonly VoterContext _context;

        public VoterLogRepository(VoterContext context)
        {
            _context = context;
        }

        public async Task<VoterLog> GetByIdAsync(int id)
        {
            return await _context.VoterLogs.FindAsync(id);
        }

        public async Task<IEnumerable<VoterLog>> GetAllAsync()
        {
            return await _context.VoterLogs.Include(v => v.Voter).ToListAsync();
        }

        public async Task AddAsync(VoterLog entity)
        {
            await _context.VoterLogs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VoterLog entity)
        {
            _context.VoterLogs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(VoterLog entity)
        {
            _context.VoterLogs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
 }
