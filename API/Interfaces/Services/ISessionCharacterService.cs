using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces.Services
{
    public interface ISessionCharacterService
    {
        Task<IEnumerable<SessionCharacter>> CreateSessionCharacters(Session session);
    }
}
