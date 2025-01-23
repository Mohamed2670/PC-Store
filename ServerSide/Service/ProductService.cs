using AutoMapper;
using ServerSide.Dto.PriceDtos;
using ServerSide.Dto.ProductDtos;
using ServerSide.Model;
using ServerSide.Repository;

namespace ServerSide.Service
{
    public class ProductService(ProductRepository _repository, IMapper _mapper, StoreRepository _storeRepository, PriceRepository _priceRepository)
    {
        public async Task<ProductReadDto?> AddProduct(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            var productAdded = await _repository.Add(product);
            var store = await _storeRepository.GetById(productAdded.StoreId);
            if (store == null)
            {
                return null;
            }
            var oldProduct = await _repository.GetByNameStoreId(productAdded.Name, store.Id);
            if (oldProduct != null)
            {
                await UpdateProduct(oldProduct.Id, _mapper.Map<ProductUpdateDto>(product));
            }
            var priceAddDto = new PriceAddDto
            {
                ProductId = productAdded.Id,
                Value = productAdded.CurrentPrice,
                Date = DateTime.UtcNow
            };
            var price = _mapper.Map<Price>(priceAddDto);
            await _priceRepository.Add(price);
            return _mapper.Map<ProductReadDto>(productAdded);

        }
        public async Task<Product?> GetProductByNameStoreId(string name, string storeName)
        {
            var store = await _storeRepository.GetByName(storeName);
            if (store == null)
            {
                return null;
            }
            return await _repository.GetByNameStoreId(name, store.Id);
        }
        public async Task<ProductReadDto?> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return null;
            }
            _mapper.Map(productUpdateDto, product);
            var productUpdated = await _repository.Update(product);
            return _mapper.Map<ProductReadDto>(productUpdated);
        }
        public async Task<ProductReadDto?> DeleteProductById(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return null;
            }
            var productDeleted = await _repository.Delete(id);
            return _mapper.Map<ProductReadDto>(productDeleted);
        }
        public async Task<ICollection<ProductReadDto>?> GetAllProducts(int page,int size)
        {
            var products = await _repository.GetProductPagination(page, size);
            return _mapper.Map<ICollection<ProductReadDto>>(products);
        }
        public async Task<ProductReadDto?>GetProductById(int id)
        {
            var product = await _repository.GetById(id);
            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return productReadDto;
        }
    }

}