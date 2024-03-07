using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<AddressEntity> GetAddressAsync(string UserId)
    {
        var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == UserId);
        return addressEntity!;
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {
        _context.Addresses.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var existing = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == entity.UserId);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
}
