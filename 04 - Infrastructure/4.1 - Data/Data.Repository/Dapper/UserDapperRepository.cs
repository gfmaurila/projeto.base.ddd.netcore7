﻿using Domain.Contract.Repositories;
using Domain.Core.Entities;

namespace Data.Repository.Repositories.Dapper;
public class UserDapperRepository : IUserRepository
{
    public Task<User> Create(User obj)
    {
        throw new NotImplementedException();
    }

    public Task<User> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User obj)
    {
        throw new NotImplementedException();
    }
}
