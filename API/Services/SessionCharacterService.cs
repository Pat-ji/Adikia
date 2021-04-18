using API.Interfaces.Services;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class SessionCharacterService : ISessionCharacterService
    {
        private readonly IBaseRepository<Game> _gameRepository;
        private readonly IBaseRepository<SessionCharacter> _sessionCharacterRepository;

        public SessionCharacterService(IBaseRepository<Game> gameRepository, IBaseRepository<SessionCharacter> sessionCharacterRepository)
        {
            _gameRepository = gameRepository;
            _sessionCharacterRepository = sessionCharacterRepository;
        }

        public async Task<IEnumerable<SessionCharacter>> CreateSessionCharacters(Session session)
        {
            var game = await _gameRepository.GetWithSpecAsync(new GameSpecification.WithCharacters(session.GameId));

            // Get all characters for the sessions game and map them to a session character
            var sessionCharacters = game.Characters.Select(x => new SessionCharacter
            {
                SessionId = session.Id,
                CharacterId = x.Id,
                CharacterStage = 0
            });

            return await _sessionCharacterRepository.AddRangeAsync(sessionCharacters, true);
        }
    }
}
