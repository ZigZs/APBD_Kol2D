using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOL2C.Models;

[Table("Tournament")]
public class Tournament
{
    [Key] public int TournamentId { get; set; }
    [Required] [MaxLength(50)] public string Name { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }

}