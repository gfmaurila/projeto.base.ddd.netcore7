using Application.DTOs;
using AutoMapper;
using Domain.Contract.Repositories;
using Domain.Contract.Services;
using Domain.Core.Entities;

namespace Application.Services;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repo;

    public UserService(IMapper mapper, IUserRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<UserDto> Get(int id) => _mapper.Map<UserDto>(await _repo.Get(id));

    public async Task<List<UserDto>> Get() => _mapper.Map<List<UserDto>>(await _repo.Get());

    public async Task<UserDto> Create(UserDto dto)
    {
        var entity = _mapper.Map<User>(dto);
        var entityCreated = await _repo.Create(entity);
        return _mapper.Map<UserDto>(entityCreated);
    }

    public async Task<UserDto> Update(UserDto dto)
    {
        var entity = _mapper.Map<User>(dto);
        var entityUpdated = await _repo.Update(entity);
        return _mapper.Map<UserDto>(entityUpdated);
    }

    public async Task<bool> Remove(int id) => await _repo.Remove(id);
}
