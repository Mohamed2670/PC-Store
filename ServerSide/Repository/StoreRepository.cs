using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Model;

namespace ServerSide.Repository
{
    public class StoreRepository: GeneRepository<Store>
    {
        private readonly BuilderDBContext _context;
        public StoreRepository(BuilderDBContext context):base(context)
        {
            _context = context;
        }
        public async Task<Store?> GetByName(string name)
        {
            return await _context.Stores.FirstOrDefaultAsync(x => x.Name == name);
        }

    }
}