using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Arkitektur.Business.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager) : IUserService
    {
        public async Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto)
        {
           
           if(createUserDto.Password != createUserDto.ConfirmPassword)
           {
                return BaseResult<object>.Fail("Your password don't same confirm password.Please check");
           }

            var user=createUserDto.Adapt<AppUser>();

            var result = await _userManager.CreateAsync(user,createUserDto.Password);

            if(!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);

            }

            return BaseResult<object>.Success(new { Message="User Created"});




        }
    }
}
