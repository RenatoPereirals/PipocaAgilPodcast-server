using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using AutoMapper;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Application.DTOs;

namespace PipocaAgilPodcast.Authentication.Implementations
{
    public class TokenService
    {
        
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config,
                            UserManager<User> userManager,
                            IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _mapper = mapper;

            string tokenKey = config["TokenKey"]!;

            if (tokenKey == null) throw new Exception("TokenKey não está presente na configuração");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        }

        // Método para criar um token JWT com base nas informações do usuário
        public async Task<string> CreateToken(UserUpdateDTO userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // Reivindicação para o ID do usuário
                new Claim(ClaimTypes.Name, user.UserName)  // Reivindicação para o nome do usuário
            };

            var roles = await _userManager.GetRolesAsync(user);  // Obter as funções (roles) do usuário

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));  // Adicionar as reivindicações das funções (roles) do usuário

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);  // Credenciais para assinar o token

            var tokenDescription = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),  // Definir as reivindicações do token
                Expires = DateTime.Now.AddDays(1),  // Definir a validade do token para expirar após 1 dia
                SigningCredentials = creds  // Definir as credenciais de assinatura do token
            };

            var tokenHadler = new JwtSecurityTokenHandler();
            
            var token = tokenHadler.CreateToken(tokenDescription);  // Criar o token JWT

            return tokenHadler.WriteToken(token);  // Retornar o token JWT como uma string
        }
    }
}