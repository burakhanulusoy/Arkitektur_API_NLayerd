using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.DataAccess.Repositories.ContactRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ContactServices
{
    public class ContactService(IContactRepository _contactRepository
                               ,IUnitOfWork _unitOfWork
                                ,IValidator<Contact> _validator) : IContactService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateContactDto createContact)
        {

            var mappedContact = createContact.Adapt<Contact>();

            var resultValidation = await _validator.ValidateAsync(mappedContact);

            if (!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            await _contactRepository.CreateAsync(mappedContact);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Create Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            if (contact is null)
            {
                return BaseResult<object>.Fail("Contact not Found");
            }

            _contactRepository.Delete(contact);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();

            var mappedContacts = contacts.Adapt<List<ResultContactDto>>();

            return BaseResult<List<ResultContactDto>>.Success(mappedContacts);

        }

        public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            if (contact is null)
            {
                return BaseResult<ResultContactDto>.Fail("Contact Not Found");
            }

            var mappedContacts = contact.Adapt<ResultContactDto>();

            return BaseResult<ResultContactDto>.Success(mappedContacts);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto updateContact)
        {
            var mappedContacts = updateContact.Adapt<Contact>();

            var resultValidation = await _validator.ValidateAsync(mappedContacts);

            if (!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            _contactRepository.Update(mappedContacts);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");





        }
    }
}
