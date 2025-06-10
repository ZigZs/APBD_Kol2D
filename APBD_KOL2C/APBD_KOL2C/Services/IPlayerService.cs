using APBD_KOL2C.DTO;

namespace APBD_KOL2C.Services;

public interface IPlayerService
{
    Task<PlayerMatchDto> GetPlayerMatches(int id);
    /*
    Task AddPlayerWithPlayerMatches(PostPlayerWithPlayerMatchDto dto);
*/
}