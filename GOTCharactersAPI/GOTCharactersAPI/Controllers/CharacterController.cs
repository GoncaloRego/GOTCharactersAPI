using GOTCharactersAPI.Dtos;
using GOTCharactersAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GOTCharactersAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharacterController(ICharacterControllerService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CharacterResponseDto>>> GetAllCharactersAsync()
    => Ok(await service.GetAllCharactersAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterResponseDto>> GetCharacterAsync(int id)
    {
        var character = await service.GetCharacterByIdAsync(id);

        return character is null ? NotFound("Character with the given Id was not found.") : Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponseDto>> CreateCharacterAsync(CreateCharacterRequest character)
    {
        var newCharacter = await service.CreateCharacterAsync(character);
        return newCharacter;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CharacterResponseDto>> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        var updatedCharacter = await service.UpdateCharacterAsync(id, character);
        
        return updatedCharacter ? NoContent() : NotFound("Character with the given Id was not found.");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CharacterResponseDto>> DeleteCharacterAsync(int id)
    {
        var characterToDelete = await service.DeleteCharacterAsync(id);
        
        return characterToDelete ? NoContent() : NotFound("Character with the given Id was not found.");
    }
}