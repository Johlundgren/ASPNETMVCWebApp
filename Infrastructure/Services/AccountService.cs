using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class AccountService
{
    private readonly AppDbContext _context;
    private readonly UserManager<UserEntity> _userManager;

    public AccountService(AppDbContext context, UserManager<UserEntity> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // NY INFO
    public async Task<IdentityResult> UpdateUserAccountAsync(UserEntity user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error  in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
            }
        }
        return result;
    }

}