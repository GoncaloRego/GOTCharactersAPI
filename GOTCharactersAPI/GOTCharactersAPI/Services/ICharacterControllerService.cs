using GOTCharactersAPI.Dtos;
using GOTCharactersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GOTCharactersAPI.Services;

public interface ICharacterControllerService
{
    Task<List<CharacterResponseDto>> GetAllCharactersAsync();
    Task<CharacterResponseDto?> GetCharacterByIdAsync(int id);
    Task<CharacterResponseDto> CreateCharacterAsync(CreateCharacterRequest character);
    Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);
    Task<bool> DeleteCharacterAsync(int id);
}