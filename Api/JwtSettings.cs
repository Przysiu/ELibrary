using CoreLayer.Infrastructure;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Api
{
    public  class JwtSettings
    {
        private static readonly string _section = "JwtSettings";

        private readonly IConfiguration _configuration;
        public string? Issuer =>
       _configuration.GetSection(_section).GetSection("ValidIssuer").Value;
        public string? Audience =>
       _configuration.GetSection(_section).GetSection("ValidAudience").Value;
        public string? Secret =>
       _configuration.GetSection(_section).GetSection("Secret").Value;
        public JwtSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
