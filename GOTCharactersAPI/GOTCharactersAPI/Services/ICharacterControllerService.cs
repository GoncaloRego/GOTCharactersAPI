using GOTCharactersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GOTCharactersAPI.Services;

public interface ICharacterControllerService
{
    Task<IActionResult> GetAllCharactersAsync();
    Task<IActionResult> GetCharacterByIdAsync(int id);
    Task<IActionResult> CreateCharacterAsync(Character character);
    Task<IActionResult> UpdateCharacterAsync(int id, string name);
    Task<IActionResult> DeleteCharacterAsync(int id);
}