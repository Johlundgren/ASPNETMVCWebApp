using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AccountService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<UserEntity> _userManager;

        public AccountService(AppDbContext context, UserManager<UserEntity> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public async Task<bool> UpdateUserAsync(UserEntity user)
        //{
        //    _context.Users.Add(user);
            
        //}
    }
}
