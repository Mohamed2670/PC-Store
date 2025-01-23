using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Model;

namespace ServerSide.Repository
{
    public class BuildRepository : GeneRepository<Build>
    {
        private readonly BuilderDBContext _context;
        public BuildRepository(BuilderDBContext context) :base(context)
        {
            _context = context;
        }
        public async Task<ICollection<Build>?> GetBuildsByUserId(int userId)
        {
            return await _context.Builds.Where(x => x.UserId == userId).ToListAsync();
        }

    }
}