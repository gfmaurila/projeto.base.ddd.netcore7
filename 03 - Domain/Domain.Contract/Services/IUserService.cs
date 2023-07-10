using Application.DTOs;

namespace Domain.Contract.Services;

public interface IUserService
{
    Task<UserDto> Create(UserDto dto);
    Task<UserDto> Update(UserDto dto);
    Task<bool> Remove(int id);
    Task<UserDto> Get(int id);
    Task<List<UserDto>> Get();
}
