using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Model;

namespace ServerSide.Repository
{
    public class ProductRepository : GeneRepository<Product>
    {
        private readonly BuilderDBContext _context;
        public ProductRepository(BuilderDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Product?> GetByNameStoreId(string name, int storeId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name == name && x.StoreId == storeId);
        }
        public async Task<ICollection<Product>?> GetProductPagination(int page, int size)
        {
            return await _context.Products.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<ICollection<Product>?> GetProductsByCategoryId(int categoryId, int page, int size)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<ICollection<Product>?> GetProductsByStoreId(int storeId, int page, int size)
        {
            return await _context.Products.Where(x => x.StoreId == storeId).Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<ICollection<Product>?> GetProductsByProductName(string productName, int page, int size)
        {
            return await _context.Products.Where(x=>x.Name.Contains(productName)).Skip((page - 1) * size).Take(size).ToListAsync();
        }

    }
}