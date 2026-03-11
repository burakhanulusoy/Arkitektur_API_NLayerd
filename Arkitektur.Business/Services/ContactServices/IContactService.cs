using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.Business.DTOs.ContactDtos;

namespace Arkitektur.Business.Services.ContactServices
{
    public interface IContactService
    {

        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<ResultContactDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto updateContact);
        Task<BaseResult<object>> CreateAsync(CreateContactDto createContact);




    }
}
