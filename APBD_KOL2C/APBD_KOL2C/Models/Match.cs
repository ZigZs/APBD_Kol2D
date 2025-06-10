using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOL2C.Models;

[Table("Match")]
public class Match
{
    [Key] public int MatchId { get; set; }
    [ForeignKey(nameof(Tournament))] public int TournamentId { get; set; }
    [ForeignKey(nameof(Map))] public int MapId { get; set; }
    [Required] public DateTime MatchDay { get; set; }
    [Required] public int Team1Score { get; set; }
    [Required] public int Team2Score { get; set; }
    public decimal? BestRating { get; set; }
    
    public Map Map { get; set; }
    public Tournament Tournament { get; set; }
}