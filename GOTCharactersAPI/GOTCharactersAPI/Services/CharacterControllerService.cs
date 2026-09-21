using GOTCharactersAPI.Data;
using GOTCharactersAPI.Dtos;
using GOTCharactersAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GOTCharactersAPI.Services;

public class CharacterControllerService (CharacterDbContext context) : ICharacterControllerService
{
    private static List<Character> characters =
    [
        new Character { Id = 1, Name = "Jon Snow", Kingdom = "North", Title = "King in the North" },
        new Character { Id = 2, Name = "Daenerys Targaryen", Kingdom = "Essos", Title = "Queen of the Ashes"},
        new Character { Id = 3, Name = "Cersei Lannister", Kingdom = "Kings Landing", Title = "Queen of the Seven Kingdoms"},
        new Character { Id = 4, Name = "Night King", Kingdom = "Beyond the wall", Title = "King of the night walkers"}
    ];
        
    public async Task<List<CharacterResponseDto>> GetAllCharactersAsync() => await context.Characters.Select(c => new CharacterResponseDto()
        {
            Id = c.Id,
            Name = c.Name,
            Kingdom = c.Kingdom,
            Title = c.Title,
        }).ToListAsync();

    public async Task<CharacterResponseDto? > GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters
            .Where(c => c.Id == id)
            .Select(c => new CharacterResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            Kingdom = c.Kingdom,
            Title = c.Title,
        }).FirstOrDefaultAsync();

        return result;
    }

    public async Task<CharacterResponseDto> CreateCharacterAsync(CreateCharacterRequest character)
    {
        var newCharacter = new Character
        {
            Id = character.Id,
            Name = character.Name,
            Kingdom = character.Kingdom,
            Title = character.Title,
        };
        
        context.Characters.Add(newCharacter);
        await context.SaveChangesAsync();

        return new CharacterResponseDto
        {
            Id = newCharacter.Id,
            Name = newCharacter.Name,
            Kingdom = newCharacter.Kingdom,
            Title = newCharacter.Title,
        };
    }

    public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        var oldCharacter = await context.Characters.FindAsync(id);
        
        if (oldCharacter is null)
            return false;
        
        oldCharacter.Name = character.Name;
        oldCharacter.Kingdom = character.Kingdom;
        oldCharacter.Title = character.Title;
        
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        var character = await context.Characters.FindAsync(id);

        if (character is null)
            return false;

        context.Characters.Remove(character);
        
        await context.SaveChangesAsync();
        return true;
    }
}