using API.Dtos.Entities;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
	public class ResourceUrlResolver : IValueResolver<Resource, ResourceDto, string>
	{
		private readonly IConfiguration _config;

		public ResourceUrlResolver(IConfiguration config)
			=> _config = config;

        public string Resolve(Resource source, ResourceDto destination, string destMember, ResolutionContext context)
        {
			if (!string.IsNullOrEmpty(source.ResourceUrl))
			{
				return _config["ApiUrl"] + source.ResourceUrl;
			}

			return null;
		}
    }
}