using Dapper;

using Microsoft.Extensions.Options;

using UserAuthenticationService.Infrastructure.Abstractions.Repositories;
using UserAuthenticationService.Infrastructure.Settings;

namespace UserAuthenticationService.Infrastructure.Repositories;

public sealed class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public Task Add()
    {
        throw new NotImplementedException();
    }

    public Task Get()
    {
        throw new NotImplementedException();
    }
}