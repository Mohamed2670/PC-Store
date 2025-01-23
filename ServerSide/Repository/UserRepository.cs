using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Model;

namespace ServerSide.Repository
{
    public class UserRepository : GeneRepository<User>
    {
        private readonly BuilderDBContext _context;
        public UserRepository(BuilderDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}