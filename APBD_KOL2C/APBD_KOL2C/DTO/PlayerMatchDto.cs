namespace APBD_KOL2C.DTO;

public class PlayerMatchDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public List<MatchDto> Matches { get; set; }
}

public class MatchDto
{
    public string Tournment { get; set; }
    public string Map { get; set; }
    public DateTime Date { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}
