using GOTCharactersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GOTCharactersAPI.Services;

public class CharacterControllerService : ICharacterControllerService
{
    public Task<IActionResult> GetAllCharactersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetCharacterByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> CreateCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> UpdateCharacterAsync(int id, string name)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> DeleteCharacterAsync(int id)
    {
        throw new NotImplementedException();
    }
}