using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Model;

namespace ServerSide.Repository
{
    public class PriceRepository : GeneRepository<Price>
    {
            private readonly BuilderDBContext _context;

        public PriceRepository(BuilderDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ICollection<Price>> GetByProductId(int productId)
        {
            return await _context.Prices.Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}