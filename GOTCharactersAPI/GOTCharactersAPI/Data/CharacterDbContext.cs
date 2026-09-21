using GOTCharactersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GOTCharactersAPI.Data;

public class CharacterDbContext(DbContextOptions<CharacterDbContext> options) : DbContext(options)
{
    public DbSet<Character> Characters => Set<Character>();
}