using Data.SQLServer.Config;
using Domain.Contract.Repositories;
using Domain.Core.Entities;

namespace Data.Repository.Repositories.EF;

public class UserEFRepository : BaseRepository<User>, IUserRepository
{
    public UserEFRepository(SQLServerContext context) : base(context)
    {
    }
}
