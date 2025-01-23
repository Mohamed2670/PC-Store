using AutoMapper;
using ServerSide.Dto.StoreDtos;
using ServerSide.Model;
using ServerSide.Repository;

namespace ServerSide.Service
{
    public class StoreService(StoreRepository _repository, IMapper _mapper) 
    {
        public async Task<StoreReadDto?> AddStore(StoreAddDto storeAddDto)
        {
            var store = _mapper.Map<Store>(storeAddDto);
            var storeAdded = await _repository.Add(store);
            var storeReadDto = _mapper.Map<StoreReadDto>(storeAdded);
            return storeReadDto;

        }
        public async Task<ICollection<StoreReadDto>?> GetAllStores()
        {
            var stores = await _repository.GetAll();
            var storeReadDtos = _mapper.Map<ICollection<StoreReadDto>>(stores);
            return storeReadDtos;
        }
        public async Task<StoreReadDto?> UpdateStore(StoreUpdateDto storeUpdateDto,string name)
        {
            var store = await _repository.GetByName(name);
            if (store == null)
            {
                return null;
            }
            var storeUpdated = await _repository.Update(_mapper.Map(storeUpdateDto, store));
            var storeReadDto = _mapper.Map<StoreReadDto>(storeUpdated);
            return storeReadDto;
        }
        public async Task<StoreReadDto?> GetStoreByName(string name)
        {
            var store = await _repository.GetByName(name);
            var storeReadDto = _mapper.Map<StoreReadDto>(store);
            return storeReadDto;

        }
        public async Task<StoreReadDto?> DeleteStoreByName(string name)
        {
            var store = await _repository.GetByName(name);
            if (store == null)
            {
                return null;
            }
            var storeDeleted = await _repository.Delete(store.Id);
            var storeReadDto = _mapper.Map<StoreReadDto>(storeDeleted);
            return storeReadDto;
        }
    }
}