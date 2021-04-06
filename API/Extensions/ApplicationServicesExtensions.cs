using System.Linq;
using System.Net;
using API.Data;
using Core.Interfaces;
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

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = actionContext =>
				{
					var errors = actionContext.ModelState
						.Where(x => x.Value.Errors.Any())
						.SelectMany(x => x.Value.Errors)
							.Select(y => y.ErrorMessage)
						.ToArray();

					var response = new ApiResponse<string[]>((int)HttpStatusCode.BadRequest, errors);

					return new BadRequestObjectResult(response);
				};
			});

			return services;
		}
	}
}