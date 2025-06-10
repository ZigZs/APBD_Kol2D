using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2C.Models;

[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
[Table("Player_Match")]
public class PlayerMatch
{
    [ForeignKey(nameof(Match))] public int MatchId { get; set; }
    [ForeignKey(nameof(Player))] public int PlayerId { get; set; }
    [Required] public int MVPs { get; set; }
    [Required]public decimal Rating { get; set; }
    
    public Player Player { get; set; }
    public Match Match { get; set; }
}