using System.Linq;
using API.Errors;
using API.Services;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IGameService, GameService>();
			services.AddScoped<IUserGameService, UserGameService>();
			services.AddScoped<ISessionService, SessionService>();
			services.AddScoped<ISessionCharacterService, SessionCharacterService>();

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = actionContext =>
				{
					var errors = actionContext.ModelState
						.Where(x => x.Value.Errors.Any())
						.SelectMany(x => x.Value.Errors)
							.Select(y => y.ErrorMessage)
						.ToArray();

					var response = new ApiValidationErrorResponse(errors);

					return new BadRequestObjectResult(response);
				};
			});

			return services;
		}
	}
}