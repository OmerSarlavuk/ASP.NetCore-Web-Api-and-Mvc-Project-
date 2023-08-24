using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Security.JWT
{
    public class JwtGenerator
    {
        private readonly IConfiguration _configuration;
        private TokenOptions _tokenOptions;
        private DateTime _tokenExpiration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken()
        {
            _tokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.TokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (_tokenOptions.SecurityKey!));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials);

            var jwtHandler = new JwtSecurityTokenHandler();

            var token = jwtHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _tokenExpiration,
                Claims = new List<string> { "CLAIM1", "CLAIM2", "CLAIM3" }
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken
                (
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _tokenExpiration, 
                    notBefore: DateTime.Now,
                    claims: new List<Claim> { new Claim("KEY1", "VALUE1"), new Claim("KEY2", "VALUE2"), new Claim("KEY3", "VALUE3") },
                    signingCredentials: signingCredentials
                );
            return jwtSecurityToken;
        }

    }
}
