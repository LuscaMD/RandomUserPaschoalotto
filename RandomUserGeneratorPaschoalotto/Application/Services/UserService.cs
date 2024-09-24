using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUserGeneratorPaschoalotto.Application.Interfaces;
using RandomUserGeneratorPaschoalotto.Domain.Entities;
using RandomUserGeneratorPaschoalotto.Infrastructure.Database;
using RandomUserGeneratorPaschoalotto.Infrastructure.ExternalServices;
using System.Runtime.CompilerServices;

namespace RandomUserGeneratorPaschoalotto.Application.Services
{
    public class UserService
    {
        private readonly RandomUserGeneratorPaschoalottoContext _context;
        private readonly IRandomUserGeneratorService _randomUserGeneratorService;

        public UserService(RandomUserGeneratorPaschoalottoContext context, IRandomUserGeneratorService randomUserGeneratorService)
        {
            _context = context;
            _randomUserGeneratorService = randomUserGeneratorService;
        }

        public async Task<List<User>> AddUsers(List<User> users)
        {
            try
            {
                _context.User.AddRange(users);
                await _context.SaveChangesAsync();

                return users;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                throw;
            }
        }

        //public async Task<User> GetNewRandomUser()
        //{
        //    return await _randomUserGeneratorService.GetRandomUserAsync(1);
        //}

        public async Task<List<User>> GenerateAndAddRandomUsers(int count)
        {
            var users = new List<User>();
            var randomUser = await _randomUserGeneratorService.GetRandomUserAsync(count);

            if (randomUser != null)
            {
                users.AddRange(randomUser);
            }
            
            return await AddUsers(users);
        }

        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                var existingUser = await _context.User.FindAsync(id);

                existingUser.Name = user.Name;
                existingUser.Location = user.Location;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.Cell = user.Cell;
                //_context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o usuário: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                if (_context.User == null)
                {
                    return false;
                }

                var usuario = await _context.User.FindAsync(id);
                if (usuario == null)
                {
                    return false;
                }

                _context.User.Remove(usuario);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o usuário: {ex.Message}", ex);
            }
        }

        public async Task<List<User>> GetUsuario()
        {
            try
            {
                if (_context.User == null)
                {
                    return null;
                }

                return await _context.User.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}", ex);
            }
        }

        public async Task<User> GetUsuarios(int id)
        {
            if (_context.User == null)
            {
                return null;
            }
            var usuario = await _context.User.FindAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }
    }
}

