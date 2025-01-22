using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Model;

namespace ServerSide.Repository
{
    public class ProductRepository : GeneRepository<Product>
    {
        private readonly BuilderDBContext _context;
        public ProductRepository(BuilderDBContext context) :base(context)
        {
            _context = context;
        }
        public async Task<Product?> GetByNameStoreId(string title,int storeId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name == title && x.StoreId == storeId);
        }

    }
}