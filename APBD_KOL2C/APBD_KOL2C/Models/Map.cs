using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOL2C.Models;

[Table("Map")]
public class Map
{
    [Key] public int MapId { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] [MaxLength(100)] public string Type { get; set; }
}