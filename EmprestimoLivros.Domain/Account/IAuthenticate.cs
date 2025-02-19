﻿using EmprestimoLivros.Domain.Entities;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExists(string email);
        public string GenerateToken(int id, string email);
        public Task<Usuario> GetUserByEmail(string email);
    }
}
