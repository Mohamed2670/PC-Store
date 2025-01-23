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
        public async Task<Product?> GetByNameStoreId(string name,int storeId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name == name && x.StoreId == storeId);
        }
        public async Task<ICollection<Product>?>GetProductPagination(int page,int size = 20)
        {
            return await _context.Products.Skip((page - 1) * size).Take(size).ToListAsync();
        }

    }
}