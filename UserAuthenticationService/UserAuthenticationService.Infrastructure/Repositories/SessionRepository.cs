using Dapper;

using Microsoft.Extensions.Options;

using UserAuthenticationService.Infrastructure.Abstractions.Repositories;
using UserAuthenticationService.Infrastructure.Settings;

namespace UserAuthenticationService.Infrastructure.Repositories;

public sealed class SessionRepository : BaseRepository, ISessionRepository
{
    public SessionRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }
}