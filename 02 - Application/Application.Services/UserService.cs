using Application.DTOs;
using Application.Responses;
using Application.Validators;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Domain.Contract.Redis;
using Domain.Contract.Repositories;
using Domain.Contract.Services;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Newtonsoft.Json;
using SharpCompress.Common;

namespace Application.Services;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repo;
    private readonly ICacheService _cache;
    private readonly CreateUserValidator _validator;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(ICacheService cache, CreateUserValidator validator, IMapper mapper, IUserRepository repo, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _cache = cache;
        _repo = repo;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserDto>> Get(int id)
    {
        var objEntity = _mapper.Map<UserDto>(await _repo.Get(id));
        if (objEntity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {id}");

        return Result.Success(objEntity);
    }

    public async Task<Result<List<UserDto>>> Get()
    {
        return Result.Success(_mapper.Map<List<UserDto>>(await _repo.Get()));
    }

    public async Task<Result<CreatedUserResponse>> Create(UserDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        if (await _repo.ExistsByEmailAsync(new Email(dto.Email)))
            return Result.Error("O endereço de e-mail informado já está sendo utilizado.");

        var entityCreated = await _repo.Create(_mapper.Map<User>(dto));
        await _unitOfWork.SaveChangesAsync();

        // Add Fila para armazenar no redis 
        await _cache.SetAsyncAll("users", JsonConvert.SerializeObject(entityCreated), TimeSpan.FromHours(1));

        return Result.Success(new CreatedUserResponse(entityCreated.Id), "Cadastrado com sucesso!");
    }

    public async Task<Result> Update(UserDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var objEntity = await _repo.Get(dto.Id);
        if (objEntity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {dto.Id}");

        if (await _repo.ExistsByEmailAsync(new Email(dto.Email), objEntity.Id))
            return Result.Error("O endereço de e-mail informado já está sendo utilizado.");

        await _repo.Update(_mapper.Map<User>(dto));
        await _unitOfWork.SaveChangesAsync();

        await _cache.SetAsyncAll($"user_update_id_{objEntity.Id}_{TimeSpan.FromDays(10)}", JsonConvert.SerializeObject(objEntity), TimeSpan.FromDays(30));

        return Result.SuccessWithMessage("Atualizado com sucesso!");
    }

    public async Task<Result> Remove(int id)
    {
        // Obtendo o registro da base.
        var objEntity = await _repo.Get(id);
        if (objEntity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {id}");

        // Add BKP por mais 30 dias esse redistro removido
        await _cache.SetAsyncAll($"user_delete_id_{objEntity.Id}_{TimeSpan.FromDays(30)}", JsonConvert.SerializeObject(objEntity), TimeSpan.FromDays(30));

        await _repo.Remove(id);
        await _unitOfWork.SaveChangesAsync();

        // Add Fila para armazenar no redis todos produtos
        await _cache.SetAsyncAll("users", JsonConvert.SerializeObject(await Get()), TimeSpan.FromHours(30));

        // Add Fila para armazenar no redis 
        return Result.SuccessWithMessage("Removido com sucesso!");
    }
}
