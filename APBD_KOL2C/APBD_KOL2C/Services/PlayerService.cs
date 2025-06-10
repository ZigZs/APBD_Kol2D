using APBD_KOL2C.Data;
using APBD_KOL2C.DTO;
using APBD_KOL2C.Exceptions;
using APBD_KOL2C.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2C.Services;

public class PlayerService : IPlayerService
{
    private readonly DatabaseContext _context;

    public PlayerService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PlayerMatchDto> GetPlayerMatches(int id)
    {
        var customer = await _context.Players
            .FirstOrDefaultAsync(c => c.PlayerId == id);

        if (customer == null)
        {
            throw new NotFoundException($"Nie znaleziono klient z Id {id}");
        }
        
        
        var purchases = await _context.PlayerMatches
            .Where(p => p.PlayerId == id)
            .Include(p => p.Match)
            .ThenInclude(wp => wp.Map)
            .Include(p => p.Match)
            .ThenInclude(m => m.Tournament)
            .ToListAsync();

        return new PlayerMatchDto
        {
            PlayerId = customer.PlayerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            BirthDay = customer.BirthDay,
            Matches = purchases.Select(p => new MatchDto
            {
                Tournment = p.Match.Tournament.Name,
                Map = p.Match.Tournament.Name,
                Date = p.Match.MatchDay,
                MVPs = p.MVPs,
                Rating = p.Rating,
                Team1Score = p.Match.Team1Score,
                Team2Score = p.Match.Team2Score

            }).ToList()
        };
    }
    /*public async Task AddPlayerWithPlayerMatches(PostPlayerWithPlayerMatchDto dto)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var player = new Player
            {
                MaxWeight = dto.WashingMachine.maxWeight,
                SerialNumber = dto.WashingMachine.SerialNumber
            };
            _context.WashingMachines.Add(washingMachine);
            await _context.SaveChangesAsync();

            var WashingProgramsNames = dto.AvailablePrograms.Select(p =>
                p.ProgramName
            ).ToList();
            var programs = _context.Programs.Where(p => WashingProgramsNames.Contains(p.Name)).ToList();

            if (programs.Count != WashingProgramsNames.Count)
            {
                throw new NotFoundException($"There is no program like that");
            }

            var availablePrgrams = dto.AvailablePrograms.Select(apDto =>
                {
                    var program = programs.First(p => p.Name == apDto.ProgramName);
                    return new AvailableProgram
                    {
                        WashingMachineId = washingMachine.WashingMachineId,
                        ProgramId = program.ProgramId,
                        Price = apDto.Price
                    };
                }
            ).ToList();

            _context.AvailablePrograms.AddRange(availablePrgrams);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }*/
}