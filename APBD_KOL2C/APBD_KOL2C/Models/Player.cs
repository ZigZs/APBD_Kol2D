using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOL2C.Models;

[Table("Player")]
public class Player
{
    [Key] public int PlayerId { get; set; }
    [Required][MaxLength(50)] public string FirstName { get; set; }
    [Required][MaxLength(100)] public string LastName { get; set; }
    [Required] public DateTime BirthDay { get; set; }

}